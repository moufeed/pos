using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.EFile2.Utilities.Services
{
    public interface IEFileIdentityProviderService
    {

        Task<bool> IsAuthenticatedAsync(string access_token);


        Task<string> GetUsernameByAccessTokenAsync(string access_token);


        string GetLoginUrl(string returnUrl = null);


        Task<bool> LogoutAsync(string access_token);

    }
}
