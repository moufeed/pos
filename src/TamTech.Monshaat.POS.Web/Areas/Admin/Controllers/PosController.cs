using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Sort;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Status;
using TamTech.Monshaat.POS.Web.SDK.Services.POSs;
using TamTech.Monshaat.POS.Web.SDK.Services.POSs.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Sectors;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Types;
using TamTech.Monshaat.POS.Web.SDK.Core.Constants;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Shared.Filters;
using TamTech.Monshaat.POS.Web.SDK.Core.Telemetry;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.SelectList;
using TamTech.Monshaat.POS.Web.SDK.Services.Email;
using TamTech.Monshaat.POS.Web.SDK.Services.Email.Models;
using System.Text.RegularExpressions;
using TamTech.Monshaat.POS.SDK.Core.Constants;

namespace TamTechSDK.Web.Controllers.Admin
{
  //  [Authorize(Policy = ContentSDKPoliciesConstants.POSAdmin)]
    public class PosController : AdminBaseController
    {

        private readonly IPOSAdminServeice _posservice;
        private readonly IPosTypeService _typeService;
        private readonly IPosStatusService _statusService;
        private readonly IPOSSectorServices _sectorservice;
        private readonly IEmailSenderService _emailSender;
        public PosController(ITelemetryService telemetryClientService,
                IStringLocalizer<BaseController> localizer,
                IPOSAdminServeice posservice,
                IPosTypeService typeservice,
                IPosStatusService statusService,
                IPOSSectorServices sectorservice,
                IEmailSenderService emailSender
            ) : base(telemetryClientService, localizer)
        {

            _posservice = posservice;
            _typeService = typeservice;
            _statusService = statusService;
            _sectorservice = sectorservice;
            _emailSender = emailSender;
        }



        private async Task init(Filter model)
        {
            var _lang = GetCurrentDataLang();
            var sectors = await _sectorservice.GetSelectListAsync(_lang);
            ViewBag.sectors = new SelectList(VerifySucceed(sectors) ? sectors.Data : new List<SelectListItemModel>(), "Value", "Text", model.SectorId);
           
            var types = await _typeService.GetSelectListAsync(_lang);
            ViewBag.types = new SelectList(VerifySucceed(types) ? types.Data : new List<SelectListItemModel>() , "Value", "Text", model.TypeId);

            var status = await _statusService.GetAllSelectListAsync(_lang);
            ViewBag.statusList = new SelectList(VerifySucceed(status) ? status.Data : new List<SelectListItemModel>(), "Value", "Text", model.StatusId);

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
                return View(VerifySucceed(items) ? items.Data : null);
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            return View();
        }

        [HttpGet("{Culture}/[Area]/[Controller]/Preview/{id}")]
        public virtual async Task<IActionResult> details(Guid id)
        {
            try
            {
                var _act = await _posservice.GetPOSActionsAsync(GetCurrentDataLang());
                ViewBag.PosActions = VerifySucceed(_act) ? _act.Data : new List<ProcessActionModel>();

                var result = await _posservice.GetByIdExceptSoftDeletedAsync(id, GetCurrentDataLang());
                return View("Details", VerifySucceed(result) ? result.Data : null);
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View("Details");
        }


        [HttpPost("{Culture}/[Area]/[Controller]/pos/Action")]
        public virtual async Task<JsonResult> PosAction(UpdatePOSStatus model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _posservice.SetActionAsync(model);

                    if (result.Success)
                    {
                        EmailModel _email = new EmailModel
                        {
                            Email = result.Data.VendorEmail,
                            Subject = "وزارة التجارةوالاستثمار - منشآت",
                            HtmlMessage = model.Notes,
                            Message = string.IsNullOrEmpty(model.Notes) ? model.Notes : Regex.Replace(model.Notes, "<.*?>", String.Empty),
                            ReasonOfSend = result.Data.Approved? EmailTemplates.RequestAcceptance : EmailTemplates.RequestRejection
                        };
                        var emailsender = await _emailSender.SendAsync(_email);
                    }
                    return ReturnJsonResult(result, model);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, model);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
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
                    PublishModel data = new PublishModel
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
                return PartialView("~/Areas/Admin/Views/Pos/Partials/_history.cshtml", VerifySucceed(result) ? result.Data : new List<POSStatusHistoryDto>());
            }
            catch (Exception ex)
            {
                TrackException(ex);
                return PartialView("~/Areas/Admin/Views/Pos/Partials/_history.cshtml", new List<POSStatusHistoryDto>());
            }

        }
    }
}
