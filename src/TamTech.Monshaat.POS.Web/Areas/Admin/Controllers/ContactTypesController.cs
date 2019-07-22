using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Types;
using TamTech.Monshaat.POS.Web.SDK.Core.Attributes;
using TamTech.Monshaat.POS.Web.SDK.Core.Constants;    
using TamTech.Monshaat.POS.Web.SDK.Core.Telemetry;

namespace TamTechSDK.Web.Controllers.Admin
{
    
    [Authorize(Policy = PolicyConstants.ContactUsTypesAdmin)]
    [ControllerName("contact-types")]
    public class ContactTypesController : BaseTypesController
    {
        public ContactTypesController(ITelemetryService telemetryClientService,
            IStringLocalizer<BaseController> localizer, IContactTypeService typeService)
            : base(telemetryClientService, localizer, typeService)
        {
        }
    }
}

