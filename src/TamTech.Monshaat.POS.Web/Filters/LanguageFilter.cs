using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.Core.Settings.Utilities;

namespace TamTechSDK.Web.Filters
{


    public class AdminFilter : ActionFilterAttribute, IActionFilter
    {


        //private readonly IAppSettingsFile _appSettingsService;

        //public AdminFilter(  IAppSettingsFile appSettingsService)
        //{ 
        //    _appSettingsService = appSettingsService ;
        //}

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var controller = context.Controller as Controller;

            if (controller != null)
            {

                controller.ViewBag.AppVersion = SettingsHelpers.app_version; // _appSettingsService.GetVersion(); 
                //controller.ViewData["_lang"] = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
                //controller.ViewData["_culture"] = System.Globalization.CultureInfo.CurrentCulture.Name;
            }



        }
    }
}
