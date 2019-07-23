using Microsoft.AspNetCore.Mvc;     
using System.Collections.Generic;    
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Core.Biographies;      
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Slugs;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Shared.Biography;

namespace TamTech.Monshaat.POS.Web.Areas.Portal.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        IBiographiesManager _biographiesManager;


        public HeaderViewComponent(IBiographiesManager biographiesManager)
        {
            _biographiesManager = biographiesManager;
        }
        public async Task<IViewComponentResult> InvokeAsync(List<SlugModel> Slugs  = null)
        {
            /*  ViewBag.IsLoogedIn = User.Identity.IsAuthenticated &&
            SettingsHelpers.VendorRoleName.Equals(User.Identity.GetUserRolesCommaSeparated(), StringComparison.InvariantCultureIgnoreCase);
            */
            BiographyInfoVm biographiesInfo = await _biographiesManager.GetInfoAsync() ;
            ViewBag.BiographyLogo = biographiesInfo.Logo;

            return View("~/Areas/Portal/Views/Shared/Components/Header/Default.cshtml",Slugs);
        }
    }
}
 