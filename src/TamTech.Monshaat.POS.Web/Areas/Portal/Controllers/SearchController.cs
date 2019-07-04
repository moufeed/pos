using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Web.Services.Telemetry;

namespace TamTechSDK.Web.Controllers.Portal
{
    public class SearchController : PublicBaseController
    {
        public SearchController(ITelemetryService telemetryClientService)
            : base(telemetryClientService)
        {
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
