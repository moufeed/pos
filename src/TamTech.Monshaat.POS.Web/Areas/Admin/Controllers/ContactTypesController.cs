using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using TamTech.Monshaat.POS.Web.Services.ContentService.Types;
using TamTech.Monshaat.POS.Web.Core.Attributes;
using TamTech.Monshaat.POS.Web.Core.Constants;
using TamTechSDK.Web.Controllers.Admin;
using TamTech.Monshaat.POS.Web.Core.Telemetry;

namespace TamTechSDK.Web.Controllers.Admin
{
    [Authorize(Policy = ContentSDKPoliciesConstants.ContactUsTypesAdmin)]
    [ControllerName("contact-types")]
    public class ContactTypesController : BaseTypesController
    {
        public ContactTypesController(ITelemetryService telemetryClientService,
            IStringLocalizer<AdminBaseController> localizer, IContactTypeService typeService)
            : base(telemetryClientService, localizer, typeService)
        {
        }
    }
}

