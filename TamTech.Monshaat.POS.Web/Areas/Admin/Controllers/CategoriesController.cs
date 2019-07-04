using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TamTechSDK.Web.Extensions.AutoMapper;
using TamTechSDK.Common.Services.ContentService.Categories;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Web.Models.Admin.Product;
using TamTechSDK.Web.Services.Telemetry;
using TamTechSDK.Web.Services.Configurations.Cultures;
using Microsoft.AspNetCore.Authorization;
using TamTechSDK.Web.Constants;
using Microsoft.Extensions.Localization;

namespace TamTechSDK.Web.Controllers.Admin
{
    [Authorize(Policy = ContentSDKPoliciesConstants.ProductsContentAdmin)]
    public class CategoriesController : AdminBaseController
    {
        #region Props  
        private ICategoriesServices _CategoryService;
        private IUploadService _uploadService;
        private readonly IStringLocalizer<AdminBaseController> _localizer;
        #endregion


        #region Ctors
        public CategoriesController(
            ITelemetryClientService telemetryClientService,
            ICategoriesServices categoryService,
            IUploadService uploadService,
             IStringLocalizer<AdminBaseController> localizer)
            : base(telemetryClientService, localizer)
        {
            this._CategoryService = categoryService;
            this._uploadService = uploadService;
            _localizer = localizer;
        }
        #endregion
        #region Utilities
        public async Task PrepareCreating()
        {

            ViewData["SubmitBtn"] = "Create";
            ViewData["FormAction"] = "Create";
        }

        #endregion


        #region Actions

        #region Switched
        // GET: Brands
        public virtual ActionResult Index()
        {
            return View();
        }


        // GET: Categories/Create
        public virtual async Task<ActionResult> Create()
        {
            await PrepareCreating();
            return View("Form");
        }

        // POST: Categories/Create
        [HttpPost]
        public virtual async Task<ActionResult> Create(CategoryVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _CategoryService.CreateAsync(model.MapToDto());
                    HandelPostingResult(result, _localizer["category_creation_successfully"]);
                    if (result.Success)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }


            await PrepareCreating();
            return View("Form", model);
        }


        #endregion
        [HttpGet]
        public virtual async Task<IActionResult> LoadCategories()
        {
            var result = await _CategoryService.GetCategoriesAsync();
            if (result.Success)
            {
                return Json(new { data = result.Data });
            }
            return View();
        }

        [HttpPost]
        public virtual async Task<IActionResult> LoadCategories(IFormCollection collection)
        {
            try
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var _collection = collection;
                var draw = _collection["draw"];
                var start = _collection["start"];
                var length = _collection["length"];
                var st = _collection["order[0][column]"];
                var sortColumn = _collection["columns[" + st + "][name]"];
                var sortColumnDir = _collection["order[0][dir]"];
                var searchValue = _collection["search[value]"];
                int pageSize = (!string.IsNullOrEmpty(length)) ? Convert.ToInt32(length) : 10;
                int skip = (!string.IsNullOrEmpty(start)) ? Convert.ToInt32(start) : 0;
                var result = await _CategoryService.GetCategoriesAsync();

                if (result.Success)
                {
                    return Json(new { draw = draw, recordsFiltered = 10, recordsTotal = 10, data = result.Data });
                }

            }
            catch (Exception)
            { throw; }
            return View();
        }


        // GET: Categories/Edit/5
        public virtual async Task<ActionResult> Edit(string id)
        {
            var result = await _CategoryService.GetCategoryByIdAsync(id);


            ViewData["FormAction"] = "Edit";

            if (result.Success)
            {
                return View("Form", result.Data);
            }
            return View();
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Delete/5
        public virtual async Task<JsonResult> Delete(string id)
        {

            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var result = await _CategoryService.DeleteCategoryByIdAsync(id);

                    return Json(result);
                }

            }
            catch (Exception)
            {
                return Json(new
                {
                    Success = false,
                    Messages = new Dictionary<string, string> {
                                            { _localizer["error"], _localizer["something_wrong"] }
                                        }
                });
            }

            return Json(new
            {
                Success = false,
                Messages = new Dictionary<string, string> {
                                              { _localizer["error"], _localizer["something_wrong"] }
                                        }
            });

        }

        // POST: Categories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        #endregion
    }
}