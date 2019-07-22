using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TamTech.Monshaat.POS.MCI.EFile2.Services;
using TamTech.Monshaat.POS.MCI.EFile2.Utilities;

namespace TamTech.Monshaat.POS.MCI.EFile2.Controllers
{     
    public class OAuthController : Controller
    {
        private readonly IEFileIdentityProviderService _eFileService;
        private readonly IdentityUtilities _identityUtilities;

        public OAuthController(IEFileIdentityProviderService eFileService,
            IdentityUtilities posIdentityHelper)
        {
            _eFileService = eFileService;
            _identityUtilities = posIdentityHelper;
        }


        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> Index(string access_token, string returnUrl)
        {

            var isAuthenticated = await _eFileService.IsAuthenticatedAsync(access_token);
            if (isAuthenticated)
            {
                var result = await _identityUtilities.Signup(access_token);
                if (result)
                {
                    SetCookie(Constants.EFileTokenCookieName, access_token, Helpers.LogoutAfterMinutes);
                    var username = await _eFileService.GetUsernameByAccessTokenAsync(access_token);
                    if (await _identityUtilities.CheckAciveVendor(username))
                    {
                        return Redirect(Constants.POSUrl);
                    }
                    return RedirectToAction(Constants.RegisterAction, Constants.VendorController, new { Area = "Portal" });
                }
            }
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return Redirect("~/");
        }


        [Route("{culture}/portal/OAuth/login")]
        public async Task<IActionResult> Login(string returnUrl)
        {
            return View("~/Areas/Portal/Views/Vendor/Login.cshtml");
        }


        [Route("OAuth/Login")]
      //  [Route("{culture}/portal/OAuth/login")]
        public async Task<IActionResult> LoginDirect(string returnUrl)
        {
            if (string.IsNullOrWhiteSpace(returnUrl) || returnUrl.Equals("/"))
                returnUrl = "/";//$"/{DataCultureHelper.GetCurrent(Request.Query)}";

            var url = returnUrl;

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

