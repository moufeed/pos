using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TamTechSDK.Common.Services.ContentService;
using TamTechSDK.Common.Services.ContentService.Reviews;
using TamTechSDK.Common.Services.ContentService.Reviews.Models;
using TamTechSDK.Web.Constants;

namespace TamTechSDK.Web.Controllers.Admin
{
    [Area("Admin")]
    [Authorize(Policy = ContentSDKPoliciesConstants.ProductsContentAdmin)]
    public class ReviewsController : Controller
    {

        private IReviewsServices _reviewsServices;
        private IContentServices _contentServices;

        public ReviewsController(IContentServices contentServices, IReviewsServices reviewsServices)
        {
            _contentServices = contentServices;
            _reviewsServices = reviewsServices;
        }
        // GET: Reviews
        public virtual ActionResult Index()
        {
            return View();
        }


        public virtual async Task<JsonResult> GetReviews()
        {
            var result = await _reviewsServices.GetAllReviewsAsync();

            if (result.Success)
            {
                return Json(new { data = result.Data, success = result.Success });
            }

            return Json(new { data = new object(), success = false });
        }

        // GET: Reviews/Details/5
        public virtual ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reviews/Create
        public virtual async Task<ActionResult> Create()
        {
            Review Model = new Review();
            ViewBag.viewMode = 0;
            ViewBag.ProductsNames = new List<SelectListItem> { };
            var result = await _contentServices.GetProductsNames();

            if (result.Success)
            {
                ViewBag.ProductsNames = Mapper.Map<List<SelectListItem>>(result.Data);

            }

            ViewData["PageTitle"] = "Create Review";
            ViewData["FormAction"] = "Create";
            ViewData["SubmitBtn"] = "Create";

            return View("Form", Model);
        }

        // POST: Reviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(Review collection)
        {
            try
            {

                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Reviews/Edit/5
        public virtual async Task<ActionResult> Edit(string id)
        {
            var result = await _reviewsServices.GetReviewByIdAsync(id);
            ViewBag.viewMode = 1;
            ViewData["PageTitle"] = "Edit Review";
            ViewData["FormAction"] = "Edit";
            ViewData["SubmitBtn"] = "update";
            ViewBag.ProductsNames = new List<SelectListItem> { };
            var ProductsNames = await _contentServices.GetProductsNames();

            if (ProductsNames.Success)
            {
                ViewBag.ProductsNames = Mapper.Map<List<SelectListItem>>(ProductsNames.Data);

            }

            if (result.Success)
            {
                return View("Form", result.Data);
            }
            return View();
        }

        // POST: Reviews/Edit/5
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

        // GET: Reviews/Delete/5
        public virtual ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reviews/Delete/5
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


        public virtual async Task<JsonResult> Hints()
        {
            var result = await _contentServices.GetProductsNames();
            if (result.Success)
            {
                return Json(new { data = result.Data });
            }
            return Json(new { data = false });
        }
    }
}