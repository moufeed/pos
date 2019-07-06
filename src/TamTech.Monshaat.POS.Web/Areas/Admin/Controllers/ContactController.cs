using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Models.Dtos.Sort;
using TamTech.Monshaat.POS.Web.Services.ContentService.ContactUs;
using TamTech.Monshaat.POS.Web.Services.ContentService.ContactUs.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Status;
using TamTech.Monshaat.POS.Web.Services.ContentService.Status.Models;
using TamTech.Monshaat.POS.Web.Services.Email;
using TamTech.Monshaat.POS.Web.Services.Email.Models;
using TamTech.Monshaat.POS.Web.Services.Identity;
using TamTech.Monshaat.POS.Web.Services.Identity.Models;
using TamTech.Monshaat.POS.Web.Services.Identity.Models.Params;
using TamTech.Monshaat.POS.Web.Services.ContentService.Types;
using TamTech.Monshaat.POS.Web.Services.ContentService.Types.Models;
using TamTech.Monshaat.POS.Web.Core.Constants;
using TamTech.Monshaat.POS.Web.Core.Mappers;
using TamTech.Monshaat.POS.Web.Core.Mappers.Contact;
using TamTech.Monshaat.POS.Web.Models.VMs.Admin.Contact;
using TamTech.Monshaat.POS.Web.Models.VMs.Admin.Email;
using TamTech.Monshaat.POS.Web.Models.VMs.Shared.Filters;
using TamTech.Monshaat.POS.Web.Core.Cultures;
using TamTech.Monshaat.POS.Web.Core.Telemetry;
using TamTech.Monshaat.POS.Web.Models.Dtos.SelectList;

namespace TamTechSDK.Web.Controllers.Admin
{
    [Authorize(Policy = ContentSDKPoliciesConstants.ContactUsAdmin)]
    public class ContactController : AdminBaseController
    {


        IEmailSenderService _EmailService;
        IUsersManagerService _IdentityService;
        IContactService _contactService;
        IContactTypeService _typeService;
        IContactUsStatusService _statusService;
        IStringLocalizer<AdminBaseController> _localizer;
        public ContactController(
            IUsersManagerService IdentityService,
            IEmailSenderService emailService,
            ITelemetryService telemetryClientService,
            IStringLocalizer<AdminBaseController> localizer,
            IContactService contactService,
            IContactTypeService typeService,
            IContactUsStatusService statusService
            ) : base(telemetryClientService, localizer)
        {
            _IdentityService = IdentityService;
            _EmailService = emailService;
            _contactService = contactService;
            _typeService = typeService;
            _statusService = statusService;
            _localizer = localizer;
        }



        #region utilites




        #endregion

        [HttpGet("{Culture}/[Area]/[controller]")]
        public async virtual Task<ActionResult> Index(Filter model)
        {
            ViewBag.showReset = new Filter().Equals(model);
            ViewBag.FilterModel = model;
            GetDefaultFiltersList(model, "fullname");
            SortingModel sorting = CreateSortingModel(model.SortBy);
            var types = await _typeService.GetSelectListAsync(GetCurrentDataLang(), true);
            HandelGetingResult(types);


            ViewBag.types = new SelectList(VerifySucceed(types) ? types.Data : new List<SelectListItemModel>(), "Value", "Text", model.TypeId);
            

            var status = await _statusService.GetAllSelectListAsync(GetCurrentDataLang());
            ViewBag.statusList = new SelectList(VerifySucceed(status) ? status.Data : new List<SelectListItemModel>(), "Value", "Text", model.StatusId);

            DTFilter filters = new DTFilter
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
                var items = await _contactService.GetExceptSoftDeletedAsync(filters);
                return View(VerifySucceed(items) ? items.Data : null);
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View();
        }


        [HttpGet("{Culture}/[Area]/[controller]/View/{id}")]
        public virtual async Task<ActionResult> ViewMessage(Guid id)
        {
            ContactDto model = new ContactDto();
            try
            {
                var item = await _contactService.GetByIdAndSetStatusAsync(id, GetCurrentDataLang());
                return View("Details", VerifySucceed(item)  ? item.Data : null);
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View("Details", null);
        }


        public virtual async Task<JsonResult> reply(ReplayVm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _contactService.ReplayAsync(model.MapToReplyModel());

                    if (VerifySucceed(result))
                    {
                        bool Sendemail = await _EmailService.SendAsync(new EmailModel
                        {
                            Email = model.Email,
                            Subject = model.Subject != null ? model.Subject : _localizer["response_email", model.ReplyType],
                            HtmlMessage = model.Replay,
                            Message = Regex.Replace(model.Replay, "<.*?>", String.Empty),
                            ReasonOfSend = _localizer["respond_to_the", model.ReplyType]
                        });
                        if (Sendemail)
                        {
                            return ReturnJsonResult(result, model);
                        }
                        else
                        {
                            var remove = await _contactService.RemoveReplayAsync(model.Id);
                            ModelState.AddModelError(_localizer["send_error"], _localizer["try_again_later"]);
                            return ReturnJsonErrorResult(ModelState, model);
                        }
                    }
                    else
                    {
                        if (result.Messages != null)
                        {
                            AddModelStateError(result.Messages);
                        }
                        else
                        {
                            ModelState.AddModelError(_localizer["send_error"], _localizer["try_again_later"]);
                        }

                        return ReturnJsonErrorResult(ModelState, model);
                    }

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

        

        [HttpPost("{Culture}/[Area]/[controller]/SendJsonEmail")]
        public virtual async Task<JsonResult> SendJsonEmail(EmailVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    bool result = await _EmailService.SendAsync(new EmailModel
                    {
                        Email = model.Recipients[0],
                        Subject = model.Subject,
                        HtmlMessage = model.Message,
                        Message = Regex.Replace(model.Message, "<.*?>", String.Empty),
                        ReasonOfSend = "MessageByWebAdminPanel"
                    });

                    return Json(new { success = result });

                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, model);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return Json(new { success = false });
        }
    }
}