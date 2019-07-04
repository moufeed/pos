using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using TamTech.Monshaat.POS.EFile2.Utilities; 
using IdentityServer4.Services; 
using Microsoft.AspNetCore.Identity;  
using TamTechBackendSDK.IdentityService.Models;
using IdentityServer4.Quickstart.UI;
using TamTechBackendSDK.Common.Extensions;  
using Microsoft.AspNetCore.Http;
using TamTech.Monshaat.POS.EFile2.Utilities.Services;
using TamTech.Monshaat.POS.EFile2.Utilities.Filters;
using System.Security.Principal;

namespace TamTech.Monshaat.POS.EFile2.Utilities.Controllers
{
    // For the POS 
    [Route("[controller]")]
    public class OAuthController : Controller
    {
        private readonly IEFileIdentityProviderService _eFileService; 
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;  
        private readonly IdentityUtilities _identityUtilities;  

        public OAuthController(IEFileIdentityProviderService eFileService,
            IdentityUtilities posIdentityHelper,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager )  
        {
            _eFileService = eFileService;
            _identityUtilities = posIdentityHelper; 
            _userManager = userManager;
            _signInManager = signInManager;  
        }


        [HttpGet]
        public async Task<IActionResult> Index(string access_token, string returnUrl)
        {
            var isAuthenticated = await _eFileService.IsAuthenticatedAsync(access_token);
            if(isAuthenticated)
            {
                var result = await _identityUtilities.Signup(access_token); 
                if(result)
                {
                    SetCookie( Constants.EFileTokenCookieName, access_token, Helpers.LogoutAfterMinutes); 
                  var username =await _eFileService.GetUsernameByAccessTokenAsync(access_token); 
                    if (await _identityUtilities.CheckAciveVendor(username))
                    {
                        return Redirect(Constants.POSUrl);
                    }
                }
            }
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            //if (!String.IsNullOrWhiteSpace($"{returnUrl}?isAuthenticated={isAuthenticated}"))
            //    return Redirect(returnUrl);
            return Redirect("~/"); 
        }




        /// <summary>  
        /// set the cookie  
        /// </summary>  
        /// <param name="key">key (unique indentifier)</param>  
        /// <param name="value">value to store in cookie object</param>  
        /// <param name="expireTime">expiration time</param>  
        public void SetCookie(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();

            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMinutes(10);

            Response.Cookies.Append(key, value, option);
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



//[HttpGet("Login")]
//[SecurityHeaders]
//public async Task<IActionResult> Login(string returnUrl)
//{
//    //ViewBag.Token = await HttpContext.GetTokenAsync("access_token");
//    //ViewBag.Id = HttpContext.User.Identity.GetUserId();
//    //var claims = HttpContext.User.Identity.GetClaims();

//    if (string.IsNullOrWhiteSpace(returnUrl) || returnUrl.Equals("/"))
//        returnUrl = $"/{DataCultureHelper.GetCurrent(Request.Query)}";
//    var url = returnUrl;
//    //   <<<<<<<<<<<<<<<< check is already authenticated!   >>>>>>>>>>>>>>>>>>
//    var userId = HttpContext.User.Identity.GetUserId();
//   if (string.IsNullOrWhiteSpace(userId))
//    {
//          url = _eFileService.GetLoginUrl(returnUrl);
//    } 
//    return Redirect(url);
//}
