using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Services.ContentService.Sections;
using TamTechSDK.Common.Services.ContentService.Sections.Models;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Web.Constants;
using TamTechSDK.Web.Extensions.AutoMapper.Sections;
using TamTechSDK.Web.Models.Admin.Sections;
using TamTechSDK.Web.Models.Shared.Filters;
using TamTechSDK.Web.Services.Configurations.Cultures;
using TamTechSDK.Web.Services.Telemetry;

namespace TamTechSDK.Web.Controllers.Admin
{
    [Authorize(Policy = ContentSDKPoliciesConstants.PostsContentAdmin)]
    public class SectionsController : AdminBaseController
    {

        #region Props 
        private readonly IUploadManagerService _uploadManager;
        private readonly ISectionsService _sectionsService;
        private readonly IStringLocalizer<AdminBaseController> _localizer;
        #endregion

        #region constructor
        public SectionsController(ITelemetryClientService telemetryClientService,
                                    ISectionsService sectionsService,
                                    IUploadManagerService uploadManager,
                                    IStringLocalizer<AdminBaseController> localizer
                                    ) : base(telemetryClientService, localizer)
        {
            _sectionsService = sectionsService;
            _uploadManager = uploadManager;
            _localizer = localizer;
        }
        #endregion


        #region Utilities

        private async Task<List<SelectListItem>> GetListOFSections()
        {

            var result = await _sectionsService.GetAllAsync(GetCurrentDataLang());

            if (result != null)
            {
                return result.Select(sec =>
                {

                    var item = new SelectListItem
                    {
                        Value = sec.Id.ToString(),
                        Text = sec.Title
                    };

                    return item;
                }).ToList();
            }

            return new List<SelectListItem>();
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

        #endregion

        #region Actions
        [HttpGet("{Culture}/[Area]/[Controller]")]
        public virtual async Task<IActionResult> Index(Filter model)
        {
            ViewBag.showReset = new Filter().Equals(model);
            ViewBag.FilterModel = model;

            ViewBag.selectItems = await GetListOFSections();

            GetDefaultFiltersList(model);


            PaginationModel pagination = new PaginationModel
            {
                PageNumber = model.PageNumber.ToString(),
                PageSize = model.PageSize
            };

            SortingModel sorting = CreateSortingModel(model.SortBy);


            try
            {

                var result = await _sectionsService.GetAllAsync(pagination, GenrateSearchParams(model), sorting, GetCurrentDataLang());
                if (result != null)
                {

                    ViewBag.pagination = result.Data.Pagination;
                    return View(result.Data.Data);
                }

            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View(new List<SectionDto>());
        }


        [HttpGet("{Culture}/[Area]/[Controller]/Create")]
        public virtual async Task<IActionResult> Create()
        {

            var sections = await _sectionsService.GetAllAsync(GetCurrentDataLang());

            ViewBag.selectItems = await GetListOFSections();

            ViewBag.IsEditMode = false;
            return View("Form", new SectionFormVM());
        }


        [HttpPost("{Culture}/[Area]/[Controller]/Create")]
        public virtual async Task<IActionResult> Create(SectionFormVM model, IFormCollection collection)
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
                    var result = await _sectionsService.CreateAsync(model.MapToCreateDto());

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
            ViewBag.selectItems = await GetListOFSections();
            ViewBag.IsEditMode = false;
            return View("Form", model);
        }



        public virtual async Task<JsonResult> CreateSection(SectionFormVM model, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Lang = GetCurrentDataLang();
                    var result = await _sectionsService.CreateAsync(model.MapToCreateDto());
                    HandelPostingResult(result, _localizer["service_creation_successfully"]);
                    if (result.Success)
                    {
                        var Sections = await _sectionsService.GetAllAsync(GetCurrentDataLang());
                        var items = new List<SelectListItem>();

                        if (Sections != null)
                        {
                            items = Sections.Select(sec =>
                            {

                                var item = new SelectListItem
                                {
                                    Value = sec.Id.ToString(),
                                    Text = sec.Title
                                };

                                return item;
                            }).ToList();
                        }
                        return Json(new { success = true, sections = items });
                    }
                    else
                    {
                        AddModelStateError(result.Messages);
                        return ReturnJsonErrorResult(ModelState, model);
                    }
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, model);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return Json(new { success = false });
        }



        [HttpGet("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public virtual async Task<IActionResult> Edit(Guid id)
        {

            try
            {
                ViewBag.selectItems = await GetListOFSections();
                ViewBag.IsEditMode = true;

                var result = await _sectionsService.GetByIdAsync(id, GetCurrentDataLang());

                if (result.Success)
                {
                    return View("Form", result.Data.MapDtoToVM());
                }

            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View("Form", new SectionFormVM());
        }

        [HttpPost("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public virtual async Task<IActionResult> Edit(SectionFormVM model, IFormCollection collection, string lang)
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
                    var result = await _sectionsService.EditAsync(model.MapToUpdateDto());

                    HandelPostingResult(result, _localizer["section_editing_successfully"]);

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

            ViewBag.selectItems = await GetListOFSections();
            ViewBag.IsEditMode = true;
            return View("Form", model);

        }

        [HttpGet("{Culture}/[Area]/[Controller]/Preview/{id}")]
        public virtual async Task<IActionResult> Details(Guid id)
        {
            try
            {
                Common.Providers.Requests.Models.IRequestProviderResult<SectionDto> result = await _sectionsService.GetByIdAsync(id, GetCurrentDataLang());
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
            return View("Details", new SectionDto());
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

                    var result = await _sectionsService.PublishAsync(data);
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

        [HttpGet("{Culture}/[Area]/[Controller]/Delete/{id}")]
        public virtual async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _sectionsService.DeleteAsync(id);
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
