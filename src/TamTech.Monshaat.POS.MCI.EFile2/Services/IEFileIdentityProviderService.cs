using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.MCI.EFile2.Services
{
    public interface IEFileIdentityProviderService
    {

        Task<bool> IsAuthenticatedAsync(string access_token);


        Task<string> GetUsernameByAccessTokenAsync(string access_token);


        string GetLoginUrl(string returnUrl = null);


        Task<bool> LogoutAsync(string access_token);

    }
}
