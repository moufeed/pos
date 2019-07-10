using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using TamTech.Monshaat.POS.Web.Services.ContentService.Attributes;
using TamTech.Monshaat.POS.Web.Core.Constants;
using TamTech.Monshaat.POS.Web.Core.Telemetry;

namespace TamTechSDK.Web.Controllers.Admin
{
    [Authorize(Policy = ContentSDKPoliciesConstants.POSAttributesAdmin)]
    public class PosAttributesController : BaseAttributesController
    {
        public PosAttributesController(ITelemetryService telemetryClientService, IStringLocalizer<BaseController> localizer,
            IPOSAttributeService attributeService) : base(telemetryClientService, localizer, attributeService)
        {
        }
    }
}
