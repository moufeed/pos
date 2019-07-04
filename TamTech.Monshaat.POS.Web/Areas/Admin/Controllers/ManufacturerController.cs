using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TamTechSDK.Web.Extensions.AutoMapper;
using TamTechSDK.Common.Services.ContentService.Brands;
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
    public class ManufacturerController : AdminBaseController
    {
        #region Props  
        private IBrandsServices _brandService;
        private IUploadService _uploadService;
        #endregion


        #region Ctors
        public ManufacturerController(
            ITelemetryClientService telemetryClientService,
            IBrandsServices brandService,
            IUploadService uploadService,
            IStringLocalizer<AdminBaseController> localizer)
            : base(telemetryClientService, localizer)
        {
            this._brandService = brandService;
            this._uploadService = uploadService;
        }
        #endregion
        #region Utilities
        public async Task PrepareCreating()
        {
            ViewData["PageTitle"] = "Create Manufacturer.";
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

        public virtual async Task<ActionResult> Create()
        {
            await PrepareCreating();
            return View("Form");
        }

        // POST: Brands/Create
        [HttpPost]
        public virtual async Task<ActionResult> Create(BrandVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var result = await _brandService.CreateAsync(model.MapToDto());
                    HandelPostingResult(result, "The manufacturer creation was successfully.");
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

        public virtual async Task<JsonResult> LoadManufacturers()
        {
            var result = await _brandService.GetBrandsListAsync();
            if (result.Success)
            {
                return Json(new { data = result.Data });
            }
            return Json(new { });

        }

        // GET: Brands/Details/5
        public virtual ActionResult Details(int id)
        {
            return View();
        }

        // GET: Brands/Create


        // GET: Brands/Edit/5
        public virtual async Task<ActionResult> Edit(string id)
        {
            var result = await _brandService.GetBrandByIdAsync(id);

            ViewData["PageTitle"] = "Edit Manufacturer.";
            ViewData["SubmitBtn"] = "Update";
            ViewData["FormAction"] = "Edit";

            if (result.Success)
            {
                return View("Form", result.Data);
            }

            return View();

        }

        // POST: Brands/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(int id, IFormCollection collection)
        {
            TempData["NontifyMessage"] = "";
            try
            {
                // TODO: Add update logic here
                TempData["showSuccessNotification"] = true;
                ViewBag.NontifyMessage = "Manufacturer has been Updated";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["showSuccessNotification"] = null;
                return View("Form");
            }
        }

        // GET: Brands/Delete/5
        public virtual async Task<JsonResult> Delete(string id)
        {

            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var result = await _brandService.DeleteBrandByIdAsync(id);

                    return Json(result);
                }

            }
            catch (Exception)
            {
                return Json(new
                {
                    Success = false,
                    Messages = new Dictionary<string, string> {
                                            { "Error", "Something wrong" }
                                        }
                });
            }

            return Json(new
            {
                Success = false,
                Messages = new Dictionary<string, string> {
                                            { "Error", "Something wrong" }
                                        }
            });

        }

        // POST: Brands/Delete/5
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