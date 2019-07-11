using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Models.Dtos.Sort;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sectors;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sectors.Models;
using TamTech.Monshaat.POS.Web.Services.Upload;
using TamTech.Monshaat.POS.Web.Services.Upload.Models;
using TamTech.Monshaat.POS.Web.Core.Constants;
using TamTech.Monshaat.POS.Web.Core.Mappers.Sectors;
using TamTech.Monshaat.POS.Web.Models.VMs.Admin.Sectors;
using TamTech.Monshaat.POS.Web.Models.VMs.Shared.Filters;
using TamTech.Monshaat.POS.Web.Core.Telemetry;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;

namespace TamTechSDK.Web.Controllers.Admin
{
    [Authorize(Policy = ContentSDKPoliciesConstants.POSSectorsAdmin)]
    public class SectorsController : AdminBaseController
    {
        private readonly IPOSSectorServices _sectorServices;
        private readonly IStringLocalizer<BaseController> _localizer;
        private readonly IUploadManagerService _uploadManager;

        public SectorsController(
                                    ITelemetryService telemetryClientService,
                                    IStringLocalizer<BaseController> localizer,
                                    IPOSSectorServices sectorServices,
                                    IUploadManagerService uploadManager

            ) : base(telemetryClientService, localizer)
        {
            _sectorServices = sectorServices;
            _uploadManager = uploadManager;
            _localizer = localizer;

        }
         
        private async Task DeleteFilesAsync(string img)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(img))
                {
                    Dictionary<string, FileTypesEnum> deleteInputModel = new Dictionary<string, FileTypesEnum> { { img, FileTypesEnum.SectorMainImage } };
                    IRequestProviderResult< DeleteFilesModelResult> uploadResult = await _uploadManager.DeleteFilesAsync(deleteInputModel);
                    TrackIfNotFilesDeleted(uploadResult.Success, uploadResult.StatusCode, uploadResult.Data, deleteInputModel);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
            }
        }
         
        [HttpGet("{Culture}/[Area]/[Controller]")]
        public virtual async Task<IActionResult> Index(Filter model)
        {
            ViewBag.showReset = new Filter().Equals(model);

            ViewBag.FilterModel = model;
            GetDefaultFiltersList(model, "name");

            SortingModel sorting = CreateSortingModel(model.SortBy);

            DTFilter filters = new DTFilter
            {
                Lang = GetCurrentDataLang(),
                PageSize = model.PageSize,
                PageNumber = model.PageNumber,
                SortBy = sorting.SortBy,
                Descending = sorting.Descending,
                Search = GenrateSearchParams(model)
            };

            try
            {
                var items = await _sectorServices.GetExceptSoftDeletedAsync(filters);
                return View(VerifySucceed(items)  ? items.Data : null);
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            return View();
        }
         
        [HttpGet("{Culture}/[Area]/[Controller]/Preview/{id}")]
        public virtual async Task<IActionResult> Details(int id)
        {
            try
            {
                var result = await _sectorServices.GetByIdExceptSoftDeletedAsync(id, GetCurrentDataLang());
                return View("Details", VerifySucceed(result) ? result.Data : null) ;
                
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View("Details");
        }


        [HttpGet("{Culture}/[Area]/[Controller]/Create")]
        public virtual async Task<ActionResult> Create()
        {
            ViewBag.IsEditMode = false;

            return View("Form", new SectorVM());
        }


        [HttpPost("{Culture}/[Area]/[Controller]/Create")]
        public virtual async Task<IActionResult> Create(SectorVM model, IFormCollection collection)
        {
            bool continueEditing = collection.ContainsKey("save-continue");
            bool newIconUploaded = false;
            bool newImageUploaded = false;
            string oldIcon = model.Icon;
            string oldImage = model.Image;
            try
            {
                if (ModelState.IsValid)
                {


                    if (model.NewIcon != null)
                    {
                        UploadFileInfo fileInfo = await GenerateFileInfo(model.NewIcon);
                        IRequestProviderResult<UploadedFileURL> upload_result = await _uploadManager.UploadFileAsync(fileInfo, FileTypesEnum.SectorIcon);
                        if (upload_result.Success)
                        {
                            model.Icon = upload_result.Data.URL;
                            newIconUploaded = true;
                        }
                        else
                        {
                            AddErrorModel(nameof(model.Icon), _localizer["image_uploading_error"]);
                        }
                    }

                    if (model.NewMainImage != null)
                    {
                        UploadFileInfo _fileInfo = await GenerateFileInfo(model.NewMainImage);
                        IRequestProviderResult<UploadedFileURL> _upload_result = await _uploadManager.UploadFileAsync(_fileInfo, FileTypesEnum.SectorMainImage);
                        if (_upload_result.Success)
                        {
                            model.Image = _upload_result.Data.URL;
                            newImageUploaded = true;
                        }
                        else
                        {
                            AddErrorModel(nameof(model.Icon), _localizer["image_uploading_error"]);
                        }
                    }

                    var result = await _sectorServices.CreateAsync(model.MapToCreateSectorModel());

                    HandelPostingResult(result, _localizer["sector_creation_successfully"]);
                    if (result.Success)
                    {
                        if (continueEditing)
                        {
                            ViewBag.IsEditMode = true;
                            return RedirectToAction("Edit", new { id = result.Data });
                        }

                        if (newIconUploaded)
                        {
                            await DeleteFilesAsync(oldIcon);
                        }
                        if (newImageUploaded)
                        {
                            await DeleteFilesAsync(oldImage);
                        }


                        return RedirectToAction("Index");
                    }
                    else
                    {
                        if (newIconUploaded)
                        {

                            await DeleteFilesAsync(model.Icon);
                            model.Icon = oldIcon;
                        }
                        if (newImageUploaded)
                        {
                            await DeleteFilesAsync(model.Image);
                            model.Image = oldImage;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            ViewBag.IsEditMode = false;
            return View("Form", model);
        }
         
        [HttpGet("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public virtual async Task<ActionResult> Edit(int id)
        {
            ViewBag.IsEditMode = true;

            try
            {
                var result = await _sectorServices.GetByIdExceptSoftDeletedAsync(id, GetCurrentDataLang());
                return View("Form",VerifySucceed(result) ?  result.Data?.MapToSectorVM() : new SectorVM());
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View("Form", new SectorVM());
        }
         
        [HttpPost("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public virtual async Task<IActionResult> Edit(SectorVM model, IFormCollection collection, string lang)
        {
            bool continueEditing = collection.ContainsKey("save-continue");
            try
            {
                if (ModelState.IsValid)
                {
                    model.Lang = GetCurrentDataLang();
                    var oldimg = model.Image;
                    var oldIcon = model.Icon;
                    bool newIconUploaded = false;
                    bool newImageUploaded = false;

                    if (model.NewIcon != null)
                    {
                        UploadFileInfo fileInfo = await GenerateFileInfo(model.NewIcon);
                        IRequestProviderResult<UploadedFileURL> upload_Icon_result = await _uploadManager.UploadFileAsync(fileInfo, FileTypesEnum.SectorIcon);

                        if (upload_Icon_result.Success)
                        {
                            model.Icon = upload_Icon_result.Data.URL;
                            newIconUploaded = true;
                        }
                        else
                        {
                            AddErrorModel(nameof(model.Icon), _localizer["image_uploading_error"]);
                        }
                    }

                    if (model.NewMainImage != null)
                    {
                        UploadFileInfo _fileInfo = await GenerateFileInfo(model.NewMainImage);
                        IRequestProviderResult<UploadedFileURL> upload_Icon_result = await _uploadManager.UploadFileAsync(_fileInfo, FileTypesEnum.SectorMainImage);

                        if (upload_Icon_result.Success)
                        {
                            model.Image = upload_Icon_result.Data.URL;
                            newImageUploaded = true;
                        }

                        else
                        {
                            AddErrorModel(nameof(model.Image), _localizer["image_uploading_error"]);
                        }
                    }

                    var result = await _sectorServices.EditAsync(model.MapToUpdateSectorModel());

                    HandelPostingResult(result, _localizer["sector_creation_successfully"]);

                    if (result.Data)
                    {
                        if (model.NewMainImage != null)
                        {
                            await DeleteFilesAsync(oldimg);
                        }
                        if (model.Icon != null)
                        {
                            await DeleteFilesAsync(oldIcon);
                        }
                        if (continueEditing)
                        {
                            ViewBag.IsEditMode = true;
                            return View("Form", model);
                        }

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        if (newIconUploaded)
                        {
                            await DeleteFilesAsync(model.Icon);
                        }
                        if (newImageUploaded)
                        {
                            await DeleteFilesAsync(model.Image);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }


            ViewBag.IsEditMode = true;
            return View("Form", model);
        }
         
        [HttpGet("{Culture}/[Area]/[Controller]/Delete/{id}")]
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _sectorServices.SoftDeleteAsync(id);
                    return ReturnJsonResult(result, id);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, id);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
                return ReturnJsonErrorResult(ex.Message, id);
            }
        }


        [HttpGet("{Culture}/[Area]/[Controller]/Publish/{id}")]
        public virtual async Task<JsonResult> PublishAsync(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PublishLookupModel data = new PublishLookupModel
                    {
                        Id = id,
                        Lang = GetCurrentDataLang()

                    };

                    var result = await _sectorServices.PublishAsync(data);
                    return ReturnJsonResult(result, id);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, id);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
                return ReturnJsonErrorResult(ex.Message, id);
            }
        }

    }
}
