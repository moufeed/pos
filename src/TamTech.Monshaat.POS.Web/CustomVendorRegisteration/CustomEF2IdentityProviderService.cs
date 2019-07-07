using EFileServiceReference;
using System;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using TamTech.Monshaat.POS.EFile2.Utilities.Services;
using Microsoft.AspNetCore.Http;
using TamTech.Monshaat.POS.EFile2.Utilities.Settings;
using TamTech.Monshaat.POS.Web.Core.Extensions;
using TamTech.Monshaat.POS.Web.CustomVendorRegisteration;

namespace TamTech.Monshaat.POS.Web.MinistryServices.EFile2
{
    public class CustomEF2IdentityProviderService : IEFileIdentityProviderService
    {
        private readonly HttpContext _httpContext;

        public CustomEF2IdentityProviderService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task<bool> IsAuthenticatedAsync(string access_token)
        {
            if (!_httpContext.User.IsAuthenticated() || string.IsNullOrWhiteSpace(access_token)) return false;
            var valid_access_token = CustomHelper.GenerateAccessToken(_httpContext.User.Identity.GetUserId(), _httpContext.User.Identity.GetUsername());
            return access_token.Equals(valid_access_token);


        }


        public async Task<string> GetUsernameByAccessTokenAsync(string access_token)
        {
        
            var username = CustomHelper.GetUsernameFromAccessToken(access_token);
            return username;
        }


        public async Task<bool> LogoutAsync(string access_token)
        { 
             return  true;
        }

        public string GetLoginUrl(string returnUrl = null)
        {
            var rurl = string.IsNullOrWhiteSpace(returnUrl) ? "" : String.Format("?returnUrl={0}", returnUrl);
           return    String.Format("~/identity/v/Account/Login{0}",  rurl); 

        }



        #region  utilities
 



        #endregion



    }
}
