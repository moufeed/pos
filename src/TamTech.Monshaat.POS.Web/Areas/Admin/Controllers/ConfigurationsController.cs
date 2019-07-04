using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Services.ContentService.Settings;
using TamTechSDK.Web.Services.Telemetry;

namespace TamTechSDK.Web.Controllers.Admin
{
    public class ConfigurationsController : AdminBaseController
    {

        private readonly ISettingService _settingsServices;
        private readonly IStringLocalizer<AdminBaseController> _localizer;
        public ConfigurationsController(ITelemetryService telemetryClientService,
            IStringLocalizer<AdminBaseController> localizer,
            ISettingService settingsServices
            ) : base(telemetryClientService, localizer)
        {
            _settingsServices = settingsServices;
            _localizer = localizer;
        }



        [HttpGet("{Culture}/[Area]/[Controller]")]
        public virtual async Task<IActionResult> Index()
        {
            try
            {
                var settings = await _settingsServices.GetByGroupIdAsync((int)SettingGroupEnum.General);

                return View(settings);
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View();
        }

        [HttpPost("{Culture}/[Area]/[Controller]/[Action]/{id}")]
        public virtual async Task<JsonResult> Post(string id)
        {
            ViewBag.Post = $"Posted successfully{id}";
            return Json(new { result = $"Posted successfully{id}" });
        }


        //[HttpGet("{Culture}/[Area]/[Controller]/[Action]")]
        //public virtual async Task<IActionResult> Biography()
        //{
        //    SiteInformationVm model = new SiteInformationVm();
        //    model.SocailMedia = BiographyMapper.DefulatSocailMedia();
        //    try
        //    {
        //        var settings = await _settingsServices.GetByGroupIdAsync((int)BiogrphyGroupEnum.Biography, GetCurrentDataLang());

        //        return View(settings != null ? settings.MapTOSiteInformationVm() : model);
        //    }
        //    catch (Exception ex)
        //    {
        //        TrackException(ex);
        //    }
        //    return View(model);
        //}

        //[HttpPost("{Culture}/[Area]/[Controller]/[Action]")]
        //public virtual async Task<IActionResult> Biography(SiteInformationVm model, IFormCollection collection)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            UpdateBiographyModel data = new UpdateBiographyModel
        //            {
        //                GroupId = (int)BiogrphyGroupEnum.Biography,
        //                Lang = GetCurrentDataLang(),
        //                Biographies = BiographyMapper.MapModelVmToListBiographyModel(model, (int)BiogrphyGroupEnum.Biography)
        //            };

        //            var request = await _settingsServices.EditAsync(data);


        //            if (request.Success)
        //            {
        //                TempData["UpdateDone"] = true;
        //                await _biographiesManager.ReloadInfoAsync();
        //                return View(model);
        //            }
        //            else
        //            {
        //                if (request.Messages != null)
        //                {
        //                    AddModelStateError(request.Messages);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        TrackException(ex);
        //    }
        //    return View(model);
        //}

    }
}
