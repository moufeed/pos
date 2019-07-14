    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc;              
using Microsoft.AspNetCore.Http;
using TamTech.Monshaat.POS.EFile2.Utilities.Services;    

namespace TamTech.Monshaat.POS.EFile2.Utilities.Controllers
{
    // For the POS 
    
    public class OAuthController : Controller
    {
        private readonly IEFileIdentityProviderService _eFileService;    
        private readonly IdentityUtilities _identityUtilities;  

        public OAuthController(IEFileIdentityProviderService eFileService,
            IdentityUtilities posIdentityHelper )  
        {
            _eFileService = eFileService;
            _identityUtilities = posIdentityHelper;       
        }


        [HttpGet]
        [Route("[controller]")]
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
            await HttpContext.SignOutAsync(); 
            string token = Request.Cookies[Constants.EFileTokenCookieName];
            if (!string.IsNullOrWhiteSpace(token))
            {
                await _eFileService.LogoutAsync(token);
            }

            RemoveCookie(Constants.EFileTokenCookieName);

            if (string.IsNullOrWhiteSpace(returnUrl) || returnUrl.Equals("/"))
                returnUrl = "~/";

            return Redirect(returnUrl);

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

  