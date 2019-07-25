using EFileServiceReference;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.MCI.EFile2.Services;
using TamTech.Monshaat.POS.MCI.EFile2.Settings;
using TamTech.Monshaat.POS.Web.SDK.Core.Extensions;

namespace TamTech.Monshaat.POS.Web.MinistryServices.EFile2
{
    public class EFileIdentityProviderService : IEFileIdentityProviderService
    {
        #region Props  
        private readonly EFileServiceClient _client;
        private readonly EFileServiceModelSettings _settings;
        public readonly ILogger _logger;
        #endregion

        #region Ctors  
        public EFileIdentityProviderService(EFileServiceModelSettings settings, ILogger<EFileIdentityProviderService> logger)
        {
            _settings = settings;
            _client = new EFileServiceClient();
            _logger = logger;
        }
        #endregion
        public async Task<bool> IsAuthenticatedAsync(string access_token)
        {
            try
            {
                return await _client.IsAuthenticatedAsync(access_token, _settings.ClientId);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, access_token);
                throw;
            }
        }


        public async Task<string> GetUsernameByAccessTokenAsync(string access_token)
        {
            try
            {
                return await _client.GetUsernameByAccessTokenAsync(access_token);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, access_token);
                throw;
            }
        }


        public async Task<bool> LogoutAsync(string access_token)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(access_token)) return true;
                return await _client.LogoutAsync(access_token);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, access_token);
                throw;
            }
        }

        public string GetLoginUrl(string returnUrl = null)
        {
            try
            {

                var rurl = string.IsNullOrWhiteSpace(returnUrl) ? "" : String.Format("&returnUrl={0}", returnUrl);
                return String.Format("{0}{1}?client_id={2}{3}", _settings.EFileUrl, _settings.LoginPath, _settings.ClientId, rurl);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, returnUrl);
                throw;
            }
        }

    }
}
