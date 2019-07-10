using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.EFile2.Utilities.Filters;
using TamTech.Monshaat.POS.Web.Core.Settings.Utilities;
using TamTech.Monshaat.POS.Web.Models.Dtos.Attachments;
using TamTech.Monshaat.POS.Web.Services.ContentService.Attributes;
using TamTech.Monshaat.POS.Web.Services.ContentService.Attributes.Models;
using TamTech.Monshaat.POS.Web.Services.POSs.Directory.Models;
using TamTech.Monshaat.POS.Web.Services.POSs;
using TamTech.Monshaat.POS.Web.Services.POSs.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sectors;
using TamTech.Monshaat.POS.Web.Services.ContentService.Types;
using TamTech.Monshaat.POS.Web.Services.ContentService.Types.Models;
using TamTech.Monshaat.POS.Web.Services.Upload;
using TamTech.Monshaat.POS.Web.Core.Constants;
using TamTech.Monshaat.POS.Web.Core.Extensions;
using TamTech.Monshaat.POS.Web.Core.Mappers.Pos;
using TamTech.Monshaat.POS.Web.Core.Filters;
using TamTech.Monshaat.POS.Web.Models.VMs.Portal.Pos;
using TamTech.Monshaat.POS.Web.Core.Telemetry;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.Upload.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sectors.Models;

namespace TamTechSDK.Web.Controllers.Portal
{
    [ServiceFilter(typeof(UserActivityFilter))]
    [ServiceFilter(typeof(UserContextUpdatedFilter))]
    public class PosController : PublicBaseController
    {
        #region properties
        private readonly IPosTypeService _posTypeService;
        private readonly IPOSSectorServices _sectorService;
        private readonly IPOSAttributeService _attributeService;
        private readonly IPOSService _posservice;
        private readonly IUploadManagerService _uploadManager;
        private IStringLocalizer<BaseController> _localizer;
        private readonly SettingsHelpers _settingsHelpers;
        #endregion

        #region constructor
        public PosController(
            ITelemetryService telemetryClientService,
            IPosTypeService posTypeService,
            IPOSSectorServices sectorService,
            IPOSAttributeService attributeService,
            IPOSService posservice,
            IUploadManagerService uploadManager,
            IStringLocalizer<BaseController> localizer,
            SettingsHelpers settingsHelpers) : base(telemetryClientService, localizer)
        {
            _posTypeService = posTypeService;
            _sectorService = sectorService;
            _attributeService = attributeService;
            _posservice = posservice;
            _uploadManager = uploadManager;
            _localizer = localizer;
            _settingsHelpers = settingsHelpers;
        }
        #endregion

        #region utilities
 

        private List<SelectListItem> CreateTypeSelect(List<TypeDto> types, int TypeId = 0)
        {
            List<SelectListItem> _Types = new List<SelectListItem>();

            foreach (TypeDto item in types)
            {
                _Types.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString(),
                    Selected = item.Id == TypeId,
                });
            }
            return _Types;
        }

        private List<AttributeDto> CreateAttributes(PosFormVm model, List<AttributeDto> attributes, bool isUpdate = false)
        {

            if (isUpdate && model.SpecificationsB.Count > 0)
            {

                foreach (var item in model.SpecificationsB)
                {
                    foreach (var val in item.Values)
                    {
                        var valueDto = attributes.Where(att => att.Id == item.Id).SelectMany(att => att.Values).FirstOrDefault(v => v.Id == val.Id);
                        if (valueDto != null)
                            valueDto.Checked = true;
                    }

                }
            }
            attributes.ForEach(s =>
            {
                s.Values = s.Values.OrderBy(v => v.Id).ToList();
            });
            return attributes;

        }
        private async Task InitAction(PosFormVm model, bool isUpdate = false)
        {
            var types = await _posTypeService.GetPublishedListAsync();


            ViewBag.TypsSelect = VerifySucceed(types) ? CreateTypeSelect(types.Data, model.TypeId) : CreateTypeSelect(new List<TypeDto>(), model.TypeId);

            var _sectors = await _sectorService.GetPublishedListAsync(); ;
            ViewBag.sectors = VerifySucceed(_sectors) ? _sectors.Data : new List<SectorDto>();
            var attributes = await _attributeService.GetPublishedListAsync();
            ViewBag.attributes = VerifySucceed(attributes) ? CreateAttributes(model, attributes.Data, isUpdate) : CreateAttributes(model, new List<AttributeDto>(), isUpdate);

        }
        #endregion

        #region index
        [Authorize(Policy = ContentSDKPoliciesConstants.Vendor)]
        public virtual async Task<IActionResult> Index()
        {
            ViewBag.ID = HttpContext.User.Identity.GetUserId();
            try
            {
                var posfilter = new PosFilters
                {
                    Lang = _lang,
                    PageSize = 100,
                    PageNumber = 1
                };
                var result = await _posservice.GetPOSsForCurrentUserAsync(posfilter);
                if (VerifySucceed(result))
                {
                    return View(result.Data);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View();
        }
        #endregion

        #region Pos   

        #region Create Pos
        [Authorize(Policy = ContentSDKPoliciesConstants.Vendor)]
        [ServiceFilter(typeof(AuthorizeEFile))]
        public virtual async Task<IActionResult> CreatePOS()
        {
            PosFormVm model = new PosFormVm();
            await InitAction(model);
            return View("PosForm", model);
        }




        [HttpPost]
        [Authorize(Policy = ContentSDKPoliciesConstants.Vendor)]
        [ServiceFilter(typeof(AuthorizeEFile))]
        public virtual async Task<IActionResult> CreatePOS(PosFormVm model, IFormCollection collection)
        {
            List<AttachmentModel> Attachments = new List<AttachmentModel>();
            bool PreviousUploadFiles = collection.ContainsKey("UploadedFiles");
            var _UploadedFiles = new List<string>();
            int UpCount = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    CreatePosModel _CreateModel = model.MapToCreateModelWithoutAttachments();

                    if (PreviousUploadFiles)
                    {
                        string urlstring = collection["UploadedFiles"];
                        if (urlstring.Length > 0)
                        {
                            _UploadedFiles = urlstring.Split(";;").ToList();

                            foreach (var url in _UploadedFiles)
                            {
                                Attachments.Add(MakeAttachment(url));
                                UpCount++;
                            }
                        }
                    }
                    if (model.Attachments != null && model.Attachments.Count > 0)
                    {
                        int index = 0;
                        List<IFormFile> _files = model.Attachments;
                        var filesInfo = await GenerateListFilesInfo(_files, FileTypesEnum.POSImage);
                        var uploadResult = await _uploadManager.UploadListFilesAsync(filesInfo);

                        foreach (var item in uploadResult.URLs)
                        {

                            if (item.Success)
                            {
                                Attachments.Add(MakeAttachment(item.URL));
                                _UploadedFiles.Add(item.URL);
                                UpCount++;
                            }
                            else
                            {
                                ModelState.AddModelError(_files[index].Name, _localizer["felled_uploading_error", _files[index].FileName]);
                            }

                            index++;
                        }
                        
                        if (!TryValidateModel(model))
                        {
                            await InitAction(model);
                            return View("PosForm", model);
                        }

                    }
                    _CreateModel.Attachments = Attachments;

                    var sendRequest = await _posservice.CreateAsync(_CreateModel);

                    if (sendRequest.Success)
                    {
                        TempData["CreatePosSuccess"] = true;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        HandelResult(sendRequest);
                        ViewBag.UploadedFiles = string.Join(";;", _UploadedFiles);
                        ViewBag.UploadedCount = UpCount;
                        TryValidateModel(model);
                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }


            await InitAction(model);
            return View("PosForm", model);
        }

        #endregion

        #region Edit POS
        [Authorize(Policy = ContentSDKPoliciesConstants.Vendor)]
        [ServiceFilter(typeof(AuthorizeEFile))]
        public virtual async Task<IActionResult> EditPOS(Guid id)
        {
            try
            {
                var request = await _posservice.GetByIdAndCurrentUserExceptSoftDeletedAsync(id, _lang);
                if (VerifySucceed(request))
                {
                    PosFormVm _model = request.Data.MapToPosFormVm();
                    await InitAction(_model, true);
                    ViewBag.UploadedFiles = string.Join(";;", _model.TempImages);
                    ViewBag.UploadedCount = _model.TempImages.Count;
                    return View("PosForm", _model);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            PosFormVm model = new PosFormVm();
            await InitAction(model);
            return View("PosForm", model);
        }



        [HttpPost]
        [Authorize(Policy = ContentSDKPoliciesConstants.Vendor)]
        [ServiceFilter(typeof(AuthorizeEFile))]
        public virtual async Task<IActionResult> EditPos(PosFormVm model, IFormCollection collection)
        {

            List<AttachmentModel> Attachments = new List<AttachmentModel>();
            bool PreviousUploadFiles = collection.ContainsKey("UploadedFiles");
            List<string> _UploadedFiles = new List<string>();
            int UpCount = 0;

            try
            {
                if (ModelState.IsValid)
                {
                    UpdatePosModel _UpdateModel = model.MapToUpdateModelWithoutAttachments();

                    if (PreviousUploadFiles)
                    {
                        string urlstring = collection["UploadedFiles"];
                        if (urlstring.Length > 0)
                        {
                            _UploadedFiles = urlstring.Split(";;").ToList();

                            foreach (var url in _UploadedFiles)
                            {
                                Attachments.Add(MakeAttachment(url));
                                UpCount++;
                            }
                        }
                    }
                    if (model.Attachments != null && model.Attachments.Count > 0)
                    {
                        int index = 0;
                        List<IFormFile> _files = model.Attachments;
                        var filesInfo = await GenerateListFilesInfo(_files, FileTypesEnum.General);
                        var uploadResult = await _uploadManager.UploadListFilesAsync(filesInfo);

                        foreach (var item in uploadResult.URLs)
                        {

                            if (item.Success)
                            {
                                Attachments.Add(MakeAttachment(item.URL));
                                _UploadedFiles.Add(item.URL);
                                UpCount++;
                            }
                            else
                            {
                                ModelState.AddModelError(_files[index].Name, _localizer["felled_uploading_error", _files[index].FileName]);
                            }

                            index++;
                        }

                        if (!TryValidateModel(model))
                        {
                            await InitAction(model);
                            return View("PosForm", model);
                        }

                    }
                    _UpdateModel.Attachments = Attachments;

                    var sendRequest = await _posservice.EditAsync(_UpdateModel);

                    if (sendRequest.Success)
                    {
                        TempData["UpdatePosSuccess"] = true;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        if (sendRequest.Messages.Count > 0)
                        {
                            AddModelStateError(sendRequest.Messages);
                            ViewBag.UploadedFiles = string.Join(";;", _UploadedFiles);
                            ViewBag.UploadedCount = UpCount;
                            TryValidateModel(model);
                            await InitAction(model);
                            return View("PosForm", model);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }


            await InitAction(model);
            return View("PosForm", model);

        }

        #endregion

        #region Delete POS
        [ServiceFilter(typeof(AuthorizeEFile))]
        public virtual async Task<JsonResult> DeletePos(Guid id)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _posservice.SoftDeleteByCurrentUserAsync(id);
                    return Json(new { success = result.Success });
                }
                return Json(new { success = false });
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            return Json(new { success = false });
        }
        #endregion

        #region Validate POS Name 
        [HttpPost]
        public async virtual Task<JsonResult> ValidatePosNameIsExist(string name, Guid id)
        {

            try
            {
                var result = await _posservice.VerifySlugUniqueByNameAsync(name, id != Guid.Empty ? id : (Guid?)null);
                if (result.Success)
                {
                    return Json(result.Data.Unique);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            return Json(new { success = false });
        }

        #endregion
        #endregion

    

        

        #region Global
        [HttpPost("{Culture}/[Area]/[Controller]/DeleteImage")]
        public async virtual Task<JsonResult> DeleteImage(string img)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(img))
                {
                    Dictionary<string, FileTypesEnum> deleteInputModel = new Dictionary<string, FileTypesEnum> { { img, FileTypesEnum.General } };
                    IRequestProviderResult<DeleteFilesModelResult> uploadResult =
                       await _uploadManager.DeleteFilesAsync(deleteInputModel);
                    if (uploadResult.Success)
                    {
                        return Json(new { success = true });
                    }
                    TrackIfNotFilesDeleted(uploadResult.Success, uploadResult.StatusCode, uploadResult.Data, deleteInputModel);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return Json(new { success = false });
        }




        #endregion


       


    }
}
