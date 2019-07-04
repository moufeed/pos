using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Services.ContentService.Services;
using TamTechSDK.Common.Services.ContentService.Services.Models;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Common.Services.Upload.FileTypes;
using TamTechSDK.Common.Services.Upload.Settings;
using TamTechSDK.Web.Constants;
using TamTechSDK.Web.Extensions.AutoMapper.Services;
using TamTechSDK.Web.Models.Admin.Services;
using TamTechSDK.Web.Services.Configurations.Cultures;
using TamTechSDK.Web.Services.Telemetry;
using TamTechSDK.Web.Extensions;
using System.Globalization;
using TamTechSDK.Web.Models.Shared.Filters;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;

namespace TamTechSDK.Web.Controllers.Admin
{
    [Authorize(Policy = ContentSDKPoliciesConstants.ServicesContentAdmin)]
    public class ServicesController : AdminBaseController
    {



        #region Props 
        private readonly IUploadManagerService _uploadManager;
        private readonly IServicesService _servicesService;
        private readonly IStringLocalizer<AdminBaseController> _localizer;
        #endregion


        #region Ctors
        public ServicesController(ITelemetryClientService telemetryClientService,
            IServicesService servicesService,
            IUploadManagerService uploadManager,
             IStringLocalizer<AdminBaseController> localizer) : base(telemetryClientService, localizer)
        {
            _servicesService = servicesService;
            _uploadManager = uploadManager;
            _localizer = localizer;

        }
        #endregion



        #region Utilities

        private void PrepareCreating()
        {
            //GetLanguages();

            ViewBag.FormAction = "Create";
            ViewBag.isUpdate = false;
        }

        private void PrepareEditing()
        {
            //GetLanguages();

            ViewBag.FormAction = "Edit";
            ViewBag.isUpdate = true;
        }


        private async Task DeleteFilesAsync(string img)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(img))
                {
                    Dictionary<string, FileTypesEnum> deleteInputModel = new Dictionary<string, FileTypesEnum> { { img, FileTypesEnum.ServiceMainImage } };
                    Common.Providers.Requests.Models.IRequestProviderResult<Common.Services.Upload.Models.DeleteFilesModelResult> uploadResult = await _uploadManager.DeleteFilesAsync(deleteInputModel);
                    TrackIfNotFilesDeleted(uploadResult.Success, uploadResult.StatusCode, uploadResult.Data, deleteInputModel);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
            }
        }




        #endregion

        #region Actions
        [HttpGet("{Culture}/[Area]/[Controller]")]
        public virtual async Task<IActionResult> Index(Filter model)
        {

            ViewBag.showReset = new Filter().Equals(model);

            GetDefaultFiltersList(model);

            ViewBag.FilterModel = model;

            PaginationModel pagination = new PaginationModel
            {
                PageNumber = model.PageNumber.ToString(),
                PageSize = model.PageSize
            };

            SortingModel sorting = CreateSortingModel(model.SortBy);
            try
            {

                var result = await _servicesService.GetAllAsync(pagination, GenrateSearchParams(model), sorting, GetCurrentDataLang());

                if (result.Success)
                {
                    ViewBag.pagination = result.Data.Pagination;
                    return View(result.Data.Data);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            return View(new List<ServiceDto>());
        }


        [HttpGet("{Culture}/[Area]/[Controller]/Create")]
        public virtual async Task<IActionResult> Create()
        {
            PrepareCreating();
            return View("Form", new ServiceFormVM());
        }

        [HttpPost("{Culture}/[Area]/[Controller]/Create")]
        public virtual async Task<IActionResult> Create(ServiceFormVM model, IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IFormFileCollection _files = collection.Files;
                    bool continueEditing = collection.ContainsKey("save-continue");

                    if (_files.Count > 0)
                    {
                        Common.Services.Upload.Models.UploadFileInfo fileInfo = await GenerateFileInfo(_files[0]);
                        Common.Services.Upload.Models.UploadedFileURL upload_result = await _uploadManager.UploadFileAsync(fileInfo, FileTypesEnum.ServiceMainImage);

                        if (upload_result.Success)
                        {
                            model.MainImage = upload_result.URL;
                        }
                        else
                        {
                            AddErrorModel(nameof(model.MainImage), _localizer["image_uploading_error"]);
                        }
                    }

                    model.Lang = GetCurrentDataLang();
                    Common.Providers.Requests.Models.IRequestProviderResult<Guid> result = await _servicesService.CreateAsync(model.MapFormVMToCreateDto());

                    HandelPostingResult(result, _localizer["service_creation_successfully"]);

                    if (result.Success)
                    {
                        if (continueEditing)
                        {
                            return RedirectToAction("Edit", new { id = result.Data });
                        }

                        return RedirectToAction("Index");
                    }

                }
                catch (Exception ex)
                {
                    TrackException(ex);
                }

            }

            PrepareCreating();
            return View("Form", model);
        }


        [HttpGet("{Culture}/[Area]/[Controller]/Preview/{id}")]
        public virtual async Task<IActionResult> Details(Guid id)
        {
            try
            {
                Common.Providers.Requests.Models.IRequestProviderResult<ServiceDto> result = await _servicesService.GetByIdAsync(id, GetCurrentDataLang());
                HandelGetingResult(result);
                if (result != null && result.Success && result.Data != null)
                {
                    return View("Details", result.Data);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View("Details", new ServiceDto());
        }


        [HttpGet("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public virtual async Task<IActionResult> Edit(Guid id)
        {

            try
            {
                PrepareEditing();

                Common.Providers.Requests.Models.IRequestProviderResult<ServiceDto> result = await _servicesService.GetByIdAsync(id, GetCurrentDataLang());
                if (result.Success)
                {
                    return View("Form", result.Data.MapDtoToVM());
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View("Form", new ServiceFormVM());
        }

        [HttpPost("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public virtual async Task<IActionResult> Edit(ServiceFormVM model, IFormCollection collection, string lang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldimg = model.MainImage;
                    bool newImageUploaded = false;
                    IFormFileCollection _files = collection.Files;
                    bool continueEditing = collection.ContainsKey("save-continue");

                    if (_files.Count > 0)
                    {
                        Common.Services.Upload.Models.UploadFileInfo fileInfo = await GenerateFileInfo(_files[0]);
                        Common.Services.Upload.Models.UploadedFileURL upload_result = await _uploadManager.UploadFileAsync(fileInfo, FileTypesEnum.ServiceMainImage);

                        if (upload_result.Success)
                        {
                            model.MainImage = upload_result.URL;
                            newImageUploaded = true;
                        }
                        else
                        {
                            AddErrorModel(nameof(model.MainImage), _localizer["image_uploading_error"]);
                        }
                    }

                    model.Lang = GetCurrentDataLang();
                    Common.Providers.Requests.Models.IRequestProviderResult<bool> result = await _servicesService.EditAsync(model.MapFormVMToUpdateDto());

                    HandelPostingResult(result, _localizer["service_creation_successfully"]);

                    if (result.Success)
                    {
                        if (_files.Count > 0)
                        {
                            await DeleteFilesAsync(oldimg);
                        }


                        if (continueEditing)
                        {
                            return RedirectToAction("Edit", new { id = model.Id, lang = lang });
                        }

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        if (newImageUploaded)
                        {
                            await DeleteFilesAsync(model.MainImage);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            PrepareEditing();
            return View("Form", model);

        }

        [HttpGet("{Culture}/[Area]/[Controller]/Delete/{id}")]
        public virtual async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _servicesService.DeleteAsync(id);
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
        public virtual async Task<JsonResult> PublishAsync(Guid id)
        {
            var qs = this.Request.Query[""];
            try
            {
                if (ModelState.IsValid)
                {
                    PublishDTO data = new PublishDTO
                    {
                        Id = id,
                        Lang = GetCurrentDataLang()

                    };

                    var result = await _servicesService.PublishAsync(data);
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

        #endregion
    }
}
