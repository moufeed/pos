using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TamTechSDK.Web.Services.Telemetry;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Common.Services.Upload.Settings;
using TamTechSDK.Common.Services.ContentService.Galleries;
using TamTechSDK.Common.Services.ContentService.Galleries.Models;
using Microsoft.AspNetCore.Http;
using TamTechSDK.Web.Models.Admin.Galleries;

using TamTechSDK.Web.Extensions.AutoMapper.Galleries;
using TamTechSDK.Web.Services.Configurations.Cultures;
using TamTechSDK.Common.Services.Upload.FileTypes;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Services.Upload.Models;
using TamTechSDK.Web.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using TamTechSDK.Web.Models.Shared.Filters;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Services.ContentService.Galleries.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TamTechSDK.Web.Controllers.Admin
{
    [Area("Admin")]
    [Authorize(Policy = ContentSDKPoliciesConstants.GalleriesContentAdmin)]
    public class GalleriesController : AdminBaseController
    {

        #region Props 
        private IUploadManagerService _uploadManager;
        private IGalleriesService _galeriesService;
        private readonly IStringLocalizer<AdminBaseController> _localizer;
        #endregion

        #region Ctors
        public GalleriesController(
                                    ITelemetryClientService telemetryClientService,
                                    IGalleriesService galeriesService,
                                    IUploadManagerService uploadManager,
                                    IStringLocalizer<AdminBaseController> localizer) : base(telemetryClientService, localizer)
        {
            _uploadManager = uploadManager;
            _galeriesService = galeriesService;
            _localizer = localizer;
        }
        #endregion

        #region Utilities


        private void PrepareCreating()
        {
            ViewBag.FormAction = "Create";
            ViewBag.isUpdate = false;
        }
        private void PrepareEditing()
        {
            ViewBag.FormAction = "Edit";
            ViewBag.isUpdate = true;
        }

        private void CreateItem(Guid id, bool isVideo)
        {

            ViewBag.FormAction = "CreateGaleryItemAsync";
            ViewBag.isUpdate = false;
            ViewBag.GalleryId = id;
            ViewBag.IsVideo = isVideo;
        }
        private void UpdateItem(Guid id, bool isVideo)
        {
            ViewBag.FormAction = "EditGaleryItemAsync";
            ViewBag.isUpdate = true;
            ViewBag.GalleryId = id;
            ViewBag.IsVideo = isVideo;

        }

        private async Task DeleteFilesAsync(string img)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(img))
                {
                    Dictionary<string, FileTypesEnum> deleteInputModel = new Dictionary<string, FileTypesEnum> { { img, FileTypesEnum.GalleryMainImage } };
                    Common.Providers.Requests.Models.IRequestProviderResult<Common.Services.Upload.Models.DeleteFilesModelResult> uploadResult =
                        await _uploadManager.DeleteFilesAsync(deleteInputModel);
                    TrackIfNotFilesDeleted(uploadResult.Success, uploadResult.StatusCode, uploadResult.Data, deleteInputModel);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
            }
        }

        #endregion
        private void sectionList()
        {
            List<SelectListItem> sections = new List<SelectListItem>()
            {
                 new SelectListItem
                { Text = _localizer["section_projects"] , Value = "projects"  },
                  new SelectListItem
                { Text = _localizer["section_works"] , Value = "works"  },
            };
            ViewBag.sectionList = sections;

        }





        #region Actions

        // -- Galleries page --------
        [HttpGet("{Culture}/[Area]/[Controller]/")]
        public async virtual Task<IActionResult> Index(Filter model)
        {
            sectionList();
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

                var result = await _galeriesService.GetAllAsync(pagination, GenrateSearchParams(model), sorting, GetCurrentDataLang());
                if (result.Success)
                {

                    ViewBag.pagination = result.Data.Pagination;
                    return View(result.Data.Data);
                }

                return View();
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            return View(new List<GalleryDto>());
        }

        #region Gallery
        // -- gallery page --------
        [HttpGet("{Culture}/[Area]/[Controller]/Preview/{id}")]
        public async virtual Task<IActionResult> Details(Guid id)
        {

            var result = await _galeriesService.GetByIdAsync(id, GetCurrentDataLang());
            if (result.Success)
            {
                return View("Details", result.Data);
            }


            return View("Details", new GalleryDto());
        }


        #region Create gallery
        [HttpGet("{Culture}/[Area]/[Controller]/Create")]
        public async virtual Task<IActionResult> Create()
        {
            sectionList();
            PrepareCreating();
            return View("FormGallery", new GalleryFormVM());
        }

        [HttpPost("{Culture}/[Area]/[Controller]/Create")]
        public async virtual Task<IActionResult> Create(GalleryFormVM model, IFormCollection collection, string submitButton)
        {
            var _collection = collection;
            var _files = _collection.Files;
            bool continueEditing = collection.ContainsKey("save-continue");
            try
            {
                if (_files.Count > 0)
                {
                    var fileInfo = await GenerateFileInfo(_files[0]);
                    var upload_result = await _uploadManager.UploadFileAsync(fileInfo, FileTypesEnum.GalleryMainImage);
                    if (upload_result.Success)
                    {
                        model.MainImage = upload_result.URL;
                    }
                    else
                    {
                        AddErrorModel(nameof(model.MainImage), _localizer["image_uploading_error"]);
                        PrepareCreating();
                        return View("FormGallery", model);
                    }
                }
                TryValidateModel(model);
                if (ModelState.IsValid)
                {
                    var result = await _galeriesService.CreateAsync(model.MapVmToCreateDto());

                    if (result.Success)
                    {
                        if (continueEditing)
                        {
                            return RedirectToAction("Edit", new { id = result.Data });
                        }
                        return RedirectToAction("Index");

                    }
                    else
                    {


                        if (result.Messages != null)
                        {
                            AddModelStateError(result.Messages);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            PrepareCreating();
            return View("FormGallery", model);
        }

        #endregion

        #region Edit gallery
        [HttpGet("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public async virtual Task<IActionResult> Edit(Guid id)
        {
            sectionList();
            PrepareEditing();

            try
            {
                var result = await _galeriesService.GetByIdAsync(id, GetCurrentDataLang());

                if (result.Success)
                {
                    return View("FormGallery", result.Data.MapGDtoToGVm());
                }
            }
            catch (Exception ex)
            {

                TrackException(ex);
            }
            return View("FormGallery", new GalleryFormVM());

        }


        [HttpPost("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public async virtual Task<IActionResult> Edit(GalleryFormVM model, IFormCollection collection)
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

                    var result = await _galeriesService.EditAsync(model.MapVmToUpdateDto());
                    if (result.Success)
                    {
                        if (_files.Count > 0)
                        {
                            await DeleteFilesAsync(oldImage);
                        }

                        if (continueEditing)
                        {
                            return RedirectToAction("Edit", new { id = model.Id, model.Lang });
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
            PrepareEditing();
            return View("FormGallery", model);

        }
        #endregion

        #region delete publish/unpublish gallery
        [HttpGet("{Culture}/[Area]/[Controller]/Delete/{id}")]
        public virtual async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _galeriesService.DeleteAsync(id);
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

                var result = await _galeriesService.PublishAsync(data);
                return ReturnJsonResult(result, id);

            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
                return ReturnJsonErrorResult(ex.Message, id);
            }
        }

        #endregion

        #endregion


        #region Gallery Item

        #region Create item
        [HttpGet("{Culture}/[Area]/[Controller]/Items/Create/{gid}")]
        public async virtual Task<IActionResult> CreateGaleryItemAsync(Guid gid, bool video)
        {
            CreateItem(gid, video);
            return View("FormGalleryItem", new GalleryItemFormVM());
        }

        [HttpPost("{Culture}/[Area]/[Controller]/Items/Create/{gid}")]
        public async virtual Task<IActionResult> CreateGaleryItemAsync(CreateGalleryItemDto model, IFormCollection collection)
        {
            var _collection = collection;
            var _files = _collection.Files;
            bool continueEditing = collection.ContainsKey("save-continue");
            try
            {
                if (model.GalleryItemType != (int)GalleryItemTypeEnum.YoutubeVideo)
                {
                    model.MainImage = "temp";
                }


                TryValidateModel(model);
                if (ModelState.IsValid)
                {
                    model.MainImage = null;
                    if (_files.Count > 0)
                    {
                        var fileInfo = await GenerateFileInfo(_files[0]);
                        var upload_result = await _uploadManager.UploadFileAsync(fileInfo, FileTypesEnum.GalleryItemImage);
                        if (upload_result.Success)
                        {
                            model.MainImage = upload_result.URL;
                        }
                        else
                        {
                            AddErrorModel(nameof(model.MainImage), _localizer["image_uploading_error"]);
                            CreateItem(model.GalleryId, model.GalleryItemType == (int)GalleryItemTypeEnum.YoutubeVideo);
                            return View("FormGalleryItem", model);
                        }
                    }
                    TryValidateModel(model);
                    if (ModelState.IsValid)
                    {
                        var result = await _galeriesService.CreateGalleryItemAsync(model);
                        HandelPostingResult(result, _localizer["gallery_item_creation_successfully"]);
                        if (result.Success)
                        {
                            if (continueEditing)
                            {
                                return RedirectToAction("EditGaleryItemAsync", new { lang = GetCurrentDataLang(), gid = model.GalleryId, id = result.Data });
                            }

                            return RedirectToAction("Edit", new { id = model.GalleryId });
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            CreateItem(model.GalleryId, model.GalleryItemType == (int)GalleryItemTypeEnum.YoutubeVideo);
            return View("FormGalleryItem", model.MapCreateDtoToVm());
        }


        #endregion

        #region update item
        [HttpGet("{Culture}/[Area]/[Controller]/Items/edit/{gid}/{id}")]
        public async virtual Task<IActionResult> EditGaleryItemAsync(Guid gid, Guid id)
        {


            var model = new GalleryItemKeysDto
            {
                Id = id,
                GalleryId = gid
            };
            var result = await _galeriesService.GetGalleryItemByIdAsync(model, GetCurrentDataLang());
            HandelPostingResult(result, _localizer["gallery_item_updating_successfully"]);
            if (result.Success)
            {
                UpdateItem(gid, result.Data.GalleryItemType == (int)GalleryItemTypeEnum.YoutubeVideo);
                return View("FormGalleryItem", result.Data.MapGiDtoToGiVm());
            }
            return View("FormGalleryItem", new GalleryItemFormVM());
        }


        [HttpPost("{Culture}/[Area]/[Controller]/Items/edit/{gid}/{id}")]
        public async virtual Task<IActionResult> EditGaleryItemAsync(GalleryItemFormVM model, IFormCollection collection, Guid id)
        {
            var _collection = collection;
            var _files = _collection.Files;
            bool continueEditing = collection.ContainsKey("save-continue");
            if (model.GalleryItemType != (int)GalleryItemTypeEnum.YoutubeVideo)
            {
                model.MainImage = model.MainImage ?? "temp";
            }

            TryValidateModel(model);
            if (ModelState.IsValid)
            {
                bool IsImgUploaded = false;
                var oldImage = model.MainImage;
                try
                {
                    if (_files.Count > 0)
                    {
                        var fileInfo = await GenerateFileInfo(_files[0]);
                        var upload_result = await _uploadManager.UploadFileAsync(fileInfo, FileTypesEnum.GalleryItemImage);
                        if (upload_result.Success)
                        {
                            model.MainImage = upload_result.URL;
                            IsImgUploaded = true;
                        }
                        else
                        {
                            AddErrorModel(nameof(model.MainImage), _localizer["image_uploading_error"]);
                            UpdateItem(model.GalleryId, model.GalleryItemType == (int)GalleryItemTypeEnum.YoutubeVideo);
                            return View("FormGalleryItem", model);
                        }
                    }
                    TryValidateModel(model);
                    if (ModelState.IsValid)
                    {
                        var result = await _galeriesService.EditGalleryItemAsync(model.MapGiVmToUpdateGiDto());

                        if (result.Success)
                        {
                            if (_files.Count > 0)
                            {
                                await DeleteFilesAsync(oldImage);
                            }

                            if (continueEditing)
                            {
                                return RedirectToAction("EditGaleryItemAsync", new { lang = GetCurrentDataLang(), gid = model.GalleryId, id = id });

                            }

                            return RedirectToAction("Edit", new { id = model.GalleryId });
                        }
                        else
                        {
                            if (IsImgUploaded)
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
            }

            UpdateItem(model.GalleryId, model.GalleryItemType == (int)GalleryItemTypeEnum.YoutubeVideo);
            return View("FormGalleryItem", model);
        }

        #endregion


        #region delete / publish
        [HttpGet("{Culture}/[Area]/[Controller]/Items/Delete/{GalleryId}/{id}")]
        public virtual async Task<IActionResult> DeletetGaleryItemAsync(GalleryItemKeysDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var result = await _galeriesService.DeleteGalleryItemByIdAsync(dto);
                    return ReturnJsonResult(result, dto);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, dto);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
                return ReturnJsonErrorResult(ex.Message, dto);
            }
        }


        [HttpGet("{Culture}/[Area]/[Controller]/Items/Publish/{GalleryId}/{id}")]
        public virtual async Task<JsonResult> PublishItemAsync(GalleryItemKeysDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    model.Lang = GetCurrentDataLang();

                    var result = await _galeriesService.PublishGalleryItemByIdAsync(model);
                    return ReturnJsonResult(result, model.Id);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, model.Id);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
                return ReturnJsonErrorResult(ex.Message, model.Id);
            }
        }

        #endregion



        [HttpGet("{Culture}/[Area]/[Controller]/Items/publish/all/{gid}")]
        public virtual async Task<JsonResult> PublishGaleryItemsAsync(Guid gid)
        {
            PublishDTO model = new PublishDTO
            {
                Id = gid,
                Lang = GetCurrentDataLang()
            };
            try
            {
                var result = await _galeriesService.PublishGalleryItemsAsync(model);
                return ReturnJsonResult(result, model.Id);
            }
            catch (Exception ex)
            {
                TrackException(ex);
                return ReturnJsonErrorResult(ex.Message, model.Id);
            }

        }


        #endregion

        [HttpPost("{Culture}/[Area]/[Controller]/Items/UploadImages/")]
        public virtual async Task<IActionResult> UploadMUltiapleImage(CreateListGalleryItemsDto model, IFormCollection _collection)
        {
            var _files = _collection.Files;
            List<string> uploadedFiles = new List<string>();

            try
            {
                if (_files.Count > 0)
                {
                    var filesInfo = await GenerateListFilesInfo(_files, FileTypesEnum.GalleryItemImage);
                    var uploadResult = await _uploadManager.UploadListFilesAsync(filesInfo);

                    foreach (UploadedFileURL item in uploadResult.URLs)
                    {
                        if (item.Success)
                        {
                            uploadedFiles.Add(item.URL);
                        }
                    }

                }
                if (uploadedFiles.Count > 0)
                {
                    model.MainImages = uploadedFiles;
                }

                TryValidateModel(model);
                if (ModelState.IsValid)
                {
                    var result = await _galeriesService.CreateListGalleryItemsAsync(model);

                    if (result.Success)
                    {
                        return RedirectToAction("Edit", new { lang = GetCurrentDataLang(), id = model.GalleryId });
                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            TempData["uploadFailed"] = true;
            return RedirectToAction("Edit", new { lang = GetCurrentDataLang(), id = model.GalleryId });
        }
        #endregion
    }
}
