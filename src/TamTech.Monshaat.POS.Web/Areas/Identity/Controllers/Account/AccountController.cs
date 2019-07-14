 using Microsoft.AspNetCore.Mvc;    
using TamTech.Monshaat.POS.Web.Core.Filters;    

namespace TamTech.Monshaat.POS.Web.Areas.Identity.Controllers
{
    [Area("Identity")]
    [ServiceFilter(typeof(AdminFilter))]
    public class AccountController : TamTech.Monshaat.POS.IdentityService.Controllers.AccountController
    {

        public AccountController(TamTech.Monshaat.POS.IdentityService.Services.IAuthTamService authTamService) : base(authTamService)
        {
        }





        /// <summary>
        /// TODO: move it to the Identity SDK to have default implementation
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public IActionResult AccessDenied(string returnUrl = "")
        {
            return View();
        }

        public IActionResult Info(string returnUrl = "")
        {
            return View();
        }



        /// <summary>
        /// TODO: move it to the Identity SDK to have default implementation
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public IActionResult Blocked(string returnUrl = "")
        {
            return View();
        }
    }
}