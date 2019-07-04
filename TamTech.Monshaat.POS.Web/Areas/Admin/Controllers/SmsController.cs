using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Services.Identity;
using TamTechSDK.Common.Services.Identity.Models.Params;
using TamTechSDK.Common.Services.ServiceBus;
using TamTechSDK.Common.Services.SMS;
using TamTechSDK.Common.Services.SMS.Models;
using TamTechSDK.Web.Constants;
using TamTechSDK.Web.Extensions;
using TamTechSDK.Web.Models.Admin.Sms;
using TamTechSDK.Web.Services.Configurations.Cultures;
using TamTechSDK.Web.Services.Telemetry;

namespace TamTechSDK.Web.Controllers.Admin
{
    [Authorize(Policy = ContentSDKPoliciesConstants.UsersAdmin)]
    public class SmsController : AdminBaseController
    {
        ServiceBusSettings _ServiceBusSettings;
        IUsersManagerService _IdentityService;
        ISMSService _SMSService;


        public SmsController(ITelemetryClientService telemetryClientService, ISMSService sMSService, IUsersManagerService IdentityService, ServiceBusSettings serviceBusSettings, IStringLocalizer<AdminBaseController> localizer) : base(telemetryClientService, localizer)
        {
            _IdentityService = IdentityService;
            _ServiceBusSettings = serviceBusSettings;
            _SMSService = sMSService;

        }





        // GET: Sms
        public virtual async Task<ActionResult> Index()
        {

            List<Smslite> SmsMD = new List<Smslite>();

            var result = await _SMSService.GetSmsMessages();
            if (result.Success)
            {

                return View("index", result.Data);
            }

            return View("index", SmsMD);
        }

        // GET: Sms/Details/5
        public virtual ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sms/Create
        public virtual async Task<ActionResult> CreateSms()
        {
            ViewBag.CharactersLength = _ServiceBusSettings.MaxCharactersLength;
            ViewBag.allowparts = _ServiceBusSettings.AllowMultiParts;
            ViewBag.SpecificUser = false;
            SmsVM SmsMD = new SmsVM();

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            GetUsersModel model = new GetUsersModel();

            var UsersList = new List<SelectListItem>();
            var users = await _IdentityService.GetUsersAsync(model);

            if (users.Success)
            {
                foreach (var user in users.Data)
                {
                    UsersList.Add(new SelectListItem
                    {
                        Text = user.UserName,
                        Value = user.MobileNumber
                    });

                }

                ViewBag.UsersList = UsersList;
            }



            return View("CreateSms");
        }



        [HttpGet("[Area]/[controller]/new/{username}/{number}")]
        public virtual ActionResult NewSms(string username, string number)
        {

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(number))
            {

                ViewBag.CharactersLength = _ServiceBusSettings.MaxCharactersLength;
                ViewBag.allowparts = _ServiceBusSettings.AllowMultiParts;
                ViewBag.SpecificUser = true;
                SmsVM SmsMD = new SmsVM();

                SmsMD.Recipients.Add(number);
                ViewBag.username = username;
                ViewBag.number = number;
                return View("CreateSms", SmsMD);

            }
            return View();


        }





        // POST: Sms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create(SmsVM model, IFormCollection Collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.Recipients.Count > 0)
                    {
                        foreach (var number in model.Recipients)
                        {
                            await _SMSService.SendAsync(new SMSModel
                            {
                                to = number,
                                body = model.Massage,
                                properties = new Dictionary<string, string> { { "ReasonOfSend", "MessageByWebAdminPanel" }, { "UserId", HttpContext.User.Identity.GetUserId() } }
                            });
                        };

                    }

                    // TODO: Add insert logic here

                    return RedirectToAction("Index", "Users");
                }
                catch
                {
                    return View("CreateSms");
                }
            }
            return View("CreateSms");

        }

        // GET: Sms/Edit/5
        public virtual ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sms/Edit/5
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

        // GET: Sms/Delete/5
        public virtual ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sms/Delete/5
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
    }
}