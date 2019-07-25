using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.MCI.Services.Models;
using TamTech.Monshaat.POS.MCI.Services.Settings;
using TamTech.Monshaat.POS.Web.SDK.Core.Extensions;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;          

namespace TamTech.Monshaat.POS.MCI.Services
{
    public class MCIServices : IMCIServices
    {
        #region Props     
        private readonly IRequestProvider _requestProvider;
        private readonly IMCIApiSettings _apiSettings;
        private readonly string _apiSecret;
        private const string _apiKey = "x-mcigateway-key";
        public readonly ILogger _logger;
        #endregion

        #region Ctors  
        public MCIServices(IRequestProvider requestProvider, IMCIApiSettings apiSettings, string apiSecret, ILogger<MCIServices> logger)   
        {
            _requestProvider = requestProvider;
            _apiSettings = apiSettings;
            _apiSecret = apiSecret;
            _logger =  logger;
        }
        #endregion


        public async Task<IRequestProviderResult<AuthenticateADResultModel>> AuthenticateByAD(ADUserModel model)
        {
            string username = null;
            try
            {
                username = model.Username;
                return await _requestProvider.PostAsync<AuthenticateADResultModel, ADUserModel>(_apiSettings.AuthenticateByAD, model,
                   new Dictionary<string, string> { { _apiKey, _apiSecret } });
            }
            catch (Exception ex)
            {
                _logger.LogException(ex,   $"username : {username}");
                throw;
            }
        }
             
        public async Task<IRequestProviderResult<PersonsOfCRResultModel>> GetAllPersonsForCR(GetAllPersonsForCRModel model)
        {
            try
            {
                return await _requestProvider.PostAsync<PersonsOfCRResultModel, GetAllPersonsForCRModel>(_apiSettings.GetAllPersonsForCR, model,
                  new Dictionary<string, string> { { _apiKey, _apiSecret } });

            }
            catch (Exception ex)
            {
                _logger.LogException(ex, model);
                throw;
            }
        }

        public async Task<IRequestProviderResult<BaseResultModel>> SendEmail(SendEmailModel model)
        {
            try
            {
                return await _requestProvider.PostAsync<BaseResultModel, SendEmailModel>(_apiSettings.SendEmail, model,
                  new Dictionary<string, string> { { _apiKey, _apiSecret } });
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, model);
                throw;
            }

        }
    }
}
