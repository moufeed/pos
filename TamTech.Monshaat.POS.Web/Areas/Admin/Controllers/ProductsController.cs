using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TamTechSDK.Common.Services.ContentService;
using TamTechSDK.Common.Services.ContentService.Brands;
using TamTechSDK.Common.Services.ContentService.Categories;
using TamTechSDK.Common.Services.ContentService.Products;
using TamTechSDK.Common.Services.ContentService.Products.Models;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Common.Services.Upload.Models;
using TamTechSDK.Web.Services.Telemetry;
using TamTechSDK.Web.Extensions.AutoMapper;
using TamTechSDK.Common.Models.Pagination;
using System.Net;
using System.IO;
using TamTechSDK.Common.Services.Upload.Settings;
using TamTechSDK.Web.Models.Admin.Product;
using TamTechSDK.Web.Models.Shared.Products;
using TamTechSDK.Web.Services.Configurations.Cultures;
using TamTechSDK.Common.Services.Upload.FileTypes;
using TamTechSDK.Web.Constants;
using Microsoft.Extensions.Localization;
using TamTechSDK.Web.Models.Shared.Filters;
using TamTechSDK.Common.Models.Sort;

namespace TamTechSDK.Web.Controllers.Admin
{
    [Authorize(Policy = ContentSDKPoliciesConstants.ProductsContentAdmin)]
    public class ProductsController : AdminBaseController
    {
        #region Props 
        private readonly IProductsManagerService _productsManagerService;
        private readonly IBrandsServices _brandsService;
        private readonly ICategoriesServices _categoriesService;
        private readonly IContentServices _contentService;
        private readonly IUploadManagerService _uploadManager;
        private readonly IStringLocalizer<AdminBaseController> _localizer;
        #endregion

        #region Ctors
        public ProductsController(
            ITelemetryClientService telemetryClientService,
            IProductsManagerService productsManagerService,
            IBrandsServices brandsService,
            ICategoriesServices categoriesService,
            IContentServices contentService,
            IUploadManagerService uploadManager,
            IStringLocalizer<AdminBaseController> localizer)
            : base(telemetryClientService, localizer)
        {
            this._productsManagerService = productsManagerService;
            this._brandsService = brandsService;
            this._categoriesService = categoriesService;
            this._contentService = contentService;
            this._uploadManager = uploadManager;
            _localizer = localizer;
        }
        #endregion

        #region Utilities
        private async Task GetCategoriesAsync()
        {
            var result = await _categoriesService.GetAsync(GetCurrentDataLang());
            if (result.Success)
                ViewBag.categories = Mapper.Map<List<SelectListItem>>(result.Data);
            else
                ViewBag.categories = new List<SelectListItem> { };
        }

        private async Task GetBrandsAsync()
        {
            var result = await _brandsService.GetAsync(GetCurrentDataLang());
            if (result.Success)
                ViewBag.Brands = Mapper.Map<List<SelectListItem>>(result.Data);
            else
                ViewBag.Brands = new List<SelectListItem> { };
        }


        //private async Task GetByIdAsync(Guid id)
        //{
        //    var result = await _productsManagerService.GetByIdAsync(id);
        //    if (result.Success)
        //        ViewBag.Brands = Mapper.Map<List<SelectListItem>>(result.Data);
        //    else
        //        ViewBag.Brands = new List<SelectListItem> { };
        //}
        public async Task PrepareCreating()
        {
            ViewBag.index = 0;

            ViewData["FormAction"] = "Create";
            ViewBag.isUpdate = false;
            await GetCategoriesAsync();
            await GetBrandsAsync();
        }

        public async Task PrepareEditing()
        {
            ViewBag.index = 0;

            ViewBag.isUpdate = true;
            ViewData["FormAction"] = "Edit";
            await GetCategoriesAsync();
            await GetBrandsAsync();
        }



        [HttpGet("{Culture}/[Area]/[Controller]/LoadHints")]
        public virtual async Task<JsonResult> LoadHints()
        {

            var result = await _contentService.ProductHints();
            if (result.Success)
            {

                return Json(new { data = result.Data });
            }
            return Json(new { Data = new List<string>() });

        }

        public virtual async Task<ActionResult> LoadProducts(PagingParameterModel model)
        {
            var result = await _productsManagerService.GetAsync(model);
            HandelGetingResult(result);
            if (result.Success)
            {
                var paging = (PaginationMetadataModel)result.Header;
                return Json(new { data = result.Data });
                // return Json(new { draw = draw, recordsFiltered = paging.TotalCount, recordsTotal = paging.TotalCount, data = result.Data });
            }
            return Json(new { data = result });
            //return View(); 
        }

        private async Task DeleteFilesAsync(UploadModelResult model)
        {
            try
            {
                DeleteFilesInputModel dmodel = new DeleteFilesInputModel { DeletedFiles = new List<DeleteFileInputModel>() };
                Dictionary<string, FileTypesEnum> deleteInputModel = new Dictionary<string, FileTypesEnum>();
                foreach (var img in model.URLs)
                {

                    dmodel.DeletedFiles.Add(new DeleteFileInputModel
                    {
                        FilePath = img.URL,
                        Type = img.Type,
                    });
                }
                var uploadResult = await _uploadManager.DeleteFilesAsync(dmodel);
                TrackIfNotFilesDeleted(uploadResult.Success, uploadResult.StatusCode, uploadResult.Data, deleteInputModel);
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
            }
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

        #region Actions

        #region {Product} Get / Create / Edit / Delete

        [HttpGet("{Culture}/[Area]/[Controller]")]
        public virtual async Task<ActionResult> Index(Filter model)
        {
            ViewBag.showReset = new Filter().Equals(model);
            ViewBag.FilterModel = model;
            GetDefaultFiltersList(model);

            PaginationModel pagination = new PaginationModel
            {
                PageNumber = model.PageNumber.ToString(),
                PageSize = model.PageSize
            };

            SortingModel sorting = CreateSortingModel(model.SortBy);


            try
            {
                // var result = await _productsManagerService.GetAllAsync(pagination, GenrateSearchParams(model), sorting, GetCurrentDataLang());

                var result = await _productsManagerService.GetAllAsync(GetCurrentDataLang());
                HandelGetingResult(result);
                if (result.Success)
                {
                    //ViewBag.pagination = result.Data.Pagination;
                    //return View(result.Data.Data.Select(p => p.MapToLiteViewModel()));

                    return View(result.Data.Select(p => p.MapToLiteViewModel()));

                }
            }
            catch (Exception ex)
            {
                TrackException(ex);

            }
            return View(new List<ProductLiteVM>());
        }

        // GET: Products/Create
        [HttpGet("{Culture}/[Area]/[Controller]/Create")]
        public virtual async Task<ActionResult> Create()
        {
            try
            {
                await PrepareCreating();
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }


            return View("Form", new ProductFormVM());
        }


        // Post: Products/Create
        [HttpPost("{Culture}/[Area]/[Controller]/Create")]
        public virtual async Task<ActionResult> Create(ProductFormVM model, IFormCollection collection)
        {
            var _files = collection.Files;
            bool continueEditing = collection.ContainsKey("save-continue");
            UploadModelResult uploadResult = new UploadModelResult();
            try
            {

                if (_files.Count > 0)
                {
                    var filesInfo = await GenerateListFilesInfo(_files,
                                                                new Dictionary<string, FileTypesEnum> { { "MainImage", FileTypesEnum.ProductMainImage } },
                                                                FileTypesEnum.ProductImage);
                    uploadResult = await _uploadManager.UploadListFilesAsync(filesInfo);
                    model.Images = new List<string>();
                    foreach (UploadedFileURL item in uploadResult.URLs)
                    {
                        if (item.Success)
                        {
                            if (item.TypeEnum == FileTypesEnum.ProductMainImage.ToString())
                            {
                                model.MainImageUrl = item.URL;
                            }
                            else
                            {
                                model.Images.Add(item.URL);
                            }
                        }
                        else
                        {
                            AddErrorModel(nameof(model.MainImageUrl), _localizer["image_uploading_error"]);
                            await PrepareCreating();
                            return View("Form", model);
                        }
                    }
                }
                TryValidateModel(model);
                if (ModelState.IsValid)
                {
                    var _model = model.MapFormToDto();
                    _model.Lang = GetCurrentDataLang();
                    var result = await _productsManagerService.CreateAsync(_model);
                    HandelPostingResult(result, _localizer["product_ceation_successfully"]);
                    if (result.Success)
                    {
                        if (continueEditing)
                        {
                            return RedirectToAction("Edit", new { id = result.Data });
                        }
                        return RedirectToAction("Index");
                    }

                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            await DeleteFilesAsync(uploadResult);
            await PrepareCreating();
            return View("Form", model);
        }



        // GET: Products/Edit/5
        [HttpGet("{culture}/[Area]/[controller]/Edit/{id}")]
        public virtual async Task<ActionResult> Edit(Guid id)
        {
            try
            {
                await PrepareEditing();
                var result = await _productsManagerService.GetByIdAsync(id, GetCurrentDataLang());
                if (result.Success)
                {
                    var product = result.Data.MapFormToFormViewModel();
                    return View("Form", product);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View("Form", new ProductFormVM());
        }






        // Post: Products/Edit/5
        [HttpPost]
        public virtual async Task<ActionResult> Edit(ProductFormVM model, IFormCollection collection)
        {
            UploadModelResult uploadResult = new UploadModelResult();
            try
            {
                TryValidateModel(model);
                if (ModelState.IsValid)
                {
                    bool IsImgUploaded = false;
                    var oldImage = model.MainImageUrl;
                    var _files = collection.Files;
                    bool continueEditing = collection.ContainsKey("save-continue");
                    if (_files.Count > 0)
                    {
                        var filesInfo = await GenerateListFilesInfo(_files,
                                                                    new Dictionary<string, FileTypesEnum> { { "MainImage", FileTypesEnum.GalleryMainImage } },
                                                                    FileTypesEnum.ProductImage);
                        uploadResult = await _uploadManager.UploadListFilesAsync(filesInfo);

                        foreach (UploadedFileURL item in uploadResult.URLs)
                        {
                            if (item.Success)
                            {
                                if (model.Images == null)
                                {
                                    model.Images = new List<string>();
                                }

                                if (item.TypeEnum == FileTypesEnum.ProductMainImage.ToString())
                                {
                                    model.MainImageUrl = item.URL;
                                    IsImgUploaded = true;
                                }
                                else
                                {
                                    model.Images.Add(item.URL);
                                }
                            }
                            else
                            {
                                AddErrorModel(nameof(model.MainImageUrl), _localizer["image_uploading_error"]);
                                await PrepareCreating();
                                return View("Form", model);
                            }
                        }
                    }

                    var _model = model.MapFormToDto();
                    _model.Lang = GetCurrentDataLang();
                    var result = await _productsManagerService.EditAsync(_model);
                    HandelPostingResult(result, _localizer["product_updating_successfully"]);
                    if (result.Success)
                    {
                        if (continueEditing)
                        {
                            return RedirectToAction("Edit", new { id = model.Id });
                        }
                        return RedirectToAction("Index");
                    }
                    else if (IsImgUploaded)
                    {
                        await DeleteFilesAsync(model.MainImageUrl);
                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            await DeleteFilesAsync(uploadResult);
            await PrepareEditing();
            return View("Form", model);

        }



        [HttpGet("{culture}/[Area]/[controller]/Publish/{id}")]
        public virtual async Task<JsonResult> PublishAsync(PublishDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Lang = GetCurrentDataLang();
                    var result = await _productsManagerService.PublishAsync(model);
                    return ReturnJsonResult(result, model);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, model);
                }

            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
                return ReturnJsonErrorResult(_localizer["exception_msg"], model);
            }
        }


        [HttpGet("{culture}/[Area]/[controller]/Delete/{id}")]
        public virtual async Task<JsonResult> DeleteAsync(Guid id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _productsManagerService.DeleteAsync(id);
                    HandelGetingResult(result);
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
                return ReturnJsonErrorResult(_localizer["exception_msg"], id);
            }

        }

        #endregion 


        #region {Product Combination} Get / Create / Edit / Delete 

        [HttpGet("{culture}/[Area]/[Controller]/Combinations/Get/{productId}")]
        public virtual async Task<JsonResult> GetProductCombinationsAsync(Guid productId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _productsManagerService.GetProductCombinationsAsync(productId, GetCurrentDataLang());
                    HandelGetingResult(result);
                    return ReturnJsonResult(result, productId);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, productId);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
                return ReturnJsonErrorResult(_localizer["exception_msg"], productId);
            }
        }

        //Action Return : json
        [HttpPost("{culture}/[Area]/[Controller]/Combinations/Create")]
        public virtual async Task<JsonResult> CreateProductCombinationAsync(ProductCombinationFormVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _model = model.MapFormToFormDto();
                    _model.Lang = GetCurrentDataLang();
                    var result = await _productsManagerService.CreateProductCombinationAsync(_model);
                    HandelPostingResult(result, _localizer["combination_creation_successfully"]);
                    model.CombinationKey = result.Data?.Key;
                    model.Sku = result.Data?.Sku;
                    return ReturnJsonResult(result, model);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, model);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
                return ReturnJsonErrorResult(_localizer["exception_msg"], model);
            }

        }


        [HttpGet("{culture}/[Area]/[controller]/Combinations/Publish")]
        public virtual async Task<JsonResult> PublishProductCombinationAsync(ProductCombinationKeys model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Lang = GetCurrentDataLang();
                    var result = await _productsManagerService.PublishProductCombinationAsync(model);
                    HandelGetingResult(result);
                    return ReturnJsonResult(result, model);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, model);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
                return ReturnJsonErrorResult(_localizer["exception_msg"], model);
            }

        }


        [HttpGet("{culture}/[Area]/[controller]/Combinations/Delete")]
        public virtual async Task<JsonResult> DeleteProductCombinationAsync(ProductCombinationKeys model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Lang = GetCurrentDataLang();
                    var result = await _productsManagerService.DeleteProductCombinationAsync(model);
                    HandelGetingResult(result);
                    return ReturnJsonResult(result, model);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, model);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
                return ReturnJsonErrorResult(_localizer["exception_msg"], model);
            }

        }


        #endregion


        #region {Product Attribute} Get / Create / Edit / Delete

        [HttpGet("{culture}/[Area]/[Controller]/Attributes/Get/{productId}")]
        public virtual async Task<JsonResult> GetProductAttributesAsync(Guid productId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _productsManagerService.GetProductAttributesAsync(productId, GetCurrentDataLang());
                    HandelGetingResult(result);
                    return ReturnJsonResult(result, productId);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, productId);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
                return ReturnJsonErrorResult(_localizer["exception_msg"], productId);
            }

        }


        //Action Return : json
        [HttpPost("{culture}/[Area]/[Controller]/Attributes/Create")]
        public virtual async Task<JsonResult> CreateProductAttributeAsync(ProductAttributeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _model = model.MapToFormDto();
                    _model.Lang = GetCurrentDataLang();
                    var result = await _productsManagerService.CreateProductAttributeAsync(_model);
                    return ReturnJsonResult(result, model);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, model);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
                return ReturnJsonErrorResult(_localizer["exception_msg"], model);
            }
        }


        //Action Return : json 
        [HttpPost("{culture}/[Area]/[Controller]/Attributes/Edit")]
        public virtual async Task<JsonResult> EditProductAttributeAsync(ProductAttributeEditing model)
        {
            try
            {
                model.Lang = GetCurrentDataLang();
                if (ModelState.IsValid)
                {

                    var result = await _productsManagerService.EditProductAttributeAndGetCompinationsAsync(model);
                    return ReturnJsonResult(result, model);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, model);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
                return ReturnJsonErrorResult(_localizer["exception_msg"], model);
            }



        }



        [HttpGet("{culture}/[Area]/[controller]/Attributes/Delete")]
        public virtual async Task<JsonResult> DeleteProductAttributeAsync(ProductAttributeKeys model)
        {
            try
            {
                model.Lang = GetCurrentDataLang();
                if (ModelState.IsValid)
                {

                    var result = await _productsManagerService.DeleteProductAttributeAsync(model);
                    HandelGetingResult(result);
                    return ReturnJsonResult(result, model);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, model);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
                return ReturnJsonErrorResult(_localizer["exception_msg"], model);
            }
        }
        #endregion


        #region {Product Attribute Value} Get / Create / Edit / Delete


        //Action Return : json
        [HttpPost("{culture}/[Area]/[Controller]/Attributes/Values/Create")]
        public virtual async Task<JsonResult> CreateProductAttributeValueAsync(ProductAttributeValueForm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Lang = GetCurrentDataLang();
                    var result = await _productsManagerService.CreateProductAttributeValueAsync(model);
                    HandelPostingResult(result, _localizer["attribute_value_creation_successfully"]);
                    return ReturnJsonResult(result, model);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, model);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
                return ReturnJsonErrorResult(_localizer["exception_msg"], model);
            }
        }



        //Action Return : json
        [HttpPost("{culture}/[Area]/[Controller]/Attributes/Values/Edit")]
        public virtual async Task<JsonResult> EditProductAttributeValueAsync(ProductAttributeValueEditing model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Lang = GetCurrentDataLang();
                    var result = await _productsManagerService.EditProductAttributeValueAndGetCompinationsAsync(model);
                    HandelPostingResult(result, _localizer["attribute_value_updating_successfully"]);
                    return ReturnJsonResult(result, model);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, model);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
                return ReturnJsonErrorResult(_localizer["exception_msg"], model);
            }


        }



        [HttpGet("{culture}/[Area]/[controller]/Attributes/Values/Delete")]
        public virtual async Task<JsonResult> DeleteProductAttributeValueAsync(ProductAttributeValueKeys model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Lang = GetCurrentDataLang();
                    var result = await _productsManagerService.DeleteProductAttributeValueAsync(model);
                    HandelGetingResult(result);
                    return ReturnJsonResult(result, model);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, model);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
                return ReturnJsonErrorResult(_localizer["exception_msg"], model);
            }
        }
        #endregion


        #region {Product Images}  Delete
        [HttpPost("{culture}/[Area]/[controller]/Images/Delete")]
        public virtual async Task<JsonResult> DeleteProductImagesAsync(ProductImagesModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Lang = GetCurrentDataLang();
                    var Result = await _productsManagerService.DeleteProductImagesValueAsync(model);
                    if (Result.Success)
                    {
                        // TODO :get  fileTypesSettings  >>>> var deleteModel = model.MapToDeleteFilesInputModel(_fileTypesSettings.ProductImage);
                        var deleteModel = model.MapToDeleteFilesInputModel(FileTypesEnum.ProductImage.ToString());
                        var uploadResult = await _uploadManager.DeleteFilesAsync(deleteModel);
                        TrackIfNotFilesDeleted(uploadResult.Success, uploadResult.StatusCode, uploadResult.Data, deleteModel);
                    }
                    HandelGetingResult(Result);
                    return ReturnJsonResult(Result, model);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, model);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
                return ReturnJsonErrorResult(_localizer["exception_msg"], model);
            }
        }
        #endregion






















        //// GET: Products/Details/5
        //public virtual ActionResult Details(int id)
        //{
        //    return View();
        //}


        //// POST: Products/Edit/5
        ////IFormCollection
        ///*  [HttpPost]
        //  [ValidateAntiForgeryToken]

        //  public async Task<ActionResult> Edit(int id, ProductView model, IFormCollection collection)
        //  {
        //      //var accessToken = await HttpContext.GetTokenAsync("access_token");
        //      var accessToken =  "eyJhbGciOiJSUzI1NiIsImtpZCI6ImM3NTA0YWY3YzhiMzZjOWI2NzIzMTlmMWNmYzAzZTQ1IiwidHlwIjoiSldUIn0.eyJuYmYiOjE1MjgxMTM5NDIsImV4cCI6MTUzMDcwNTk0MiwiaXNzIjoiaHR0cHM6Ly93aGF0Y29vay1kZXYtaWRlbnRpdHkuYXp1cmV3ZWJzaXRlcy5uZXQiLCJhdWQiOlsiaHR0cHM6Ly93aGF0Y29vay1kZXYtaWRlbnRpdHkuYXp1cmV3ZWJzaXRlcy5uZXQvcmVzb3VyY2VzIiwid2hhdGNvb2sucmVhbHRpbWUiLCJ3aGF0Y29vay5hcGkiLCJpZGVudGl0eS5hcGkiLCJ3aGF0Y29vay51cGxvYWQiLCJ3aGF0Y29vay5hZG1pbnBhbmVsIl0sImNsaWVudF9pZCI6IndoYXRjb29rYXBwIiwic3ViIjoiMDYwYmU5YjMtMjE4NS00YmZjLTg1ZDMtMjUyZTliZDQ5YzE1IiwiYXV0aF90aW1lIjoxNTI4MTEzOTM3LCJpZHAiOiJsb2NhbCIsIkFzcE5ldC5JZGVudGl0eS5TZWN1cml0eVN0YW1wIjoiMWI0MjgxZjEtMjNkNi00NmUxLWE3ODYtODc2ZDU3MDIwMmJlIiwicm9sZSI6IldoYXRjb29rVXNlciIsInByZWZlcnJlZF91c2VybmFtZSI6InRlc3QyIiwibmFtZSI6InRlc3QyIiwiZW1haWwiOiJ0ZXN0MkB0ZXN0Mi5jb20iLCJlbWFpbF92ZXJpZmllZCI6ZmFsc2UsInBob25lX251bWJlciI6Iis5NjYwMDAwMDAwMDAyIiwicGhvbmVfbnVtYmVyX3ZlcmlmaWVkIjpmYWxzZSwic2NvcGUiOlsib3BlbmlkIiwicHJvZmlsZSIsIndoYXRjb29rLnJlYWx0aW1lIiwid2hhdGNvb2suYXBpIiwiaWRlbnRpdHkuYXBpIiwid2hhdGNvb2sudXBsb2FkIiwid2hhdGNvb2suYWRtaW5wYW5lbCIsIm9mZmxpbmVfYWNjZXNzIl0sImFtciI6WyJwd2QiXX0.gUNpzj14kKAPL-lamwAjCCUdoKmKQuYP0SiXEinaEmFK82mt3fBv8NWYUcO0qamUQtWAhFL3ldbP1SzYLQ4ReWF0FVUIEs-nFaYLAzk97w0Sx0R26O3UOUj06Ld33ZCfPpjS6QAm6_GoKYaBogVVw_3B2zRjkL0HVp8U643SNb6RNKSEFJ3X7LvMIgVduhZsFFE8k3G5LUg8vAy2jbIAM_0ei-kvWb6vj-HZkSdJ50RVKByN6vtxV_xvkBLt4n28RbV-T4EVOQVmASXBtoU3uhTKuM70qETLrI18iBFWb-4H9lN31uPx-_YNflgRcu6AhMe5N--wob6t1iMCKvIWYA";

        //      UploadModel files = new UploadModel();
        //      files.UploadedFiles = new List<UploadFileModel>();
        //      var _files = collection.Files;
        //      if (_files.Count > 0) {
        //          foreach (var _file in _files)
        //          {
        //              files.UploadedFiles.Add(
        //              new UploadFileModel {
        //                  FileBinary = _file,
        //                  FileType = (_file.Name == "ThumbnailUrl") ? "product-image-main" : "product-image"
        //              });
        //          }
        //          var result = await _uploadService.UploadsFilesAsync(files , accessToken);

        //          if (result.Success) {

        //              var data = result.Data;
        //          }

        //      }

        //     // 
        //      try
        //      {






        //          // TODO: Add update logic here

        //          return Json(new { data = model });
        //          // return RedirectToAction(nameof(Index));
        //      }
        //      catch
        //      {
        //          return View();
        //      }
        //  }
        //  */

        //[HttpPost]
        //public virtual JsonResult UploadImages(List<IFormFile> Files)
        //{


        //    return Json(new { });
        //}

        //// GET: Products/Delete/5
        //public virtual async Task<JsonResult> Delete(Guid id)
        //{

        //    try
        //    {
        //        var result = await _productsManagerService.DeleteAsync(id);
        //        return Json(result);
        //    }
        //    catch (Exception)
        //    {
        //        return Json(new
        //        {
        //            Success = false,
        //            Messages = new Dictionary<string, string> {
        //                                      { _localizer["error"], _localizer["something_wrong"] }
        //                                }
        //        });
        //    }

        //    return Json(new
        //    {
        //        Success = false,
        //        Messages = new Dictionary<string, string> {
        //                                     { _localizer["error"], _localizer["something_wrong"] }
        //                                }
        //    });

        //}

        //// POST: Products/Delete/5 IFormCollection collection
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public virtual ActionResult Delete(object id)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //[HttpPost]
        //public virtual async Task<JsonResult> DeleteImages(ProductImagesModel model)
        //{

        //    var result = await _productsManagerService.DeleteProductImagesValueAsync(model);

        //    if (result.Success)
        //    {
        //        return Json(new { data = model });
        //    }

        //    return Json(new { });
        //}
        #endregion 
    }
}


//private async Task<ProductFormVM> (ProductFormVM model, IFormFileCollection _files)
//{

//    if (_files.Count > 0)
//    {
//        UploadModel UploadModel = new UploadModel
//        {
//            UploadFile = new List<UploadFileInfo>()
//        };
//        foreach (var _file in _files)
//        {
//            MemoryStream stream = new MemoryStream();
//            await _file.CopyToAsync(stream);
//            stream.Position = 0;
//            UploadModel.UploadFile.Add(new UploadFileInfo
//            {
//                Stream = stream,
//                FileNamePrefix = $"product_{model.Id} _",
//                type = (_file.Name == "MainImage") ? "avatars" : "avatars",  //  TODO: change type of file
//                FileName = _file.FileName
//            });
//        }
//        try
//        {
//            var uploadResult = await _uploadService.UploadsFilesAsync(UploadModel);

//            if (uploadResult.Success)
//            {
//                foreach (var image in uploadResult.Data.URLs)
//                {
//                    if (image.Type == "mainimage") //  TODO: change type of file
//                    {
//                        model.MainImageUrl = image.URL;
//                    }
//                    else
//                    {
//                        model.Images.Add(image.URL);
//                    }
//                }
//            }
//        }
//        catch (Exception exc)
//        {
//            TrackException(exc);
//        }
//    }
//    return model;
//}
