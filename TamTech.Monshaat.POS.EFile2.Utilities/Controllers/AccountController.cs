using IdentityServer4.Quickstart.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.EFile2.Utilities;
using TamTech.Monshaat.POS.EFile2.Utilities.Services;
using TamTechBackendSDK.Common.Extensions;
using TamTechBackendSDK.IdentityService.Models;  

namespace TamTech.Monshaat.POS.EFile2.Utilities.Controllers
{
    public class AccountController : Controller
    {
        private readonly IEFileIdentityProviderService _eFileService;
        private readonly UserManager<ApplicationUser> _userManager; 
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(IEFileIdentityProviderService eFileService,
                                    UserManager<ApplicationUser> userManager,
                                    SignInManager<ApplicationUser> signInManager
                                    )
        {
            _eFileService = eFileService;
            _userManager = userManager;
            _signInManager = signInManager;
        }



       
        [Route("OAuth/Login")]
        [Route("{culture}/portal/OAuth/login")]
        public async Task<IActionResult> Login(string returnUrl)
        {
            if (string.IsNullOrWhiteSpace(returnUrl) || returnUrl.Equals("/"))
                returnUrl = "/";//$"/{DataCultureHelper.GetCurrent(Request.Query)}";

            var url = returnUrl; 

           // var userId = HttpContext.User.Identity.GetUserId();



            if (!User.Identity.IsAuthenticated)
            {
                url = _eFileService.GetLoginUrl(returnUrl);
            }
            return Redirect(url);
        }

      

        [HttpGet("OAuth/Logout")]
        [Route("{culture}/portal/OAuth/Logout")]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            //var userId =  HttpContext.User.Identity.GetUserId();
            //  var user = await _userManager.FindByIdAsync(HttpContext.User.Identity.GetUserId()); 
            await _signInManager.SignOutAsync();
            string token = Request.Cookies[Constants.EFileTokenCookieName];
            if (!string.IsNullOrWhiteSpace(token))
            {
                await _eFileService.LogoutAsync(token);
            }
           
            RemoveCookie( Constants.EFileTokenCookieName);

            if (string.IsNullOrWhiteSpace(returnUrl) || returnUrl.Equals("/"))
                returnUrl = "~/";

            return Redirect(returnUrl);

        }

        /// <summary>  
        /// Delete the key  
        /// </summary>  
        /// <param name="key">Key</param>  
        public void RemoveCookie(string key)
        {
            Response.Cookies.Delete(key);
        }
    }
}
//ViewBag.Token = await HttpContext.GetTokenAsync("access_token");
//ViewBag.Id = HttpContext.User.Identity.GetUserId();
//var claims = HttpContext.User.Identity.GetClaims();
