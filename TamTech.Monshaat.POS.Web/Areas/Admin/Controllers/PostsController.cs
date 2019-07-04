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
using TamTechSDK.Common.Helpers.Converters;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Services.ContentService.Posts;
using TamTechSDK.Common.Services.ContentService.Posts.Models;
using TamTechSDK.Common.Services.ContentService.Sections;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Web.Constants;
using TamTechSDK.Web.Extensions;
using TamTechSDK.Web.Extensions.AutoMapper.Posts;
using TamTechSDK.Web.Models.Admin.Posts;
using TamTechSDK.Web.Models.Shared.Filters;
using TamTechSDK.Web.Services.Configurations.Cultures;
using TamTechSDK.Web.Services.Telemetry;

namespace TamTechSDK.Web.Controllers.Admin
{
    [Authorize(Policy = ContentSDKPoliciesConstants.PostsContentAdmin)]
    public class PostsController : AdminBaseController
    {
        #region props
        IPostsService _postservice;
        private readonly IStringLocalizer<AdminBaseController> _localizer;
        private readonly IUploadManagerService _uploadManager;
        private readonly ISectionsService _SectionsService;
        private readonly IStringConverters _stringConverters;
        #endregion

        #region constructor
        public PostsController(
                    ITelemetryClientService telemetryClientService,
                    IPostsService postservice,
                    IStringLocalizer<AdminBaseController> localizer,
                    IUploadManagerService uploadManager,
                    ISectionsService sectionsService,
                    IStringConverters stringConverters) : base(telemetryClientService, localizer)
        {

            _postservice = postservice;
            _localizer = localizer;
            _uploadManager = uploadManager;
            _SectionsService = sectionsService;
            _stringConverters = stringConverters;
        }

        #endregion


        #region utility
        private async Task<List<SelectListItem>> GetListOFSections()
        {

            var result = await _SectionsService.GetAllAsync(GetCurrentDataLang());

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
                    Dictionary<string, FileTypesEnum> deleteInputModel = new Dictionary<string, FileTypesEnum> { { img, FileTypesEnum.PostMainImage } };
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
        public virtual async Task<ActionResult> Index(Filter model)
        {

            ViewBag.showReset = new Filter().Equals(model);

            GetDefaultFiltersList(model);

            ViewBag.FilterModel = model;

            ViewBag.selectItems = await GetListOFSections();

            PaginationModel pagination = new PaginationModel
            {
                PageNumber = model.PageNumber.ToString(),
                PageSize = model.PageSize
            };

            SortingModel sorting = CreateSortingModel(model.SortBy);
            try
            {
                var result = await _postservice.GetAllAsync(pagination, GenrateSearchParams(model), sorting, GetCurrentDataLang());
                // var result = await _pageService.GetAllAsync(pagination, GenrateSearchParams(model), sorting, GetCurrentDataLang());

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

            return View(new List<PostDto>());
        }



        [HttpGet("{Culture}/[Area]/[Controller]/Create")]
        public virtual async Task<ActionResult> Create()
        {
            ViewBag.IsEditMode = false;
            ViewBag.selectItems = await GetListOFSections();
            ViewBag.Roles = HttpContext.User.Identity.GetUserRoles();
            return View("Form", new PostVM());
        }

        [HttpPost("{Culture}/[Area]/[Controller]/Create")]
        public virtual async Task<IActionResult> Create(PostVM model, IFormCollection collection)
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
                    model.Tags = _stringConverters.ToListString(model.TagsString);
                    model.Lang = GetCurrentDataLang();
                    Common.Providers.Requests.Models.IRequestProviderResult<Guid> result = await _postservice.CreateAsync(model.MapFormVMToCreateDto());

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


        [HttpGet("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public virtual async Task<ActionResult> Edit(Guid id)
        {
            ViewBag.IsEditMode = true;
            ViewBag.selectItems = await GetListOFSections();


            try
            {
                var result = await _postservice.GetByIdAsync(id, GetCurrentDataLang());
                if (result.Success)
                {
                    return View("Form", result.Data.MapToPostVM());
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            return View("Form", new PostVM());
        }


        [HttpPost("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public virtual async Task<IActionResult> Edit(PostVM model, IFormCollection collection, string lang)
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
                    model.Tags = _stringConverters.ToListString(model.TagsString);
                    model.Lang = GetCurrentDataLang();
                    Common.Providers.Requests.Models.IRequestProviderResult<bool> result = await _postservice.EditAsync(model.MapFormVMToUpdateDto());

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

            ViewBag.selectItems = await GetListOFSections();
            ViewBag.IsEditMode = true;
            return View("Form", model);

        }



        [HttpGet("{Culture}/[Area]/[Controller]/Delete/{id}")]
        public virtual async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _postservice.DeleteAsync(id);
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

                    var result = await _postservice.PublishAsync(data);
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

        [HttpGet("{Culture}/[Area]/[Controller]/Preview/{id}")]
        public virtual async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var result = await _postservice.GetByIdAsync(id, GetCurrentDataLang());
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
            return View("Details", new PostDto());
        }
        #endregion
    }
}
