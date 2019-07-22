using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Attributes;   
using TamTech.Monshaat.POS.Web.SDK.Core.Telemetry;
using TamTech.Monshaat.POS.Web.SDK.Core.Constants;

namespace TamTechSDK.Web.Controllers.Admin
{
    [Authorize(Policy = PolicyConstants.POSAttributesAdmin)]
    public class PosAttributesController : BaseAttributesController
    {
        public PosAttributesController(ITelemetryService telemetryClientService, IStringLocalizer<BaseController> localizer,
            IPOSAttributeService attributeService) : base(telemetryClientService, localizer, attributeService)
        {
        }
    }
}
