using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;    
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Core.Biographies;
using TamTech.Monshaat.POS.Web.SDK.Core.Extensions;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Slugs;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Shared.Biography;

namespace TamTech.Monshaat.POS.Web.Areas.Portal.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        
        public readonly IBiographiesManager _biographiesManager;
        public readonly ILogger _logger;


        public HeaderViewComponent(IBiographiesManager biographiesManager, ILogger<HeaderViewComponent> logger)
        {
            _biographiesManager = biographiesManager;
            _logger = logger;
        }
        public async Task<IViewComponentResult> InvokeAsync(List<SlugModel> Slugs  = null)
        {
            /*  ViewBag.IsLoogedIn = User.Identity.IsAuthenticated &&
            SettingsHelpers.VendorRoleName.Equals(User.Identity.GetUserRolesCommaSeparated(), StringComparison.InvariantCultureIgnoreCase);
            */
            try
            {
                BiographyInfoVm biographiesInfo = await _biographiesManager.GetInfoAsync();
                ViewBag.BiographyLogo = biographiesInfo.Logo;
            }
            catch(Exception ex)
            {
                _logger.LogException(ex, Slugs);
            }

            return View("~/Areas/Portal/Views/Shared/Components/Header/Default.cshtml",Slugs);
        }
    }
}
 