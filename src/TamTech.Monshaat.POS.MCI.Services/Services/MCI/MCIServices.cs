using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.MCI.Services.Models;
using TamTech.Monshaat.POS.MCI.Services.Settings;
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
        #endregion


        #region Ctors
        public MCIServices(IRequestProvider requestProvider, IMCIApiSettings apiSettings, string apiSecret)   
        {
            _requestProvider = requestProvider;
            _apiSettings = apiSettings;
            _apiSecret = apiSecret;
        }
        #endregion


        public async Task<IRequestProviderResult<AuthenticateADResultModel>> AuthenticateByAD(ADUserModel model)
        {
            return await _requestProvider.PostAsync<AuthenticateADResultModel, ADUserModel>(_apiSettings.AuthenticateByAD, model,
               new Dictionary<string, string> { { _apiKey, _apiSecret } });
        }
             
        public async Task<IRequestProviderResult<PersonsOfCRResultModel>> GetAllPersonsForCR(GetAllPersonsForCRModel model)
        {
            return await _requestProvider.PostAsync<PersonsOfCRResultModel, GetAllPersonsForCRModel>(_apiSettings.GetAllPersonsForCR, model,
                  new Dictionary<string, string> { { _apiKey, _apiSecret } });
       
          
        }

        public async Task<IRequestProviderResult<BaseResultModel>> SendEmail(SendEmailModel model)
        {
            return await _requestProvider.PostAsync<BaseResultModel, SendEmailModel>(_apiSettings.SendEmail, model,
                  new Dictionary<string, string> { { _apiKey, _apiSecret } });


        }
    }
}
