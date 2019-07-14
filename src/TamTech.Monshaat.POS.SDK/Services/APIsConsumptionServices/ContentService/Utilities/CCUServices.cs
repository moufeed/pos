using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Utilities.Settings;
using TamTech.Monshaat.POS.Web.Services.ContentService.ContentCommonUtilities;
using TamTech.Monshaat.POS.Web.Services.ContentService.ContentCommonUtilities.Models;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Utilities
{
    public class CCUServices : BaseAPIService, ICCUServices
    {

        #region Props 
        private readonly IRequestProvider _requestProvider;

        private readonly ICCUApiSettings _apiSettings;
        #endregion


        public CCUServices(IRequestProvider requestProvider, ICCUApiSettings apiSettings) : base(requestProvider)
        {
            _requestProvider = requestProvider;
            _apiSettings = apiSettings;

        }
        public async  Task<IRequestProviderResult<Dictionary<string, NumericalStatisticsDto>>> GetNumericalStatisticsAsync(List<string> types, string lang)
        {
            CCUModel<List<string>> Data = new CCUModel<List<string>>()
            {
                Lang = lang,
                Types = types
            };
            return await _requestProvider.GetAsync<Dictionary<string, NumericalStatisticsDto>, CCUModel<List<string>>>(_apiSettings.GetNumericalStatisticsAsync, Data, PassParamsBy.Body);
        }
    }
}
