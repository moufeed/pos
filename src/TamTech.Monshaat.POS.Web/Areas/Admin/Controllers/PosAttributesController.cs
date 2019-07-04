using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Services.Attributes;
using TamTechSDK.Web.Constants;
using TamTechSDK.Web.Services.Telemetry;

namespace TamTechSDK.Web.Controllers.Admin
{
    [Authorize(Policy = ContentSDKPoliciesConstants.POSAttributesAdmin)]
    public class PosAttributesController : BaseAttributesController
    {
        public PosAttributesController(ITelemetryService telemetryClientService, IStringLocalizer<AdminBaseController> localizer,
            IPOSAttributeService attributeService) : base(telemetryClientService, localizer, attributeService)
        {
        }
    }
}
