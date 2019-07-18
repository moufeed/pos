using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using TamTech.Monshaat.POS.EFile2.Utilities;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Models.Dtos.Sort;
using TamTech.Monshaat.POS.Web.Services.Email;
using TamTech.Monshaat.POS.Web.Services.Email.Models;
using TamTech.Monshaat.POS.Web.Services.Identity;
using TamTech.Monshaat.POS.Web.Services.Identity.Models.Params;
using TamTech.Monshaat.POS.Web.Services.ContentService.Status;
using TamTech.Monshaat.POS.Web.Services.ContentService.Vendors;
using TamTech.Monshaat.POS.Web.Services.ContentService.Vendors.Models;
using TamTech.Monshaat.POS.Web.Core.Constants;
using TamTech.Monshaat.POS.Web.Models.VMs.Admin.Vendor;
using TamTech.Monshaat.POS.Web.Models.VMs.Shared;
using TamTech.Monshaat.POS.Web.Models.VMs.Shared.Filters;
using TamTech.Monshaat.POS.Web.Core.Telemetry;
using TamTech.Monshaat.POS.Web.Models.Dtos.SelectList;
using TamTech.Monshaat.POS.SDK.Core.Constants;

namespace TamTechSDK.Web.Controllers.Admin
{
 //   [Authorize(Policy = ContentSDKPoliciesConstants.VendorAdmin)]
    public class VendorsController : AdminBaseController
    {
        private readonly IVendorAdminServices _vendorServices;
        private readonly IStringLocalizer<BaseController> _localizer;
        private readonly IVendorStatusService _statusServices;
        private readonly IEmailSenderService _emailSender;
        private readonly IdentityUtilities _identityUtilities;
        private readonly IUsersManagerService _usersManagerService;
        public VendorsController(
            ITelemetryService telemetryClientService,
            IStringLocalizer<BaseController> localizer,
            IVendorAdminServices vendorServices,
            IVendorStatusService statusServices,
            IdentityUtilities identityUtilities,
            IEmailSenderService emailSender,
            IUsersManagerService usersManagerService) : base(telemetryClientService, localizer)
        {
            _vendorServices = vendorServices;
            _statusServices = statusServices;
            _localizer = localizer;
            _emailSender = emailSender;
            _identityUtilities = identityUtilities;
            _usersManagerService = usersManagerService;
        }


        public async virtual Task<IActionResult> Index(Filter model)
        {
            var _lang = GetCurrentDataLang();

            var status = await _statusServices.GetAllSelectListAsync(_lang);
            var _items = VerifySucceed(status) ? status.Data : new List<SelectListItemModel>();
                ViewBag.statusList =   new SelectList(_items, "Value", "Text", model.StatusId)   ;
            

            try
            {
                ViewBag.showReset = new Filter().Equals(model);

                ViewBag.FilterModel = model;

                GetDefaultFiltersList(model, "name");

                ViewBag.visibilityList =  new List<SelectListItem>()
                {
                     new SelectListItem
                    { Text = _localizer["t_active"] , Value = "1" ,  Selected =  model.Visibility  == 1 },
                      new SelectListItem
                    { Text = _localizer["t_inactive"] , Value = "0" ,  Selected = model.Visibility  == 0 },
                };
               

                SortingModel sorting = CreateSortingModel(model.SortBy);

                DTFilter filters = new DTFilter
                {
                    Lang = _lang,
                    PageSize = model.PageSize,
                    PageNumber = model.PageNumber,
                    SortBy = sorting.SortBy,
                    Descending = sorting.Descending,
                    Search = GenrateSearchParams(model)
                };
                var items = await _vendorServices.GetExceptSoftDeletedAsync(filters);
                return View(VerifySucceed(items) ? items.Data : null );
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            return View();
        }



        [HttpGet("{Culture}/[Area]/[Controller]/Details/{id}")]
        public async virtual Task<IActionResult> Details(Guid id)
        {
            try
            {
                var _act = await _vendorServices.GetVendorActions(GetCurrentDataLang());
                ViewBag.Actions = VerifySucceed(_act)  ? _act.Data : new List<ProcessActionModel>();

                var result = await _vendorServices.GetByIdExceptSoftDeletedAsync(id, GetCurrentDataLang());

                return View("Details", VerifySucceed(result) ? result.Data : null);
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View();
        }

        [HttpPost("{Culture}/[Area]/[Controller]/Action")]
        public virtual async Task<JsonResult> VendorAction(ActionVm model)
        {
            string EmailMessage = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    SetActionModel action = new SetActionModel
                    {
                        Id = model.Id,
                        ActionId = model.ActionId,
                        Notes = model.Notes,
                        Lang = model.Lang
                    };

                    var result = await _vendorServices.SetActionAsync(action);
                    if (VerifySucceed(result))
                    {
                        // This case: The admin approved to vendor
                        if (result.Data.Vendor.Activated)
                        {
                            await _identityUtilities.AddUserToVendorRole(result.Data.IdentityNo);
                        }

                        if (string.IsNullOrEmpty(model.Notes))
                        {
                            EmailMessage = _localizer[result.Data.Vendor.Activated ? "email_accepted_message" : "email_rejected_message", result.Data.Vendor.StatusName];
                        }
                        EmailModel _email = new EmailModel
                        {
                            Email = model.Email,
                            Subject = "وزارة التجارةوالاستثمار - منشآت",
                            HtmlMessage = EmailMessage,
                            Message = string.IsNullOrEmpty(model.Notes) ? EmailMessage : Regex.Replace(model.Notes, "<.*?>", String.Empty),
                            ReasonOfSend = result.Data.Vendor.Activated ? EmailTemplates.RequestAcceptance : EmailTemplates.RegisterRejection
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
                TrackExceptionOnly(ex);
                return ReturnJsonErrorResult(ex.Message, model);
            }
        }

        [HttpPost("{Culture}/[Area]/[Controller]/VendorActivation")]
        public virtual async Task<JsonResult> VendorActivation(VendorActivationVM model)
        {
            try
            {
                var response = await _vendorServices.ActivateAsync(new ActiveModel
                {
                    Id = model.Id,
                    Lang = GetCurrentDataLang()
                });

                if (VerifySucceed(response))
                {

                    if (model.Checked)
                    {
                        var UnblockResult = await _usersManagerService.UnblockUserAsync(new UserNameModel { UserName = model.Name });
                        return ReturnJsonResult(UnblockResult, model);
                    }
                    else
                    {
                        var blockResult = await _usersManagerService.BlockUserAsync(new UserNameModel { UserName = model.Name });
                        return ReturnJsonResult(blockResult, model);
                    }

                }
                return ReturnJsonResult(response, model);

            }
            catch (Exception ex)
            {
                TrackException(ex);
                return ReturnJsonErrorResult(ex.Message, model);
            }
        }


        [HttpGet("{Culture}/[Area]/[Controller]/history/{id}")]
        public virtual async Task<PartialViewResult> GetHistory(Guid id)
        {

            try
            {
                var result = await _vendorServices.GetStatusHistoriesListAsync(id, GetCurrentDataLang());
                return PartialView("~/Areas/Admin/Views/Pos/Vendors/_history.cshtml", result.Data);
            }
            catch (Exception ex)
            {
                TrackException(ex);
                return PartialView("~/Areas/Admin/Views/Vendors/Partials/_history.cshtml", new List<VendorStatusHistoryDto>());
            }

        }
    }
}
