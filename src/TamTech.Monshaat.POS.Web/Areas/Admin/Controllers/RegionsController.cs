using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Models.Dtos.Sort;
using TamTech.Monshaat.POS.Web.Services.ContentService.Regions;
using TamTech.Monshaat.POS.Web.Services.ContentService.Regions.Models;
using TamTech.Monshaat.POS.Web.Core.Mappers.Regions;
using TamTech.Monshaat.POS.Web.Models.VMs.Admin.Regions;
using TamTech.Monshaat.POS.Web.Models.VMs.Shared.Filters;
using TamTech.Monshaat.POS.Web.Core.Telemetry;

namespace TamTechSDK.Web.Controllers.Admin
{
    public class RegionsController : AdminBaseController
    {
        private readonly IRegionService _regionsServices;
        private readonly IStringLocalizer<AdminBaseController> _localizer;

        public RegionsController(ITelemetryService telemetryClientService,
            IStringLocalizer<AdminBaseController> localizer,
            IRegionService regionsServices
            ) : base(telemetryClientService, localizer)
        {
            _regionsServices = regionsServices;
            _localizer = localizer;
        }



        [HttpGet("{Culture}/[Area]/[Controller]")]
        public virtual async Task<ActionResult> Index(Filter model)
        {

            ViewBag.showReset = new Filter().Equals(model);

            GetDefaultFiltersList(model, "name");

            ViewBag.FilterModel = model;


            var _lang = GetCurrentDataLang();
            PaginationModel pagination = new PaginationModel
            {
                PageNumber = model.PageNumber.ToString(),
                PageSize = model.PageSize
            };

            SortingModel sorting = CreateSortingModel(model.SortBy);
            try
            {
                DTFilter _filters = new DTFilter
                {
                    Lang = _lang,
                    PageSize = model.PageSize,
                    PageNumber = model.PageNumber,
                    SortBy = sorting.SortBy,
                    Descending = sorting.Descending,
                    Search = GenrateSearchParams(model)
                };
                var items = await _regionsServices.GetExceptSoftDeletedAsync(_filters);

                return View(items);

            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            return View(new PagedResultModel<List<RegionDto>>());
        }




        [HttpGet("{Culture}/[Area]/[Controller]/Create")]
        public virtual async Task<ActionResult> Create()
        {
            ViewBag.IsEditMode = false;

            return View("Form", new RegionVM());
        }


        [HttpPost("{Culture}/[Area]/[Controller]/Create")]
        public virtual async Task<IActionResult> Create(RegionVM model, IFormCollection collection)
        {
            bool continueEditing = collection.ContainsKey("save-continue");

            try
            {
                if (ModelState.IsValid)
                {


                    var result = await _regionsServices.CreateAsync(model.MapToCreateRegionModel());

                    HandelPostingResult(result, _localizer["region_creation_successfully"]);
                    if (result.Success)
                    {
                        if (continueEditing)
                        {
                            ViewBag.IsEditMode = true;
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
            ViewBag.IsEditMode = false;
            return View("Form", model);
        }



        [HttpGet("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public virtual async Task<ActionResult> Edit(int id)
        {
            ViewBag.IsEditMode = true;

            try
            {
                var result = await _regionsServices.GetByIdExceptSoftDeletedAsync(id, GetCurrentDataLang());

                if (result.Success && result.Data != null)
                    return View("Form", result.Data.MapToRegionVM());

                ViewBag.EmptyResponse = true;

            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            return View("Form", new RegionVM());
        }


        [HttpPost("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public virtual async Task<IActionResult> Edit(RegionVM model, IFormCollection collection, string lang)
        {



            bool continueEditing = collection.ContainsKey("save-continue");

            try
            {
                if (ModelState.IsValid)
                {
                    model.Lang = GetCurrentDataLang();


                    var result = await _regionsServices.EditAsync(model.MapToUpdateRegionModel());

                    HandelPostingResult(result, _localizer["regions_update_successfully"]);

                    if (result.Data)
                    {

                        if (continueEditing)
                        {
                            ViewBag.IsEditMode = true;
                            return View("Form", model);
                        }

                        return RedirectToAction("Index");
                    }

                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }


            ViewBag.IsEditMode = true;
            return View("Form", model);
        }




        [HttpGet("{Culture}/[Area]/[Controller]/Delete/{id}")]
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _regionsServices.SoftDeleteAsync(id);
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
        public virtual async Task<JsonResult> PublishAsync(int id)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    PublishLookupModel data = new PublishLookupModel
                    {
                        Id = id,
                        Lang = GetCurrentDataLang()

                    };

                    var result = await _regionsServices.PublishAsync(data);
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

    }
}
