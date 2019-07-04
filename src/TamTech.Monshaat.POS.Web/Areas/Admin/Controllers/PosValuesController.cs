using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Services.Attributes;
using TamTechSDK.Common.Services.ValuesServices;
using TamTechSDK.Web.Services.Telemetry;

namespace TamTechSDK.Web.Controllers.Admin
{
    public class PosValuesController : BaseValuesController
    {
        public PosValuesController(ITelemetryClientService telemetryClientService, IStringLocalizer<AdminBaseController> localizer, IPosValuesService valuesServices, IPOSAttributeService attributesService) : base(telemetryClientService, localizer, valuesServices, attributesService)
        {
        }
    }
}
