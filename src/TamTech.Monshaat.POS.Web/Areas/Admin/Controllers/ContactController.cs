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
            if (types.Success && types.Data.Count > 0)
            {
                ViewBag.types = new SelectList(types.Data, "Value", "Text", model.TypeId);
            }

            var status = await _statusService.GetAllSelectListAsync(GetCurrentDataLang());
            if (status.Success && status.Data.Count > 0)
            {
                ViewBag.statusList = new SelectList(status.Data, "Value", "Text", model.StatusId);
            }

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
                return View(items);
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View(new PagedResultModel<List<ContactDto>>());
        }


        [HttpGet("{Culture}/[Area]/[controller]/View/{id}")]
        public virtual async Task<ActionResult> ViewMessage(Guid id)
        {
            ContactDto model = new ContactDto();
            try
            {
                var item = await _contactService.GetByIdAndSetStatusAsync(id, GetCurrentDataLang());
                if (item != null)
                {
                    return View("Details", item);
                }

            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View("Details", model);
        }


        public virtual async Task<JsonResult> reply(ReplayVm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _contactService.ReplayAsync(model.MapToReplyModel());

                    if (result.Success)
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
                            return ReturnJson(result, model);
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

        /*
        [HttpGet("{Culture}/[Area]/[controller]/new")]
        public virtual async Task<ActionResult> CreatEmail()
        {
            ViewBag.SpecificUser = false;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            GetUsersModel model = new GetUsersModel();
            EmailVM EmailMD = new EmailVM();
            ViewBag.UsersList = new List<SelectListItem> { };
            var result = await _IdentityService.GetUsersAsync(model);
             
            if (result.Success)
            {
                ViewBag.UsersList = result.Data != null ? result.Data.Select(m => m.MapToUserModelByEmail()).ToList() : new List<SelectListItem>();
            }

            return View("CreateEmail", EmailMD );
        }

        public ViewResult GetViewNewEmailStartup(string username, List<string> emails)
        {
                ViewBag.SpecificUser = true;
                EmailVM EmailMD = new EmailVM();
                EmailMD.Recipients = emails; ;

                ViewBag.username = username;
                ViewBag.email = emails[0];
                return View("CreateEmail", EmailMD);
        }
         
        [HttpGet("{Culture}/[Area]/[controller]/new/{username}/{email}")]
        public virtual ActionResult NewEmail(string username , string email ,string bt)
        {
            ViewBag.route = bt;
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(email))
            {
                return GetViewNewEmailStartup(username, new List<string> { email });
            }
            return View();
        }
         
        // POST: Email/Create
        [HttpPost("{Culture}/[Area]/[controller]/create")]  
        public virtual async Task<ActionResult> Create(EmailVM model ,string bt ,string na, IFormCollection collection)
        {
            var count = model.Recipients.Count;
            // string backToController = Request.Query["bt"].ToString();//collection.ContainsKey("save-continue")
            string backToController = collection["route"];
                    Dictionary<string, bool> results = new Dictionary<string, bool>();
            if (ModelState.IsValid)
            {
                try
                {
                    foreach ( var email  in model.Recipients)
                    {

                        results.Add(email,
                                     await _EmailService.SendAsync(new EmailModel
                                     {
                                         Email = email,
                                         Subject = model.Subject,
                                         HtmlMessage = model.Message,
                                         Message = Regex.Replace(model.Message, "<.*?>", String.Empty),
                                         ReasonOfSend = "MessageByWebAdminPanel"
                                     }));

                    }
                }
                catch (Exception ex )
                {
                    TrackException(ex);
                    return View("Error");

                }

                

                if (string.IsNullOrWhiteSpace(backToController))
                {
                    return RedirectToAction(nameof(CreatEmail)); 
                }
                else
                {
                    bool resultValue;
                     
                    if (count == 1 && results.TryGetValue( model.Recipients[0], out resultValue))
                    {
                        if (resultValue)
                        { TempData["showSuccessAlert"] = true; }
                        else
                        { TempData["showFailedAlert"] = true; }

                        TempData["username"] = model.UserName;
                        TempData["subject"] = model.Subject;
                    }

                    return RedirectToAction("Index", backToController);
                }
            }
          
            return GetViewNewEmailStartup(model.UserName, model.Recipients);


        }


    */

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