using EFileServiceReference;
using System;
using System.Threading.Tasks; 
using TamTech.Monshaat.POS.MCI.EFile2.Services;
using TamTech.Monshaat.POS.MCI.EFile2.Settings; 

namespace TamTech.Monshaat.POS.Web.MinistryServices.EFile2
{
    public class EFileIdentityProviderService : IEFileIdentityProviderService
    {
        private readonly EFileServiceClient _client;
        private readonly EFileServiceModelSettings _settings;


        public EFileIdentityProviderService(EFileServiceModelSettings settings)
        {
            _settings = settings;
            _client = new EFileServiceClient();
        }

        public async Task<bool> IsAuthenticatedAsync(string access_token)
        {
            return await _client.IsAuthenticatedAsync(access_token, _settings.ClientId);
        }


        public async Task<string> GetUsernameByAccessTokenAsync(string access_token)
        {
            return await _client.GetUsernameByAccessTokenAsync(access_token);
        }


        public async Task<bool> LogoutAsync(string access_token)
        {
            if (string.IsNullOrWhiteSpace(access_token)) return true;
            return await _client.LogoutAsync(access_token);
        }

        public string GetLoginUrl(string returnUrl = null)
        {
            var rurl = string.IsNullOrWhiteSpace(returnUrl) ? "" : String.Format("&returnUrl={0}", returnUrl);
            return String.Format("{0}{1}?client_id={2}{3}", _settings.EFileUrl, _settings.LoginPath, _settings.ClientId, rurl);

        }

    }
}
