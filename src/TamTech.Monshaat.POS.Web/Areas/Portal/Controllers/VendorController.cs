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
using TamTech.Monshaat.POS.Web.Services.ContentService.Vendors;
using TamTech.Monshaat.POS.Web.Services.ContentService.Vendors.Models;
using TamTech.Monshaat.POS.Web.Core.Constants;
using TamTech.Monshaat.POS.Web.Core.Extensions;
using TamTech.Monshaat.POS.Web.Core.Mappers.Pos;
using TamTech.Monshaat.POS.Web.Core.Mappers.Vendor;
using TamTech.Monshaat.POS.Web.Core.Filters;
using TamTech.Monshaat.POS.Web.Models.VMs.Portal.Pos;
using TamTech.Monshaat.POS.Web.Models.VMs.Portal.vendor;
using TamTech.Monshaat.POS.Web.Core.Telemetry;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.Upload.Models;

namespace TamTechSDK.Web.Controllers.Portal
{
    [ServiceFilter(typeof(UserActivityFilter))]
    [ServiceFilter(typeof(UserContextUpdatedFilter))]
    public class VendorController : PublicBaseController
    {
        #region properties
        private readonly IPosTypeService _posTypeService;
        private readonly ISectorServices _sectorService;
        private readonly IPOSAttributeService _attributeService;
        private readonly IPOSService _posservice;
        private readonly IUploadManagerService _uploadManager;
        private IStringLocalizer<PublicBaseController> _localizer;
        private readonly IVendorService _vendorServis;
        private readonly SettingsHelpers _settingsHelpers;
        #endregion

        #region constructor
        public VendorController(
            ITelemetryService telemetryClientService,
            IPosTypeService posTypeService,
            ISectorServices sectorService,
            IPOSAttributeService attributeService,
            IPOSService posservice,
            IUploadManagerService uploadManager,
            IStringLocalizer<PublicBaseController> localizer,
            IVendorService vendorServis,
                                    SettingsHelpers settingsHelpers) : base(telemetryClientService)
        {
            _posTypeService = posTypeService;
            _sectorService = sectorService;
            _attributeService = attributeService;
            _posservice = posservice;
            _uploadManager = uploadManager;
            _localizer = localizer;
            _vendorServis = vendorServis;
            _settingsHelpers = settingsHelpers;
        }
        #endregion

        #region utilities

        private readonly static Dictionary<string, string> _VIEWS = new Dictionary<string, string> {
            { "PosForm", "~/Areas/Portal/Views/Vendor/PosForm.cshtml" },
            {"VendorForm","~/Areas/Portal/Views/Vendor/VendorForm.cshtml" },
            {"VendorInfo","~/Areas/Portal/Views/Vendor/VendorInfo.cshtml" },

        };

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
            ViewBag.TypsSelect = CreateTypeSelect(types.Data, model.TypeId);
            ViewBag.sectors = await _sectorService.GetPublishedListAsync();
            var attributes = await _attributeService.GetPublishedListAsync();
            ViewBag.attributes = CreateAttributes(model, attributes.Data, isUpdate);

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
                return View(result);
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
            return View(_VIEWS["PosForm"], model);
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
                            return View(_VIEWS["PosForm"], model);
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
                        if (sendRequest.Messages.Count > 0)
                        {
                            AddModelStateError(sendRequest.Messages);
                            ViewBag.UploadedFiles = string.Join(";;", _UploadedFiles);
                            ViewBag.UploadedCount = UpCount;
                            TryValidateModel(model);
                            await InitAction(model);
                            return View(_VIEWS["PosForm"], model);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }


            await InitAction(model);
            return View(_VIEWS["PosForm"], model);
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
                if (request.Success)
                {
                    PosFormVm _model = request.Data?.MapToPosFormVm();
                    await InitAction(_model, true);
                    ViewBag.UploadedFiles = string.Join(";;", _model.TempImages);
                    ViewBag.UploadedCount = _model.TempImages.Count;
                    return View(_VIEWS["PosForm"], _model);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            PosFormVm model = new PosFormVm();
            await InitAction(model);
            return View(_VIEWS["PosForm"], model);
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
                            return View(_VIEWS["PosForm"], model);
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
                            return View(_VIEWS["PosForm"], model);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }


            await InitAction(model);
            return View(_VIEWS["PosForm"], model);

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

        #region Vendors



        #region CREATE VENDOR
        [NonAction]
        public async Task<IActionResult> PrepareVendorForm(bool editMode)
        {
            VendorFormVm model = null;
            //<<<<< Case 1 :  Not anonymous user >>>>>
            if (User.Identity.IsAuthenticated)
            {
                var roles = HttpContext.User.Identity.GetUserRoles();
                string vendorRole = await _settingsHelpers.GetVendorRoleNameAsync();
                if (roles != null && roles.All(v => v.Equals(vendorRole, StringComparison.InvariantCultureIgnoreCase)))
                {
                    if (await _vendorServis.CheckTheCurrentUserIsRegisteredAsVendorAsync())
                    {
                        //<<<<< Case 1-A1 : vendor info editing mode  >>>>>
                        if (editMode)
                        {
                            try
                            {
                                var result = await _vendorServis.GetPersonForCurrentUserAsync(_lang);
                                return View(_VIEWS["VendorForm"], result?.MapToVendorFormVm());
                            }
                            catch (Exception ex)
                            {
                                TrackException(ex);
                            }
                        }
                        var IsVendorRole = User.Identity.GetUserRolesCommaSeparated()?.Equals(TamTech.Monshaat.POS.EFile2.Utilities.Helpers.VendorRole, StringComparison.InvariantCultureIgnoreCase);
                        if (IsVendorRole != null && (bool)IsVendorRole)
                        {
                            return RedirectToAction("edit");
                        }
                        else
                        {
                            var result = await _vendorServis.GetPersonForCurrentUserAsync(_lang);
                            return View(_VIEWS["VendorForm"], result?.MapToVendorFormVm());
                        }
                        //<<<<< Case 1-A2 : Already is registered as vendor >>>>>
                    }
                    else
                    {
                        //<<<<< Case 1-B1 : vendor info editing mode  >>>>>
                        if (editMode)
                        {
                            return RedirectToAction("register");
                        }
                        //<<<<< Case 1-B2 : Is not registered as a vendor (active Registeration Form)  >>>>>
                        model = new VendorFormVm();
                    }
                }
                else
                {
                    // When AccessDenied is true will the "Access Denied" message be activated
                    ViewBag.ActivateAccessDeniedForAdmins = true;
                }

            }
            //<<<<< Case 2 :  Anonymous user (active view message) >>>>>
            else
            {
                // When AccessDenied is false will the <<<<"please Login/Signup via SSO">>>> message be activated
                ViewBag.ActivateAccessDeniedForAdmins = false;
            }
            return View(_VIEWS["VendorForm"], model);
        }


        public virtual async Task<IActionResult> Register()
        {
            return await PrepareVendorForm(false);
        }


        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(AuthorizeEFile))]
        public virtual async Task<IActionResult> Register(VendorFormVm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CreatePersonModel _CreateModel = model.MapVendorFormVmToCreatePersonModelWithoutAttachments();
                    var result = await _vendorServis.CreateAsync(_CreateModel);
                    if (result.Success)
                    {
                        TempData["RegisterSuccess"] = model.CompanyName;
                        ModelState.Clear();
                        var _model = new VendorFormVm();
                        return View(_VIEWS["VendorForm"], _model);
                    }
                    else if (result.Messages.Count > 0)
                    {
                        AddModelStateError(result.Messages);
                    }
                }

            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            //  await InitAction(model);
            return View(_VIEWS["VendorForm"], model);
        }
        #endregion

        #region EDIT VENDOR

        [Authorize]
        public virtual async Task<IActionResult> Edit()
        {
            return await PrepareVendorForm(true);
        }

        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(AuthorizeEFile))]
        public virtual async Task<IActionResult> Edit(VendorFormVm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _vendorServis.EditAsync(model.MapToUpdatePersonModel());
                    if (result.Success)
                    {
                        TempData["UpdateSuccess"] = true;
                        var Person = await _vendorServis.GetPersonForCurrentUserAsync(_lang);
                        return View(_VIEWS["VendorForm"], Person?.MapToVendorFormVm());

                    }
                    else if (result.Messages.Count > 0)
                    {
                        AddModelStateError(result.Messages);
                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }


            return View(_VIEWS["VendorForm"], model);
        }

        #endregion

        #region VALDATE VENDOR NAME
        [HttpPost]
        public async virtual Task<JsonResult> ValidateVendorNameIsExist(string name, Guid id, IFormCollection collection)
        {
            try
            {
                var result = await _vendorServis.VerifyVendorSlugUniqueByNameAsync(name, id != Guid.Empty ? id : (Guid?)null);
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

        #region VENDOR INFO


        [Authorize(Policy = ContentSDKPoliciesConstants.Vendor)]
        public virtual async Task<IActionResult> Info()
        {
            try
            {
                var result = await _vendorServis.GetPersonForCurrentUserAsync(_lang);
                return View(_VIEWS["VendorInfo"], result?.MapToVendorFormVm());
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View(_VIEWS["VendorInfo"], new VendorFormVm());
        }

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


        // just for development
        [Authorize(Policy = ContentSDKPoliciesConstants.Vendor)]
        public virtual async Task<IActionResult> Devinfo()
        {
            try
            {
                var result = await _vendorServis.GetPersonForCurrentUserAsync(_lang);
                return View("Devinfo", result?.MapToVendorFormVm());
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View("Devinfo", new VendorFormVm());
        }


    }
}



//public virtual async Task<IActionResult> Register()
//{
//    VendorFormVm model = null;

//    //<<<<< Case 1 :  Not anonymous user >>>>>
//    if (User.Identity.IsAuthenticated)
//    {
//        var roles = HttpContext.User.Identity.GetUserRoles();
//        if (roles != null && roles.All(v => _appSettings.GetVendorRolesName().Contains(v)))
//        {
//            if (await _vendorServis.CheckTheCurrentUserIsRegisteredAsVendorAsync())
//            {
//                //<<<<< Case 1-A : Already is registered as vendor >>>>>
//                return RedirectToAction("edit");
//            }
//            else
//            {
//                //<<<<< Case 1-B : Is not registered as a vendor (active Registeration Form)  >>>>>
//                model = new VendorFormVm();
//            }
//        }
//        else
//        {
//            // When AccessDenied is true will the "Access Denied" message be activated
//            ViewBag.ActivateAccessDeniedForAdmins = true;
//        }

//    }
//    //<<<<< Case 2 :  Anonymous user (active view message) >>>>>
//    else
//    {
//        // When AccessDenied is false will the <<<<"please Login/Signup via SSO">>>> message be activated
//        ViewBag.ActivateAccessDeniedForAdmins = false;
//    }
//    return View(_VIEWS["VendorForm"], model);
//}
