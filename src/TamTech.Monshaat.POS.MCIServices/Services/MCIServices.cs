using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.MCIServices.Models;
using TamTech.Monshaat.POS.MCIServices.Settings;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;          

namespace TamTech.Monshaat.POS.MCIServices
{
    public class MCIServices : IMCIADServices
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
    }
}
