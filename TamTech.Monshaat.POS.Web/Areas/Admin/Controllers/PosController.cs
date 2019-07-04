using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Filter;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Services.Status;
using TamTechSDK.Common.Services.PosService.PosService;
using TamTechSDK.Common.Services.PosService.PosService.Models;
using TamTechSDK.Common.Services.PosService.Sectors;
using TamTechSDK.Common.Services.TypesService;
using TamTechSDK.Web.Constants;
using TamTechSDK.Web.Models.Shared.Filters;
using TamTechSDK.Web.Services.Telemetry;

namespace TamTechSDK.Web.Controllers.Admin
{
    [Authorize(Policy = ContentSDKPoliciesConstants.POSAdmin)]
    public class PosController : AdminBaseController
    {

        private readonly IPOSAdminServeice _posservice;
        private readonly IPosTypeService _typeService;
        private readonly IPosStatusService _statusService;
        private readonly ISectorServices _sectorservice;

        public PosController(ITelemetryClientService telemetryClientService,
                IStringLocalizer<AdminBaseController> localizer,
                IPOSAdminServeice posservice,
                IPosTypeService typeservice,
                IPosStatusService statusService,
                ISectorServices sectorservice
            ) : base(telemetryClientService, localizer)
        {

            _posservice = posservice;
            _typeService = typeservice;
            _statusService = statusService;
            _sectorservice = sectorservice;
        }



        private async Task init(Filter model)
        {
            var _lang = GetCurrentDataLang();

            var sectors = await _sectorservice.GetSelectListAsync(_lang);
            if (sectors != null && sectors.Count > 0)
            {
                ViewBag.sectors = new SelectList(sectors, "Value", "Text", model.SectorId);
            }
            var types = await _typeService.GetSelectListAsync(_lang);
            if (types != null && types.Count > 0)
            {
                ViewBag.types = new SelectList(types, "Value", "Text", model.TypeId);
            }

            var status = await _statusService.GetAllSelectListAsync(_lang);
            if (status != null && status.Count > 0)
            {
                ViewBag.statusList = new SelectList(status, "Value", "Text", model.StatusId);
            }

        }


        [HttpGet("{Culture}/[Area]/[Controller]")]
        public virtual async Task<IActionResult> Index(Filter model)
        {


            ViewBag.showReset = new Filter().Equals(model);
            ViewBag.FilterModel = model;
            GetDefaultFiltersList(model, "name");
            SortingModel sorting = CreateSortingModel(model.SortBy);
            try
            {

                await init(model);

                DTFilter filters = new DTFilter
                {
                    Lang = GetCurrentDataLang(),
                    PageSize = model.PageSize,
                    PageNumber = model.PageNumber,
                    SortBy = sorting.SortBy,
                    Descending = sorting.Descending,
                    Search = GenrateSearchParams(model)
                };

                var items = await _posservice.GetExceptSoftDeletedAsync(filters);
                return View(items);
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            return View(new PagedResultModel<List<PosBaseDto>>());
        }

        [HttpGet("{Culture}/[Area]/[Controller]/Preview/{id}")]
        public virtual async Task<IActionResult> details(Guid id)
        {
            try
            {
                ViewBag.PosActions = await _posservice.GetPOSActionsAsync(GetCurrentDataLang());

                var result = await _posservice.GetByIdExceptSoftDeletedAsync(id, GetCurrentDataLang());

                if (result != null)
                {
                    return View("Details", result);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View("Details", new PosDto());
        }


        [HttpPost("{Culture}/[Area]/[Controller]/pos/Action")]
        public virtual async Task<JsonResult> PosAction(UpdatePOSStatus model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _posservice.SetActionAsync(model);
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
                return ReturnJsonErrorResult(ex.Message, model);
            }
        }

        [HttpGet("{Culture}/[Area]/[Controller]/Delete/{id}")]
        public virtual async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _posservice.SoftDeleteAsync(id);
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
        public virtual async Task<JsonResult> PublishAsync(Guid id)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    PublishDTO data = new PublishDTO
                    {
                        Id = id,
                        Lang = GetCurrentDataLang()

                    };

                    var result = await _posservice.PublishAsync(data);
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


        [HttpGet("{Culture}/[Area]/[Controller]/history/{id}")]
        public virtual async Task<PartialViewResult> GetHistory(Guid id)
        {

            try
            {
                var result = await _posservice.GetStatusHistoriesListAsync(id, GetCurrentDataLang());
                return PartialView("~/Areas/Admin/Views/Pos/Partials/_history.cshtml", result);
            }
            catch (Exception ex)
            {
                TrackException(ex);
                return PartialView("~/Areas/Admin/Views/Pos/Partials/_history.cshtml", new List<POSStatusHistoryDto>());
            }

        }
    }
}
