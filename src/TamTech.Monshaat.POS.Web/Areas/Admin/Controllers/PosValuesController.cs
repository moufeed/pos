using Microsoft.AspNetCore.Authorization;         
using Microsoft.Extensions.Localization;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Attributes;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Values;
using TamTech.Monshaat.POS.Web.SDK.Core.Telemetry;
using TamTech.Monshaat.POS.Web.SDK.Core.Constants;

namespace TamTechSDK.Web.Controllers.Admin
{
    [Authorize(Policy = PolicyConstants.POSAttributesAdmin)]
    public class PosValuesController : BaseValuesController
    {
        public PosValuesController(ITelemetryService telemetryClientService, IStringLocalizer<BaseController> localizer, IPosValuesService valuesServices, IPOSAttributeService attributesService) : base(telemetryClientService, localizer, valuesServices, attributesService)
        {
        }
    }
}
