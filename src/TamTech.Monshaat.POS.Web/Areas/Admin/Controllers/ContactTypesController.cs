using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Services.TypesService;
using TamTechSDK.Web.Attributes;
using TamTechSDK.Web.Constants;
using TamTechSDK.Web.Controllers.Admin;
using TamTechSDK.Web.Services.Telemetry;

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

