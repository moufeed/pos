using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.DirectBackendServices.UtilitiesServices.Mapper;
using TamTech.Monshaat.POS.Web.Services.ContentService.Statistics;
using TamTech.Monshaat.POS.Web.Services.ContentService.Statistics.Models;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.UtilitiesServices
{
    public class DirectStatisticsService : BaseDirectService,IStatisticsService
    {
        private readonly TamTech.ContentService.Services.Statistics.IStatisticsService _statisticsService;


        private StatisticsDto MapResult(IEnumerable<TamTech.ContentService.Services.Statistics.Models.NumericalStatisticsItemDto> _data)
        {
            List<string> Labels = new List<string>();
            List<int> Data = new List<int>();
            return new StatisticsDto
            {
                Statistics = _data?.Select(m =>
                {
                    Labels.Add(m.Description);
                    Data.Add(m.Count);
                    return m.MapToFrontNumericalStatisticsItemDto();
                }).ToList(),
                Labels = Labels,
                Data = Data
            };
        }
        public DirectStatisticsService(TamTech.ContentService.Services.Statistics.IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }
        public async Task<IRequestProviderResult<StatisticsDto>> GetContactUsNumericalStatisticsByStatusAsync(string lang)
        {
            var result = await _statisticsService.GetContactUsNumericalStatisticsByStatusAsync(lang);
            return ReturnRequestProviderResult(MapResult(result));
        }

        public async Task<IRequestProviderResult<StatisticsDto>> GetContactUsNumericalStatisticsByTypeAsync(string lang)
        {
            var result = await _statisticsService.GetContactUsNumericalStatisticsByTypeAsync(lang);
            return ReturnRequestProviderResult(MapResult(result));
        }


        public async Task<IRequestProviderResult<StatisticsDto>> GetPOSNumericalStatisticsByStatusAsync(string lang)
        {
            var result = await _statisticsService.GetPOSNumericalStatisticsByStatusAsync(lang);
            return ReturnRequestProviderResult(MapResult(result));
        }

        public async Task<IRequestProviderResult<StatisticsDto>> GetPOSNumericalStatisticsBySectorAsync(string lang)
        {
            var result = await _statisticsService.GetPOSNumericalStatisticsBySectorAsync(lang);
            return ReturnRequestProviderResult(MapResult(result));
        }

        public async Task<IRequestProviderResult<StatisticsDto>> GetPOSNumericalStatisticsByTypeAsync(string lang)
        {
            var result = await _statisticsService.GetPOSNumericalStatisticsByTypeAsync(lang);
            return ReturnRequestProviderResult(MapResult(result));
        }

        public async Task<IRequestProviderResult<StatisticsDto>> GetVendorNumericalStatisticsByStatusAsync(string lang)
        {
            var result = await _statisticsService.GetVendorNumericalStatisticsByStatusAsync(lang);
            return ReturnRequestProviderResult(MapResult(result));
        }
    }
}
