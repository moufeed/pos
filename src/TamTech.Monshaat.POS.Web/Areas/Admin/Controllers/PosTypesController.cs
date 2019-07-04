using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Services.TypesService;
using TamTechSDK.Web.Constants;
using TamTechSDK.Web.Services.Telemetry;

namespace TamTechSDK.Web.Controllers.Admin
{
    [Authorize(Policy = ContentSDKPoliciesConstants.POSTypesAdmin)]
    public class PosTypesController : BaseTypesController
    {
        public PosTypesController(ITelemetryService telemetryClientService, IStringLocalizer<AdminBaseController> localizer,
            IPosTypeService typeService) : base(telemetryClientService, localizer, typeService)
        {
        }
    }
}
