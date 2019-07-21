using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Attributes;
using TamTech.Monshaat.POS.Web.SDK.Core.Constants;
using TamTech.Monshaat.POS.Web.SDK.Core.Telemetry;

namespace TamTechSDK.Web.Controllers.Admin
{
   // [Authorize(Policy = ContentSDKPoliciesConstants.POSAttributesAdmin)]
    public class PosAttributesController : BaseAttributesController
    {
        public PosAttributesController(ITelemetryService telemetryClientService, IStringLocalizer<BaseController> localizer,
            IPOSAttributeService attributeService) : base(telemetryClientService, localizer, attributeService)
        {
        }
    }
}
