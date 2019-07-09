using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Utilities.Settings;
using TamTech.Monshaat.POS.Web.Services.ContentService.Statistics;
using TamTech.Monshaat.POS.Web.Services.ContentService.Statistics.Models;

namespace TamTech.Monshaat.POS.Web.Services.APIsServices.Utilities
{
    public class UtilitiesService : BaseAPIService, IStatisticsService
    {

        #region Props 
        private readonly IRequestProvider _requestProvider;

        private readonly IUtilitiesApiSettings _apiSettings;
        #endregion


        public UtilitiesService(IRequestProvider requestProvider, IUtilitiesApiSettings apiSettings) : base(requestProvider)
        {
            _requestProvider = requestProvider;
            _apiSettings = apiSettings;
        }

        public async Task<IRequestProviderResult<StatisticsDto>> GetContactUsNumericalStatisticsByStatusAsync(string lang)
        {
            return await _requestProvider.GetAsync<StatisticsDto, List<object>>(_apiSettings.GetContactUsNumericalStatisticsByStatusEndpoint, new List<object> { lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<StatisticsDto>> GetContactUsNumericalStatisticsByTypeAsync(string lang)
        {
            return await _requestProvider.GetAsync<StatisticsDto, List<object>>(_apiSettings.GetContactUsNumericalStatisticsByTypeEndpoint, new List<object> { lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<StatisticsDto>> GetPOSNumericalStatisticsBySectorAsync(string lang)
        {
            return await _requestProvider.GetAsync<StatisticsDto, List<object>>(_apiSettings.GetPOSNumericalStatisticsBySectorEndpoint, new List<object> { lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<StatisticsDto>> GetPOSNumericalStatisticsByStatusAsync(string lang)
        {
            return await _requestProvider.GetAsync<StatisticsDto, List<object>>(_apiSettings.GetPOSNumericalStatisticsByStatusEndpoint, new List<object> { lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<StatisticsDto>> GetPOSNumericalStatisticsByTypeAsync(string lang)
        {
            return await _requestProvider.GetAsync<StatisticsDto, List<object>>(_apiSettings.GetPOSNumericalStatisticsByTypeEndpoint, new List<object> { lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<StatisticsDto>> GetVendorNumericalStatisticsByStatusAsync(string lang)
        {
            return await _requestProvider.GetAsync<StatisticsDto, List<object>>(_apiSettings.GetVendorNumericalStatisticsByStatusEndpoint, new List<object> { lang }, PassParamsBy.Route);
        }
    }
}
