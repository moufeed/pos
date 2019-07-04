using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TamTechSDK.Web.Services.Telemetry;
using TamTechSDK.Common.Services.Identity; 
using TamTechSDK.Web.Extensions;
using TamTechSDK.Web.Models;
using TamTechSDK.Web.Constants;
using Microsoft.AspNetCore.Http;
using TamTechSDK.Common.Services.Upload;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Services.ContentService;
using TamTechSDK.Common.Services.ContentService.Contact;
using TamTechSDK.Common.Models.Filter;
using TamTechSDK.Common.Services.Utilities;
using TamTech.Monshaat.POS.Web.Core.Settings.Utilities;

namespace TamTechSDK.Web.Controllers.Admin
{

    [Area("Admin")]
    [Authorize(Policy = ContentSDKPoliciesConstants.DashboardAdmin)]
    public class HomeController : AdminBaseController
    {

        #region Props  
        private readonly SettingsHelpers _settingsHelpers;
        private readonly IUsersManagerService _identityService; 
        private readonly IContactService _contactService;
        private readonly IContentServices _contentServices;
        private readonly IStatisticsService _statisticsService;
        IUploadManagerService _uploadManager;

        #endregion

        #region Ctors  
        public HomeController(ITelemetryClientService telemetryClientService,
            SettingsHelpers settingsHelpers,
             IUploadManagerService uploadManager,
             IStringLocalizer<AdminBaseController> localizer,
             IContentServices contentServices,
             IContactService contactService,
             IStatisticsService statisticsService)
            : base(telemetryClientService, localizer)
        {
            _settingsHelpers = settingsHelpers;
            _uploadManager = uploadManager;
            _contentServices = contentServices;
            _contactService = contactService;
            _statisticsService = statisticsService;
        }
        #endregion




        public virtual async Task<IActionResult> Index()
        {

            Dictionary<string, object> searchParams = new Dictionary<string, object>();
            searchParams.Add("StatusId", 1);
            try
            {
                var _lang = GetCurrentDataLang();
                ViewBag.POSByStatus = await _statisticsService.GetPOSNumericalStatisticsByStatusAsync(_lang);
                ViewBag.POSBySector = await _statisticsService.GetPOSNumericalStatisticsBySectorAsync(_lang);
                ViewBag.POSByType = await _statisticsService.GetPOSNumericalStatisticsByTypeAsync(_lang);

                ViewBag.VendorByStatus = await _statisticsService.GetVendorNumericalStatisticsByStatusAsync(_lang);

                ViewBag.ContactUsByStatus = await _statisticsService.GetContactUsNumericalStatisticsByStatusAsync(_lang);
                ViewBag.ContactUsByType = await _statisticsService.GetContactUsNumericalStatisticsByTypeAsync(_lang);


                DTFilter filters = new DTFilter
                {
                    Lang = GetCurrentDataLang(),
                    PageSize = 25,
                    PageNumber = 1,
                    SortBy = "date_desc",
                    Descending = true,
                    Search = searchParams
                };
                var items = await _contactService.GetExceptSoftDeletedAsync(filters);
                ViewBag.Emails = items;
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            //  ViewBag.Host = _settingsHelpers.GetURlAsync();
            var types = await _settingsHelpers.GetNumericalStatisticsNamesAsync();
            var statistics = await _contentServices.GetNumericalStatisticsAsync(types, GetCurrentDataLang());
            ViewBag.statistics = statistics;

            return View();
        }


        [HttpGet]
        [Authorize]
        public virtual async Task<IActionResult> Token()
        {
            ViewBag.Enabled = _settingsHelpers.DisplayTokenInWebViewAsync();
            if (ViewBag.Enabled)
            {
                ViewBag.id_token = await HttpContext.GetTokenAsync("id_token");
                ViewBag.access_token = await HttpContext.GetTokenAsync("access_token");
                ViewBag.refresh_token = await HttpContext.GetTokenAsync("refresh_token");
            }
            return View();
        }
        [Authorize]
        public virtual async Task<IActionResult> About()
        {
            //GetLanguages();
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            //var result = await _identityService.GetUsersAsync(new GetUsersModel(), accessToken);
            //ViewBag.count = string.Format("List of Users Count : {0}", result.Data.Count());
            //PaginationMetadataModel pagination = (PaginationMetadataModel)result.Header;

            //var result = await _identityService.BlockUserAsyncEndpoint("test3");
            //  await _identityService.UnblockUserAsyncEndpoint("test3");

            //ViewBag.User = result.Success.ToString();


            //var GetUserResult = await _identityService.GetUserByUsernameAsync("test3", accessToken);
            //ViewBag.User = string.Format("NormalizedUserName  : {0}", GetUserResult.Data.NormalizedUserName);

            //RegisterUserModel newuser = new RegisterUserModel
            //{
            //    UserName = "a.aktaa.n",
            //    MobileNumber = "1234567890",
            //    Password = "P@ss123",
            //    RolesNames = new List<string> { "WhatcookSuperAdmin", "WhatcookUser" }
            //   // Email = "a.aktaa@tamtech.solutions"
            //};
            //var result = await _identityService.RegisterUserAsync(newuser, accessToken);
            //var sms =   new Solutions.Common.Services.SMS.Model.SMSModel {
            //     to = "76894834334",
            //     body = $"Reset password confirmation code ",
            //     properties =   new Dictionary<string, string> { { "ReasonOfSend", "ResetPasswordByMobileNumber" }, { "UserId","user id " } }
            // };


            // _iSMSSender.SendAsync(sms);


            //try
            //{
            //    throw new System.ArgumentException("TamTech.Solutions.Common.Services.Telemetry", "added by a.aktaa for test");
            //}
            //catch (Exception ex)
            //{
            //    TrackException(ex);
            //}

            return View();
        }
        public virtual void TrackException(Exception exc)
        {
            _telemetryClientService.TrackException(exc, new Dictionary<string, string>
                {
                    { TelemetryEventConstants.UserId, HttpContext.User.Identity.GetUserId() },
                    { TelemetryEventConstants.UserClientId, HttpContext.User.Identity.GetClientId() },
                    { TelemetryEventConstants.UserRoles, HttpContext.User.Identity.GetUserRolesCommaSeparated()}
                });
        }
        public virtual IActionResult Contact()
        {
            //GetLanguages();
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public virtual IActionResult Privacy()
        {
            return View();
        }

        public virtual IActionResult Biography()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public virtual IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public virtual async Task<JsonResult> UploadImage(IFormCollection collection)
        {
            var _collection = collection;
            var _files = _collection.Files;

            try
            {
                if (_files.Count > 0)
                {
                    var fileInfo = await GenerateFileInfo(_files[0]);
                    var upload_result = await _uploadManager.UploadFileAsync(fileInfo, FileTypesEnum.General);

                    if (upload_result.Success)
                    {
                        return Json(new { upload_result.URL });
                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return Json(new { });
        }
    }
}
