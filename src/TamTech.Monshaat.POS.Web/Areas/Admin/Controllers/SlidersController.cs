using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Sliders;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Sliders.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.Upload;        
using TamTech.Monshaat.POS.Web.SDK.Core.Constants;
using TamTech.Monshaat.POS.Web.SDK.Core.Mappers.Slider;  
using TamTech.Monshaat.POS.Web.SDK.Core.Telemetry;
using TamTech.Monshaat.POS.Web.SDK.Services.Upload.Models;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Admin.Sliders;
using Microsoft.Extensions.Logging;

namespace TamTechSDK.Web.Controllers.Admin
{
  [Authorize(Policy = PolicyConstants.SlidersContentAdmin)]
    public class SlidersController : AdminBaseController
    {
        #region prop
        public IUploadManagerService _uploadManager;
        public ISliderServices _sliderService;
        private readonly IStringLocalizer<BaseController> _localizer;
        #endregion


        #region constructor
        public SlidersController(ITelemetryService telemetryClientService,
            ISliderServices sliderService, 
            IUploadManagerService uploadManager,
              ILogger<SlidersController> logger,
           IStringLocalizer<BaseController> localizer)
            : base(telemetryClientService, logger, localizer)
        {
            _sliderService = sliderService;
            _uploadManager = uploadManager;
            _localizer = localizer;
        }

        #endregion



        #region utilities

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

        private async Task DeleteFilesAsync(string img)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(img))
                {
                    Dictionary<string, FileTypesEnum> deleteInputModel = new Dictionary<string, FileTypesEnum> { { img, FileTypesEnum.SliderItemMainImage } };
                    IRequestProviderResult<DeleteFilesModelResult> uploadResult = await _uploadManager.DeleteFilesAsync(deleteInputModel);
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

        #region { Sliders }  

        #region index View

        [HttpGet("{Culture}/[Area]/[Controller]")]
        public async virtual Task<IActionResult> Index()
        {

            var result = await _sliderService.GetAllAsync(GetCurrentDataLang());

            if (result.Success)
            {

                return View(result.Data);
            }

            return View();
        }

        #endregion

        #region Create Get / Post
        [HttpGet("{Culture}/[Area]/[Controller]/Create")]
        public async virtual Task<IActionResult> CreateSlider()
        {
            PrepareCreating();

            CreateSliderDto Slider = new CreateSliderDto();

            return View("CreateSliderForm", Slider);

        }

        [HttpPost("{Culture}/[Area]/[Controller]/Create")]
        public virtual async Task<IActionResult> Create(CreateSliderDto model, IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool continueEditing = collection.ContainsKey("save-continue");

                    model.Lang = GetCurrentDataLang();

                    var result = await _sliderService.CreateASync(model);

                    HandelPostingResult(result, _localizer["slider_creation_successfully"]);

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
                    TrackException(ex, model);
                }

            }

            PrepareCreating();
            return View("CreateSliderForm", model);
        }


        #endregion

        #region Edit Get / Post
        [HttpGet("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public async virtual Task<IActionResult> Edit(Guid id)
        {
            PrepareEditing();

            try
            {
                var result = await _sliderService.GetByIdAsync(id, GetCurrentDataLang());


                if (result.Success)
                {
                    return View("EditSliderForm", result.Data.MapDtoToUpdateDto());
                }

            }
            catch (Exception ex)
            {
                TrackException(ex, id);

            }

            return View("EditSliderForm", new UpdateSliderDto());
        }



        [HttpPost("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public async virtual Task<IActionResult> Edit(UpdateSliderDto model, IFormCollection collection, string lang)
        {
            try
            {
                bool continueEditing = collection.ContainsKey("save-continue");
                 IRequestProviderResult<bool> result = await _sliderService.UpdateAsync(model);
                HandelPostingResult(result, _localizer["slider_updating_successfully"]);
                if (result.Success)
                {
                    if (continueEditing)
                    {
                        return RedirectToAction("Edit", new { model.Id, lang });
                    }

                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                TrackException(ex, model);
            }
            return View("EditSliderForm", model);
        }

        #endregion

        #region delete / publish slider
        [HttpGet("{Culture}/[Area]/[Controller]/Delete/{id}")]
        public async virtual Task<IActionResult> DeleteAsync(Guid id)
        {

            try
            {
                var result = await _sliderService.DeleteByIdAsync(id);
                return ReturnJsonResult(result, id);
            }
            catch (Exception ex)
            {
                TrackException(ex, id);
                return ReturnJsonErrorResult(ex.Message, id);
            }

        }

        [HttpGet("{Culture}/[Area]/[Controller]/Publish/{id}")]
        public async virtual Task<IActionResult> PublishSliderAsync(Guid id)
        {

            try
            {
                PublishModel data = new PublishModel
                {
                    Id = id,
                    Lang = GetCurrentDataLang()
                };

                var result = await _sliderService.publishByIdAsync(data);

                return ReturnJsonResult(result, id);
            }
            catch (Exception ex)
            {
                TrackException(ex, id);
                return ReturnJsonErrorResult(ex.Message, id);
            }

        }

        #endregion

        #region details

        [HttpGet("{Culture}/[Area]/[Controller]/Preview/{id}")]
        public async virtual Task<IActionResult> details(Guid id)
        {
            SliderDto model = new SliderDto();
            try
            {
                var result = await _sliderService.GetByIdAsync(id, GetCurrentDataLang());
                HandelGetingResult(result);
                if (result.Success)
                {
                    result.Data.Lang = GetCurrentDataLang();
                    return View("Details", result.Data);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex, id);
            }
            return View("Details", model);
        }

        #endregion

        #endregion


        #region { Sliders Items }  


        #region create Slider item Get / Post

        [HttpGet("{Culture}/[Area]/[Controller]/items/Create/{sliderId}")]
        public async virtual Task<IActionResult> CreateItem(Guid sliderId, string sliderTitle)
        {

            ViewBag.SliderId = sliderId;
            ViewBag.SliderTitle = sliderTitle;
            return View("CreateSliderItemForm", new CreateSliderItemVm());
        }


        [HttpPost("{Culture}/[Area]/[Controller]/items/Create/{sliderId}")]
        public async virtual Task<IActionResult> CreateItem(CreateSliderItemVm model, Guid sliderId, string sliderTitle, IFormCollection collection)
        {

            ViewBag.SliderId = sliderId;
            ViewBag.SliderTitle = sliderTitle;

            var _collection = collection;
            var _files = _collection.Files;
            bool continueEditing = collection.ContainsKey("save-continue");
            var oldimg = model.MainImage;
            bool newImageUploaded = false;

            if (ModelState.IsValid)
            {
            try
            {
                if (_files.Count > 0)
                {
                    var fileInfo = await GenerateFileInfo(_files[0]);
                    IRequestProviderResult<UploadedFileURL> upload_result = await _uploadManager.UploadFileAsync(fileInfo, FileTypesEnum.SliderItemMainImage);
                    if (upload_result.Success)
                    {
                        model.MainImage = upload_result.Data.URL;
                        newImageUploaded = true;
                    }
                    else
                    {
                            HandelResult(upload_result);
                       // AddErrorModel(nameof(model.MainImage), _localizer["image_uploading_error"]);
                        PrepareCreating();
                        return View("CreateSliderItemForm", model);
                    }
                }


                var result = await _sliderService.CreateSliderItemASync(model.MapSliderItemDto());

                if (result.Success)
                {
                    if (_files.Count > 0)
                    {
                        await DeleteFilesAsync(oldimg);
                    }

                    if (continueEditing)
                    {
                        return RedirectToAction("EditItem", new { lang = GetCurrentDataLang(), sliderId = sliderId, slideId = result.Data, sliderTitle });

                    }
                    return RedirectToAction("Edit", new { id = sliderId, lang = GetCurrentDataLang() });

                }
                else
                {
                    AddModelStateError(result.Messages);
                    if (newImageUploaded)
                    {
                        await DeleteFilesAsync(model.MainImage);
                    }

                    return View("CreateSliderItemForm", model);
                }

            }
            catch (Exception ex)
            {
                TrackException(ex,model,   sliderId,  sliderTitle);
              
            }

            }
            return View("CreateSliderItemForm", model);
        }



        #endregion


        #region Edit Slider Item Get/ Post

        [HttpGet("{Culture}/[Area]/[Controller]/items/Edit/{sliderId}/{slideId}")]
        public async virtual Task<IActionResult> EditItem(Guid sliderId, Guid slideId, string sliderTitle)
        {

            ViewBag.SliderId = sliderId;
            ViewBag.SliderTitle = sliderTitle;
            try
            {
                var data = new SliderItemKeysDto()
                {
                    SliderId = sliderId,
                    Id = slideId
                };
                var result = await _sliderService.GetSliderItemByIdAsync(data, GetCurrentDataLang());

                if (result.Success)
                {
                    var item = result.Data.MapTOUpdateSliderItemDto();
                    return View("EditSliderItemForm", item);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex, sliderId, slideId, sliderTitle);

            }

            return View("EditSliderItemForm", new UpdateSliderItemDto());
        }

        [HttpPost("{Culture}/[Area]/[Controller]/items/Edit/{sliderId}/{slideId}")]
        public async virtual Task<IActionResult> EditItem(UpdateSliderItemDto model, Guid sliderId, IFormCollection collection)
        {

            ViewBag.SliderId = sliderId;
        

            ModelState.Clear();

            var _collection = collection;
            var _files = _collection.Files;

            if (string.IsNullOrEmpty(model.MainImage) && _files.Count > 0)
            {
                model.MainImage = "/Admin/img/no_image.jpg";

            }
            ViewBag.SliderId = sliderId;

            bool continueEditing = collection.ContainsKey("save-continue");
            var oldimg = model.MainImage;
            bool newImageUploaded = false;
            try
            {
                var ValidateModel = TryValidateModel(model);
                if (ValidateModel)
                {
                    if (_files.Count > 0)
                    {
                        var fileInfo = await GenerateFileInfo(_files[0]);
                        IRequestProviderResult<UploadedFileURL> upload_result = await _uploadManager.UploadFileAsync(fileInfo, FileTypesEnum.SliderItemMainImage);
                        if (upload_result.Success)
                        {
                            model.MainImage = upload_result.Data.URL;
                            newImageUploaded = true;
                        }
                        else
                        {
                            HandelResult(upload_result);
                            PrepareCreating();
                            return View("EditSliderItemForm", model);
                        }
                    }

                    var result = await _sliderService.UpdateSliderItemAsync(model);

                    if (result.Success)
                    {
                        if (_files.Count > 0)
                        {
                            await DeleteFilesAsync(oldimg);
                        }
                        if (continueEditing)
                        {
                            return View("EditSliderItemForm", model);
                        }
                        return RedirectToAction("Edit", new { id = sliderId, lang = GetCurrentDataLang() });
                    }
                    else
                    {
                        if (newImageUploaded)
                        {
                            await DeleteFilesAsync(model.MainImage);
                        }
                        AddModelStateError(result.Messages);
                    }

                }
            }
            catch (Exception ex)
            {
                TrackException(ex, model, sliderId);
            }

            return View("EditSliderItemForm", model);
        }
        #endregion


        #region publish /delete slider Item
        [HttpGet("{Culture}/[Area]/[Controller]/items/Publish/{sliderId}/{id}")]
        public async virtual Task<IActionResult> PublishItem(Guid sliderId, Guid id)
        {
            try
            {
                var data = new SliderItemKeysDto()
                {
                    SliderId = sliderId,
                    Id = id,
                    Lang = GetCurrentDataLang()
                };
                var result = await _sliderService.publishSliderItemByIdAsync(data);
                return ReturnJsonResult(result, id);
            }
            catch (Exception ex)
            {
                TrackException(ex,  sliderId, id);
                return ReturnJsonErrorResult(ex.Message, id);
            }
        }

        [HttpGet("{Culture}/[Area]/[Controller]/items/Delete/{sliderId}/{id}")]
        public async virtual Task<IActionResult> DeleteAsync(Guid sliderId, Guid id)
        {

            try
            {
                var data = new SliderItemKeysDto()
                {
                    SliderId = sliderId,
                    Id = id
                };
                var result = await _sliderService.DeleteSliderItemByIdAsync(data);
                return ReturnJsonResult(result, id);
            }
            catch (Exception ex)
            {
                TrackException(ex, sliderId, id); TrackException(ex);
                return ReturnJsonErrorResult(ex.Message, id);
            }

        }


        #endregion

        #endregion
        #endregion


    }
}
