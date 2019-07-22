using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TamTech.Monshaat.POS.Web.SDK.Core.Telemetry;
using TamTech.Monshaat.POS.Web.SDK.Services.Identity; 
using TamTech.Monshaat.POS.Web.SDK.Core.Extensions;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs;
using TamTech.Monshaat.POS.Web.SDK.Core.Constants;
using Microsoft.AspNetCore.Http;
using TamTech.Monshaat.POS.Web.SDK.Services.Upload;
using Microsoft.Extensions.Localization;     
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.ContactUs;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Statistics;
using TamTech.Monshaat.POS.Web.SDK.Core.Settings.Utilities;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.ContentCommonUtilities;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Statistics.Models;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.ContactUs.Models;
using TamTech.Monshaat.POS.Web.SDK.Core.Helpers;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.Upload.Models;

namespace TamTechSDK.Web.Controllers.Admin
{       
    [Authorize(Policy = PolicyConstants.DashboardAdmin)]
    public class HomeController : AdminBaseController
    {

        #region Props  
        private readonly SettingsHelpers _settingsHelpers;
        private readonly IUsersManagerService _identityService; 
        private readonly IContactService _contactService;
        private readonly ICCUServices _contentServices;
        private readonly IStatisticsService _statisticsService;
        IUploadManagerService _uploadManager;

        #endregion

        #region Ctors  
        public HomeController(ITelemetryService telemetryClientService,
            SettingsHelpers settingsHelpers,
             IUploadManagerService uploadManager,
             IStringLocalizer<BaseController> localizer,
             ICCUServices contentServices,
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


                var _p_status = await _statisticsService.GetPOSNumericalStatisticsByStatusAsync(_lang);
                ViewBag.POSByStatus = VerifySucceed(_p_status) ? _p_status.Data  : new StatisticsDto();
               

                var _p_sectors = await _statisticsService.GetPOSNumericalStatisticsBySectorAsync(_lang);
                ViewBag.POSBySector = VerifySucceed(_p_sectors) ? _p_sectors.Data : new StatisticsDto();


                var _p_type = await _statisticsService.GetPOSNumericalStatisticsByTypeAsync(_lang);
                ViewBag.POSByType = VerifySucceed(_p_type) ? _p_type.Data : new StatisticsDto();


                var _v_status = await _statisticsService.GetVendorNumericalStatisticsByStatusAsync(_lang);;
                ViewBag.VendorByStatus = VerifySucceed(_v_status) ? _v_status.Data : new StatisticsDto();


                var _c_status = await _statisticsService.GetContactUsNumericalStatisticsByStatusAsync(_lang);
                ViewBag.ContactUsByStatus = VerifySucceed(_c_status) ? _c_status.Data : new StatisticsDto();

                var _c_type = await _statisticsService.GetContactUsNumericalStatisticsByTypeAsync(_lang);
                ViewBag.ContactUsByType = VerifySucceed(_c_type) ? _c_type.Data : new StatisticsDto();


                DTFilter filters = new DTFilter
                {
                    Lang = GetCurrentDataLang(),
                    PageSize = 25,
                    PageNumber = 1,
                    SortBy = "date_desc",
                    Descending = true,
                    Search = searchParams
                };
                var Emails = await _contactService.GetExceptSoftDeletedAsync(filters);
                ViewBag.Emails = (VerifySucceed(Emails)) ? Emails.Data : new PagedResultModel<List<ContactDto>>();
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            //  ViewBag.Host = _settingsHelpers.GetURlAsync();
            var types = await _settingsHelpers.GetNumericalStatisticsNamesAsync();
            var statistics = (await _contentServices.GetNumericalStatisticsAsync(types, GetCurrentDataLang())).Data;
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
                    IRequestProviderResult<UploadedFileURL> upload_result = await _uploadManager.UploadFileAsync(fileInfo, FileTypesEnum.EditorImages);
                    if (upload_result.Success)
                    {
                        var result = new RequestProviderResult<UploadedFileURL>
                        {
                            Data = upload_result.Data,
                            Success = upload_result.Success,
                            Messages = upload_result.Messages,
                            StatusCode = upload_result.StatusCode,
                            Header = upload_result.StatusCode,
                            JsonHeader = upload_result.JsonHeader
                        };
                        string _url = Url.FileUrl(CommonConstants.ImgAction, new { img = Helpers.GetFileNameFromUrl(upload_result.Data.URL), type = FileTypesEnum.EditorImages });
                        result.Data.URL = _url;
                        return Json(result);
                    }
                   

                    return Json(upload_result);
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
