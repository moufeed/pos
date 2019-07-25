using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.SDK.Core.Cultures;
using TamTech.Monshaat.POS.Web.SDK.Core.Telemetry;

namespace TamTechSDK.Web.Controllers.Identity
{
    [Area("Identity")]
    public class IdentityBaseController : BaseController
    {
        #region Props   
        

        #endregion


        #region Ctors
        public IdentityBaseController(ITelemetryService telemetryClientService,
                 ILogger<IdentityBaseController> logger,
            IStringLocalizer<BaseController> localizer)
          : base(telemetryClientService , logger, localizer)
        {
            //  _helperService = helperService;
            ViewData["Area"] = "Admin";
        }



        public void AddErrorModel(string key = "Error", string msg = "General Error!!")
        {
            ModelState.AddModelError(key, msg);
        }

        public override void TrackException(Exception exc)
        {
            AddErrorModel("Exeption", exc.Message);
            base.TrackException(exc);
        }
        #endregion
    }
}
