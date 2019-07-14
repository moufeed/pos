using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using TamTech.Monshaat.POS.Web.Services.ContentService.Types;
using TamTech.Monshaat.POS.Web.Core.Constants;
using TamTech.Monshaat.POS.Web.Core.Telemetry;

namespace TamTechSDK.Web.Controllers.Admin
{
   // [Authorize(Policy = ContentSDKPoliciesConstants.POSTypesAdmin)]
    public class PosTypesController : BaseTypesController
    {
        public PosTypesController(ITelemetryService telemetryClientService, IStringLocalizer<BaseController> localizer,
            IPosTypeService typeService) : base(telemetryClientService, localizer, typeService)
        {
        }
    }
}
