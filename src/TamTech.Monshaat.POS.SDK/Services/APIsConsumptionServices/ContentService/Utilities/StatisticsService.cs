using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Utilities.Settings;
using TamTech.Monshaat.POS.Web.Services.ContentService.Statistics;
using TamTech.Monshaat.POS.Web.Services.ContentService.Statistics.Models;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Utilities
{
   public class StatisticsService : BaseAPIService, IStatisticsService
    {

        #region Props        
        private readonly IStatisticsApiSettings _apiSettings;
        #endregion



        public StatisticsService(IRequestProvider requestProvider, IStatisticsApiSettings apiSettings) : base(requestProvider)
        {           
            _apiSettings = apiSettings;
        }

        public StatisticsDto MapToStatisticsDto(IEnumerable<NumericalStatisticsItemDto> data)
        {
            if (data == null) return null;
            List<string> Labels = new List<string>();
            List<int> Data = new List<int>();
            return new StatisticsDto
            {
                Statistics = data?.Select(m =>
                {
                    Labels.Add(m.Description);
                    Data.Add(m.Count);
                    return m;
                }).ToList(),
                Labels = Labels,
                Data = Data
            };
        }
        public IRequestProviderResult<StatisticsDto> MapToStatisticsDto(IRequestProviderResult<IEnumerable<NumericalStatisticsItemDto>> result)
        {
           return new RequestProviderResult<StatisticsDto>
            {
                Data = MapToStatisticsDto(result.Data),
                Header = result.Header,
                JsonHeader = result.JsonHeader,
                Messages = result.Messages,
                StatusCode = result.StatusCode,
                Success = result.Success,
            };
        }


        public async Task<IRequestProviderResult<StatisticsDto>> GetContactUsNumericalStatisticsByStatusAsync(string lang)
        {
            var result = await ReqProvider.GetAsync<IEnumerable<NumericalStatisticsItemDto>, List<object>>(_apiSettings.GetContactUsNumericalStatisticsByStatusEndpoint, new List<object> { lang }, PassParamsBy.Route);
        return MapToStatisticsDto(result);


        }

        public async Task<IRequestProviderResult<StatisticsDto>> GetContactUsNumericalStatisticsByTypeAsync(string lang)
        {
            var result =  await ReqProvider.GetAsync<IEnumerable<NumericalStatisticsItemDto>, List<object>>(_apiSettings.GetContactUsNumericalStatisticsByTypeEndpoint, new List<object> { lang }, PassParamsBy.Route);
            return MapToStatisticsDto(result);
        }

        public async Task<IRequestProviderResult<StatisticsDto>> GetPOSNumericalStatisticsBySectorAsync(string lang)
        {
            var result = await ReqProvider.GetAsync<IEnumerable<NumericalStatisticsItemDto>, List<object>>(_apiSettings.GetPOSNumericalStatisticsBySectorEndpoint, new List<object> { lang }, PassParamsBy.Route);
            return MapToStatisticsDto(result);
        }

        public async Task<IRequestProviderResult<StatisticsDto>> GetPOSNumericalStatisticsByStatusAsync(string lang)
        {
            var result = await ReqProvider.GetAsync<IEnumerable<NumericalStatisticsItemDto>, List<object>>(_apiSettings.GetPOSNumericalStatisticsByStatusEndpoint, new List<object> { lang }, PassParamsBy.Route);
            return MapToStatisticsDto(result);
        }

        public async Task<IRequestProviderResult<StatisticsDto>> GetPOSNumericalStatisticsByTypeAsync(string lang)
        {
            var result = await ReqProvider.GetAsync<IEnumerable<NumericalStatisticsItemDto>, List<object>>(_apiSettings.GetPOSNumericalStatisticsByTypeEndpoint, new List<object> { lang }, PassParamsBy.Route);
            return MapToStatisticsDto(result);
        }

        public async Task<IRequestProviderResult<StatisticsDto>> GetVendorNumericalStatisticsByStatusAsync(string lang)
        {
            var result = await ReqProvider.GetAsync<IEnumerable<NumericalStatisticsItemDto>, List<object>>(_apiSettings.GetVendorNumericalStatisticsByStatusEndpoint, new List<object> { lang }, PassParamsBy.Route);
            return MapToStatisticsDto(result);
        }
    }
}
