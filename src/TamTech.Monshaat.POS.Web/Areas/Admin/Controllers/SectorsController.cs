using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Filter;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Services.PosService.Sectors;
using TamTechSDK.Common.Services.PosService.Sectors.Models;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Common.Services.Upload.Models;
using TamTechSDK.Web.Constants;
using TamTechSDK.Web.Extensions.AutoMapper.Sectors;
using TamTechSDK.Web.Models.Admin.Sectors;
using TamTechSDK.Web.Models.Shared.Filters;
using TamTechSDK.Web.Services.Telemetry;

namespace TamTechSDK.Web.Controllers.Admin
{
    [Authorize(Policy = ContentSDKPoliciesConstants.POSSectorsAdmin)]
    public class SectorsController : AdminBaseController
    {
        private readonly ISectorServices _sectorServices;
        private readonly IStringLocalizer<AdminBaseController> _localizer;
        private readonly IUploadManagerService _uploadManager;

        public SectorsController(
                                    ITelemetryClientService telemetryClientService,
                                    IStringLocalizer<AdminBaseController> localizer,
                                    ISectorServices sectorServices,
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
                    Dictionary<string, FileTypesEnum> deleteInputModel = new Dictionary<string, FileTypesEnum> { { img, FileTypesEnum.SectionMainImage } };
                    Common.Providers.Requests.Models.IRequestProviderResult<Common.Services.Upload.Models.DeleteFilesModelResult> uploadResult = await _uploadManager.DeleteFilesAsync(deleteInputModel);
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
                return View(items);
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            return View(new PagedResultModel<List<SectorDto>>());
        }


        [HttpGet("{Culture}/[Area]/[Controller]/Preview/{id}")]
        public virtual async Task<IActionResult> Details(int id)
        {
            try
            {
                var result = await _sectorServices.GetByIdExceptSoftDeletedAsync(id, GetCurrentDataLang());

                if (result != null)
                {
                    return View("Details", result);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View("Details", new SectorDto());
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
                        UploadedFileURL upload_result = await _uploadManager.UploadFileAsync(fileInfo, FileTypesEnum.SectorIcon);
                        if (upload_result.Success)
                        {
                            model.Icon = upload_result.URL;
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
                        UploadedFileURL _upload_result = await _uploadManager.UploadFileAsync(_fileInfo, FileTypesEnum.SectorMainImage);
                        if (_upload_result.Success)
                        {
                            model.Image = _upload_result.URL;
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

                if (result != null)
                    return View("Form", result.MapToSectorVM());

                ViewBag.EmptyResponse = true;

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
                        UploadedFileURL upload_Icon_result = await _uploadManager.UploadFileAsync(fileInfo, FileTypesEnum.SectorIcon);

                        if (upload_Icon_result.Success)
                        {
                            model.Icon = upload_Icon_result.URL;
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
                        UploadedFileURL upload_Icon_result = await _uploadManager.UploadFileAsync(_fileInfo, FileTypesEnum.SectorMainImage);

                        if (upload_Icon_result.Success)
                        {
                            model.Image = upload_Icon_result.URL;
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
                    return ReturnJson(result, id);
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
            var qs = this.Request.Query[""];
            try
            {
                if (ModelState.IsValid)
                {
                    PublishDTO data = new PublishDTO
                    {
                        IntId = id,
                        Lang = GetCurrentDataLang()

                    };

                    var result = await _sectorServices.PublishAsync(data);
                    return ReturnJson(result, id);
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

