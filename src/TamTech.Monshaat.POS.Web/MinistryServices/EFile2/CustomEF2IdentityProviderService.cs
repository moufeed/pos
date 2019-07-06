using EFileServiceReference;
using System;
using System.Threading.Tasks; 
using TamTech.Monshaat.POS.EFile2.Utilities.Services;
using TamTech.Monshaat.POS.EFile2.Utilities.Settings; 

namespace TamTech.Monshaat.POS.Web.MinistryServices.EFile2
{
    public class CustomEF2IdentityProviderService : IEFileIdentityProviderService
    {
       
        public async Task<bool> IsAuthenticatedAsync(string access_token)
        {
            return true;
        }


        public async Task<string> GetUsernameByAccessTokenAsync(string access_token)
        {
            return TamTech.Monshaat.POS.Web.Core.Helpers.Helpers.Base64Decode(access_token);
        }


        public async Task<bool> LogoutAsync(string access_token)
        { 
             return  true;
        }

        public string GetLoginUrl(string returnUrl = null)
        {
            return "";

        }

         

    }
}
