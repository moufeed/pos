using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Localization;
using TamTech.Monshaat.POS.Web.Services.ContentService.Attributes;
using TamTech.Monshaat.POS.Web.Services.ContentService.Values;
using TamTech.Monshaat.POS.Web.Core.Telemetry;

namespace TamTechSDK.Web.Controllers.Admin
{
    public class PosValuesController : BaseValuesController
    {
        public PosValuesController(ITelemetryService telemetryClientService, IStringLocalizer<AdminBaseController> localizer, IPosValuesService valuesServices, IPOSAttributeService attributesService) : base(telemetryClientService, localizer, valuesServices, attributesService)
        {
        }
    }
}
