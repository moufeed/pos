using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Types;
using TamTech.Monshaat.POS.Web.SDK.Core.Constants;
using TamTech.Monshaat.POS.Web.SDK.Core.Telemetry;

namespace TamTechSDK.Web.Controllers.Admin
{
   [Authorize(Policy = PolicyConstants.POSTypesAdmin)]
    public class PosTypesController : BaseTypesController
    {
        public PosTypesController(ITelemetryService telemetryClientService, IStringLocalizer<BaseController> localizer,
            IPosTypeService typeService) : base(telemetryClientService, localizer, typeService)
        {
        }
    }
}
