using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using TamTech.Monshaat.POS.Web.Services.ContentService.Menus;
using TamTech.Monshaat.POS.Web.Core.Telemetry;

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
