using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Services.ContentService.Testimonials;
using TamTechSDK.Common.Services.ContentService.Testimonials.Models;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Web.Constants;
using TamTechSDK.Web.Extensions.AutoMapper.Testimonials;
using TamTechSDK.Web.Models.Admin.Testimonials;
using TamTechSDK.Web.Models.Shared.Filters;
using TamTechSDK.Web.Services.Telemetry;

namespace TamTechSDK.Web.Controllers.Admin
{
    [Authorize(Policy = ContentSDKPoliciesConstants.TestimonialsAdmin)]
    public class TestimonialsController : AdminBaseController
    {

        private ITestimonialsServices _testimonialservices;
        private IStringLocalizer<AdminBaseController> _localizer;
        private readonly IUploadManagerService _uploadManager;


        public TestimonialsController(
            ITelemetryClientService telemetryClientService,
            IStringLocalizer<AdminBaseController> localizer,
            ITestimonialsServices testimonialservices,
            IUploadManagerService uploadManager)
            : base(telemetryClientService, localizer)
        {
            _localizer = localizer;
            _testimonialservices = testimonialservices;
            _uploadManager = uploadManager;
        }

        #region uitilties
        private async Task DeleteFilesAsync(string img)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(img))
                {
                    Dictionary<string, FileTypesEnum> deleteInputModel = new Dictionary<string, FileTypesEnum> { { img, FileTypesEnum.General } };
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
                var result = await _testimonialservices.GetAllAsync(pagination, GenrateSearchParams(model), sorting, GetCurrentDataLang());

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
            return View(new List<TestimonialDto>());
        }

        [HttpGet("{Culture}/[Area]/[Controller]/Create")]
        public async virtual Task<IActionResult> Create()
        {
            TestimonialFormVM testimonial = new TestimonialFormVM();
            ViewBag.IsEditMode = false;
            return View("Form", testimonial);
        }

        [HttpPost("{Culture}/[Area]/[Controller]/Create")]
        public virtual async Task<IActionResult> Create(TestimonialFormVM model, IFormCollection collection)
        {
            bool newImageUploaded = false;
            if (ModelState.IsValid)
            {
                try
                {
                    IFormFileCollection _files = collection.Files;
                    var oldimg = model.MainImage;
                    if (_files.Count > 0)
                    {

                        Common.Services.Upload.Models.UploadFileInfo fileInfo = await GenerateFileInfo(_files[0]);
                        Common.Services.Upload.Models.UploadedFileURL upload_result = await _uploadManager.UploadFileAsync(fileInfo, FileTypesEnum.General);

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
                    var result = await _testimonialservices.CreateAsync(model.MapFormVMToCreateDto());

                    if (result.Success)
                    {
                        await DeleteFilesAsync(oldimg);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        if (newImageUploaded)
                        {
                            await DeleteFilesAsync(model.MainImage);
                        }

                        if (result.Messages != null)
                        {
                            AddModelStateError(result.Messages);
                        }
                    }

                }
                catch (Exception ex)
                {
                    TrackException(ex);
                }
            }

            ViewBag.IsEditMode = false;
            return View("Form", model);
        }


        [HttpGet("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public async virtual Task<IActionResult> Edit(Guid id)
        {
            ViewBag.IsEditMode = true;
            try
            {
                var result = await _testimonialservices.GetByIdAsync(id, GetCurrentDataLang());

                if (result.Success)
                {
                    return View("Form", result.Data.MapDtoToGVm());
                }
            }
            catch (Exception ex)
            {

                TrackException(ex);
            }
            return View("Form", new TestimonialFormVM());

        }


        [HttpPost("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public async virtual Task<IActionResult> Edit(TestimonialFormVM model, IFormCollection collection)
        {

            ModelState.Clear();

            bool IsImgUploaded = false;
            var oldImage = model.MainImage;
            var _files = collection.Files;
            bool continueEditing = collection.ContainsKey("save-continue");

            if (string.IsNullOrEmpty(model.MainImage) && _files.Count > 0)
            {
                model.MainImage = "/Admin/img/no_image.jpg";

            }

            var ValidateModel = TryValidateModel(model);
            if (ValidateModel)
            {
                try
                {
                    if (_files.Count > 0)
                    {
                        var fileInfo = await GenerateFileInfo(_files[0]);
                        var upload_result = await _uploadManager.UploadFileAsync(fileInfo, FileTypesEnum.GalleryMainImage);
                        if (upload_result.Success)
                        {
                            IsImgUploaded = true;
                            model.MainImage = upload_result.URL;
                        }
                        else
                        {
                            AddErrorModel(nameof(model.MainImage), _localizer["image_uploading_error"]);
                        }
                    }
                    model.Lang = GetCurrentDataLang();

                    var result = await _testimonialservices.EditAsync(model.MapVmToUpdateDto());
                    if (result.Success)
                    {
                        if (_files.Count > 0)
                        {
                            await DeleteFilesAsync(oldImage);
                        }

                        return RedirectToAction("Index");
                    }
                    else if (IsImgUploaded)
                    {
                        await DeleteFilesAsync(model.MainImage);
                    }
                }
                catch (Exception ex)
                {
                    TrackException(ex);
                }
            }
            ViewBag.IsEditMode = true;
            return View("Form", model);

        }


        #region delete publish/unpublish gallery
        [HttpGet("{Culture}/[Area]/[Controller]/Delete/{id}")]
        public virtual async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _testimonialservices.DeleteAsync(id);
                return ReturnJsonResult(result, id);
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
            try
            {
                PublishDTO data = new PublishDTO
                {
                    Id = id,
                    Lang = GetCurrentDataLang()
                };

                var result = await _testimonialservices.PublishAsync(data);
                return ReturnJsonResult(result, id);

            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
                return ReturnJsonErrorResult(ex.Message, id);
            }
        }

        #endregion


        [HttpGet("{Culture}/[Area]/[Controller]/Preview/{id}")]
        public async virtual Task<IActionResult> Details(Guid id)
        {

            var result = await _testimonialservices.GetByIdAsync(id, GetCurrentDataLang());
            if (result.Success)
            {
                return View("Details", result.Data);
            }


            return View("Details", new TestimonialDto());
        }


    }
}
