using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Services.ContentService.City;
using TamTechSDK.Common.Services.ContentService.Request;
using TamTechSDK.Common.Services.ContentService.Request.Models;
using TamTechSDK.Common.Services.Status;
using TamTechSDK.Web.Constants;
using TamTechSDK.Web.Models.Admin.Requests;
using TamTechSDK.Web.Models.Shared.Filters;
using TamTechSDK.Web.Services.Telemetry;

namespace TamTechSDK.Web.Controllers.Admin
{
    [Authorize(Policy = ContentSDKPoliciesConstants.RequestAdmin)]
    public class RequestController : AdminBaseController
    {
        private IRequestService _RequestService;
        private ICityService _cityService;
        private IRequestStatusService _statusService;

        private readonly IStringLocalizer<AdminBaseController> _localizer;


        public RequestController(ITelemetryClientService telemetryClientService, IRequestService requestService,
            IStringLocalizer<AdminBaseController> localizer,
            ICityService cityService,
            IRequestStatusService statusService
            ) : base(telemetryClientService, localizer)
        {
            _RequestService = requestService;
            _localizer = localizer;
            _cityService = cityService;
            _statusService = statusService;
        }


        #region  utility
        private async Task GetSelectsLists(Filter model)
        {

            List<SelectListItem> SortItems = new List<SelectListItem>()
            {

                new SelectListItem
                {
                    Text = "Name: A to Z",
                    Value = "name" ,
                    Selected = model.SortBy == "Title" && !model.Desc
                },
                new SelectListItem
                {
                    Text =   "Name: Z to A",
                    Value = "name_desc" ,
                    Selected = model.SortBy == "Title" && model.Desc
                },
                new SelectListItem
                {
                    Text = "Newest first",
                    Value = "date" ,
                    Selected =  model.SortBy == "date" && !model.Desc
                },
                new SelectListItem
                {
                    Text = "Oldest first",
                    Value = "date_desc" ,
                    Selected =  model.SortBy == "date" && model.Desc
                },

            };
            ViewBag.sortNameList = SortItems;

            var cityList = await _cityService.GetAllListExceptSoftDeletedAsync();
            ViewBag.Cities = new SelectList(cityList, "Value", "Text");

            var status = await _statusService.GetAllSelectListAsync(GetCurrentDataLang());
            ViewBag.statusList = new SelectList(status, "Value", "Text");

        }


        #endregion


        [HttpGet("{Culture}/[Area]/[Controller]")]
        public virtual async Task<ActionResult> Index(Filter model)
        {

            ViewBag.showReset = new Filter().Equals(model);
            ViewBag.FilterModel = model;
            GetDefaultFiltersList(model);
            await GetSelectsLists(model);

            PaginationModel pagination = new PaginationModel
            {
                PageNumber = model.PageNumber.ToString(),
                PageSize = model.PageSize
            };


            SortingModel sorting = CreateSortingModel(model.SortBy);

            try
            {
                var result = await _RequestService.GetAllExceptSoftDeletedAsync(pagination, GenrateSearchParams(model), sorting, GetCurrentDataLang());

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
            return View(new List<RequestDto>());
        }

        [HttpGet("{Culture}/[Area]/[Controller]/{id}")]
        public virtual async Task<ActionResult> Details(Guid id)
        {
            try
            {
                var result = await _RequestService.GetByIdAsync(id, GetCurrentDataLang());

                if (result.Success)
                {
                    ViewBag.history = await _RequestService.GetRequestHistoriesListByRequestIdAsync(id, GetCurrentDataLang());
                    ViewBag.statusList = await _statusService.GetAllSelectListAsync(GetCurrentDataLang());


                    return View(result.Data);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            return View(new RequestDto());
        }

        [HttpPost("{Culture}/[Area]/[Controller]/{id}")]
        public virtual async Task<ActionResult> Details(UpdateRequestStatusModel model)
        {
            try
            {
                if (ModelState.IsValid && model.CurrentStatusId != model.StatusId)
                {
                    var result = await _RequestService.UpdateRequestStatusAsync(model);

                    if (result.Success)
                    {
                        return RedirectToAction("Details", new { model.Id });
                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return RedirectToAction("Details", new { model.Id });
        }
    }
}
