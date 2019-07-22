using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TamTech.Monshaat.POS.Web.SDK.Core.Mappers;
using TamTech.Monshaat.POS.Web.SDK.Core.Telemetry;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Pages;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Pages.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Pages.Enums;
using TamTech.Monshaat.POS.Web.SDK.Core.Helpers.Converters;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Admin.Page;
using TamTech.Monshaat.POS.Web.SDK.Services.Upload;
using Microsoft.AspNetCore.Mvc.Rendering;        
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Common;
using Microsoft.AspNetCore.Authorization;
using TamTech.Monshaat.POS.Web.SDK.Core.Constants;
using Microsoft.Extensions.Localization;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Shared.Filters;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Sort;
using TamTech.Monshaat.POS.Web.SDK.Services.Upload.Models;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Filter;

namespace TamTechSDK.Web.Controllers.Admin
{   
 [Authorize(Policy = PolicyConstants.PagesContentAdmin)]
    public class PagesController : AdminBaseController
    {
        #region Props 
        IPageService _pageService;
        IStringConverters _stringConverters;
        IUploadManagerService _uploadManager;
        private readonly IStringLocalizer<BaseController> _localizer;
        #endregion


        #region Ctors
        public PagesController(ITelemetryService telemetryClientService,
                              IPageService pageService,
                              IUploadManagerService uploadManager,
                              IStringConverters stringConverters,
                               IStringLocalizer<BaseController> localizer)
                             : base(telemetryClientService, localizer)
        {
            this._pageService = pageService;
            this._stringConverters = stringConverters;
            this._uploadManager = uploadManager;
            _localizer = localizer;

            ViewBag.Author_Name_Enabled = false;
        }
        #endregion


        #region utility
        private void GetTypeList(Filter model)
        {
            List<SelectListItem> TypeList = new List<SelectListItem>()
            {
                 new SelectListItem
                {
                    Text = "Html",
                    Value = "1",
                    Selected = model.Type == 1
                },
                  new SelectListItem
                {
                    Text = "Sections",
                    Value = "2",
                    Selected = model.Type == 2
                },
            };

            ViewBag.TypeList = TypeList;


        }
        private void sectionList()
        {
            #region sectionList
            List<SelectListItem> sections = new List<SelectListItem>()
            {
                 new SelectListItem
                { Text = _localizer["home_page_section"] , Value = "home"  },
                  new SelectListItem
                { Text = _localizer["other_section"] , Value = "other"  },
            };
            ViewBag.sectionList = sections;
            #endregion
        }

        private async Task DeleteFilesAsync(string img)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(img))
                {
                    Dictionary<string, FileTypesEnum> deleteInputModel = new Dictionary<string, FileTypesEnum> { { img, FileTypesEnum.PageMainImage } };
                     IRequestProviderResult< DeleteFilesModelResult> uploadResult = await _uploadManager.DeleteFilesAsync(deleteInputModel);
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

        #region {Shared Page}

        // GET: Pages
        [HttpGet("{Culture}/[Area]/[Controller]")]
        public virtual async Task<ActionResult> Index(Filter model)
        {
            ViewBag.showReset = new Filter().Equals(model);
            ViewBag.FilterModel = model;

            GetDefaultFiltersList(model);
            GetTypeList(model);

            PaginationModel pagination = new PaginationModel
            {
                PageNumber = model.PageNumber.ToString(),
                PageSize = model.PageSize
            };

            SortingModel sorting = CreateSortingModel(model.SortBy);
           
            DTFilter _filters = new DTFilter
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
                // CheckSuccessModel(); 

                var result = await _pageService.GetAllAsync(_filters);

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

            return View();
        }

        [HttpGet("{Culture}/[Area]/[Controller]/Delete/{type}/{id}")]
        public virtual async Task<JsonResult> Delete(string type, Guid id)
        {
            try
            {
                if (string.IsNullOrEmpty(type))
                {
                    ModelState.AddModelError(_localizer["c_type"], _localizer["parameter_required", _localizer["c_type"]]);
                }
                if (id == null || id == Guid.Empty)
                {
                    ModelState.AddModelError(_localizer["c_id"], _localizer["parameter_required", _localizer["c_id"]]);
                }
                if (ModelState.IsValid)
                {
                    if (PageTypeEnum.Html.ToString().ToLower() == type.ToLower())
                    {
                        var result = (await _pageService.DeleteHtmlPageAsync(id));
                        return ReturnJsonResult(result, id);
                    }

                    if (PageTypeEnum.Sections.ToString().ToLower() == type.ToLower())
                    {
                        var result = (await _pageService.DeleteSectionsPageAsync(id));
                        return ReturnJsonResult(result, id);
                    }
                }

            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
                return ReturnJsonErrorResult(ex.Message, id);
            }

            return Json(ModelState.Values);

        }



        [HttpGet("{Culture}/[Area]/[Controller]/Publish/{type}/{id}")]
        public virtual async Task<JsonResult> Publish(string type, Guid id)
        {
            try
            {
                if (string.IsNullOrEmpty(type))
                {
                    ModelState.AddModelError(_localizer["c_type"], _localizer["parameter_required", _localizer["c_type"]]);
                }
                if (id == null || id == Guid.Empty)
                {
                    ModelState.AddModelError(_localizer["c_id"], _localizer["parameter_required", _localizer["c_id"]]);
                }
                if (ModelState.IsValid)
                {
                    PublishModel data = new PublishModel
                    {
                        Id = id,
                        Lang = GetCurrentDataLang()
                    };

                    if (PageTypeEnum.Html.ToString().ToLower() == type.ToLower())
                    {
                        var result = (await _pageService.PublishHtmlPageAsync(data));
                        return ReturnJsonResult(result, data.Id);
                        // return Json(result);
                    }

                    if (PageTypeEnum.Sections.ToString().ToLower() == type.ToLower())
                    {
                        var result = (await _pageService.PublishSectionsPageAsync(data));
                        return ReturnJsonResult(result, data.Id);
                        // return Json(result);
                    }
                }

            }
            catch (Exception ex)
            {
                TrackException(ex);
                return ReturnJsonErrorResult(ex.Message, id);
                //return Json(new
                //{
                //    Success = false,
                //    Messages = new Dictionary<string, string> {
                //                            { "Error", "Something wrong" }
                //                        }
                //});
            }

            return ReturnJsonErrorResult(ModelState, id);
        }


        #endregion


        #region {Html Page}

        [HttpGet("{Culture}/[Area]/[Controller]/html/{id}")]
        public virtual async Task<ActionResult> GetHtmlDetailsAsync(Guid id)
        {
            try
            {
                //GetLanguages();
                var result = await _pageService.GetHtmlPageByIdAsync(id, GetCurrentDataLang());
                HandelGetingResult(result);
                if (result != null && result.Success && result.Data != null)
                {
                    return View("HtmlPageDetails", result.Data);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View("HtmlPageDetails", new HtmlPage());

        }


        [HttpGet("{Culture}/[Area]/[Controller]/Create/html")]
        public virtual ActionResult CreateHtmlPage()
        {
            sectionList();
            return View();
        }


        [HttpPost("{Culture}/[Area]/[Controller]/Create/html")]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> CreateHtmlPage(HtmlPageCreationVM model, IFormCollection collection)
        {
            sectionList();

            //  _getSections();
            // GetLanguages();
            var _collection = collection;
            var _files = _collection.Files;
            bool continueEditing = collection.ContainsKey("save-continue");

            bool newImageUploaded = false;
            try
            {

                if (ModelState.IsValid)
                {
                    var oldimg = model.MainImage;
                    if (_files.Count > 0)
                    {
                        var fileInfo = await GenerateFileInfo(_files[0]);
                        IRequestProviderResult<UploadedFileURL> upload_result = await _uploadManager.UploadFileAsync(fileInfo, FileTypesEnum.PageMainImage);

                        if (upload_result.Success)
                        {
                            model.MainImage = upload_result.Data.URL;
                            newImageUploaded = true;
                        }
                    }
                    model.KeywordsList = _stringConverters.ToListString(model.Keywords);
                    model.Lang = GetCurrentDataLang();

                    var result = await _pageService.CreateHtmlPageAsync(model.MapToDto());
                    HandelPostingResult(result, _localizer["html_page_creation_successfully"]);
                    if (result.Success)
                    {
                        await DeleteFilesAsync(oldimg);
                        if (continueEditing)
                        {
                            return RedirectToAction("EditHtmlPage", new { id = result.Data, model.Lang });
                        }
                        return RedirectToAction("Index");
                    }
                    else if (newImageUploaded)
                    {
                        await DeleteFilesAsync(model.MainImage);
                    }

                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View(model);
        }



        [HttpGet("{Culture}/[Area]/[Controller]/edit/html/{id}")]
        public virtual async Task<ActionResult> EditHtmlPage(Guid id)
        {
            sectionList();
            try
            {

                var result = await _pageService.GetHtmlPageByIdAsync(id, GetCurrentDataLang());
                if (result != null)
                {
                    return View(result.Data.MapToEditingVM());
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View(new HtmlPageEditingVM());
        }


        [HttpPost("{Culture}/[Area]/[Controller]/edit/html/{id}")]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> EditHtmlPage(HtmlPageEditingVM model, IFormCollection collection)
        {
            sectionList();
            var _collection = collection;
            var _files = _collection.Files;
            bool continueEditing = collection.ContainsKey("save-continue");
            bool newImageUploaded = false;
            try
            {
                model.KeywordsList = _stringConverters.ToListString(model.Keywords);
                model.Lang = GetCurrentDataLang();

                if (ModelState.IsValid)
                {
                    var oldimg = model.MainImage;
                    if (_files.Count > 0)
                    {
                        var fileInfo = await GenerateFileInfo(_files[0]);
                        IRequestProviderResult<UploadedFileURL> upload_result = await _uploadManager.UploadFileAsync(fileInfo, FileTypesEnum.PageMainImage);

                        if (upload_result.Success)
                        {
                            model.MainImage = upload_result.Data.URL;
                            newImageUploaded = true;
                        }
                    }


                    var result = await _pageService.EditHtmlPageAsync(model.MapEditToEditDto());
                    HandelPostingResult(result, _localizer["html_page_updating_successfully"]);
                    if (result.Success)
                    {
                        if (_files.Count > 0)
                        {
                            await DeleteFilesAsync(oldimg);
                        }

                        if (continueEditing)
                        {
                            return View(model);
                        }
                        return RedirectToAction("Index");
                    }
                    else if (newImageUploaded)
                    {
                        await DeleteFilesAsync(model.MainImage);
                    }
                }

            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            //GetLanguages();
            return View(model);
        }

        #endregion





        #region {Sections Page}

        [HttpGet("{Culture}/[Area]/[Controller]/sections/{id}")]
        public virtual async Task<ActionResult> GetSectionsDetailsAsync(Guid id)
        {

            // GetLanguages();
            try
            {
                var result = await _pageService.GetSectionsPageByIdAsync(id, GetCurrentDataLang());
                HandelGetingResult(result);
                if (result != null && result.Success && result.Data != null)
                {
                    return View("SectionsPageDetails", result.Data);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View("SectionsPageDetails", new SectionsPage());
        }




        [HttpGet("{Culture}/[Area]/[Controller]/create/sections")]
        public virtual ActionResult CreateSectionsPage()
        {
            sectionList();
            return View();
        }

        [HttpPost("{Culture}/[Area]/[Controller]/create/sections")]
        public virtual async Task<ActionResult> CreateSectionsPage(SectionsPageCreationVM model, IFormCollection collection)
        {
            sectionList();
            var _collection = collection;
            var _files = _collection.Files;
            bool continueEditing = collection.ContainsKey("save-continue");

            bool newImageUploaded = false;


            try
            {
                if (ModelState.IsValid)
                {
                    var oldimg = model.MainImage;
                    if (_files.Count > 0)
                    {
                        var fileInfo = await GenerateFileInfo(_files[0]);
                        IRequestProviderResult<UploadedFileURL> upload_result = await _uploadManager.UploadFileAsync(fileInfo, FileTypesEnum.PageMainImage);

                        if (upload_result.Success)
                        {
                            model.MainImage = upload_result.Data.URL;
                            newImageUploaded = true;
                        }
                    }
                    model.KeywordsList = _stringConverters.ToListString(model.Keywords);
                    model.Lang = GetCurrentDataLang();
                    var result = await _pageService.CreateSectionsPageAsync(model.MapToDto());
                    HandelPostingResult(result, _localizer["section_page_creation_successfully"]);
                    if (result.Success)
                    {
                        await DeleteFilesAsync(oldimg);
                        if (continueEditing)
                        {
                            return RedirectToAction("EditSectionsPage", new { id = result.Data, model.Lang });
                        }
                        return RedirectToAction("Index");
                    }
                    else if (newImageUploaded)
                    {
                        await DeleteFilesAsync(model.MainImage);
                    }

                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            // GetLanguages();
            return View(model);
        }

        [HttpGet("{Culture}/[Area]/[Controller]/edit/sections/{id}")]
        public virtual async Task<ActionResult> EditSectionsPage(Guid id)
        {
            sectionList();
            try
            {
                var result = await _pageService.GetSectionsPageByIdAsync(id, GetCurrentDataLang());
                if (result != null)
                {
                    return View(result.Data.MapToEditingVM());
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View();
        }


        [HttpPost("{Culture}/[Area]/[Controller]/edit/sections/{id}")]

        public virtual async Task<ActionResult> EditSectionsPage(SectionsPageEditingVM model, IFormCollection collection)
        {
            sectionList();
            var _collection = collection;
            var _files = _collection.Files;
            bool continueEditing = collection.ContainsKey("save-continue");
            var oldimg = model.MainImage;
            bool newImageUploaded = false;
            try
            {
                model.KeywordsList = _stringConverters.ToListString(model.Keywords);
                model.Lang = GetCurrentDataLang();
                if (ModelState.IsValid)
                {
                    if (_files.Count > 0)
                    {
                        var fileInfo = await GenerateFileInfo(_files[0]);
                        IRequestProviderResult<UploadedFileURL> upload_result = await _uploadManager.UploadFileAsync(fileInfo, FileTypesEnum.PageMainImage);

                        if (upload_result.Success)
                        {
                            model.MainImage = upload_result.Data.URL;
                        }
                    }


                    var result = await _pageService.EditSectionsPageAsync(model.MapEditToEditDto());
                    HandelPostingResult(result, _localizer["section_page_updating_successfully"]);
                    if (result.Success)
                    {
                        if (_files.Count > 0)
                        {
                            await DeleteFilesAsync(oldimg);
                        }
                        if (continueEditing)
                        {
                            return View(model);
                        }
                        return RedirectToAction("Index");
                    }
                    else if (newImageUploaded)
                    {
                        await DeleteFilesAsync(model.MainImage);
                    }

                }


            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            return View(model);
        }



        #endregion


        #endregion
    }
}