using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.DirectBackendServices.UtilitiesServices.Mapper;
using TamTechSDK.Common.Services.Utilities;
using TamTechSDK.Common.Services.Utilities.Models;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.UtilitiesServices
{
    public class DirectStatisticsService : IStatisticsService
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
        public async Task<StatisticsDto> GetContactUsNumericalStatisticsByStatusAsync(string lang)
        {
            var result = await _statisticsService.GetContactUsNumericalStatisticsByStatusAsync(lang);
            return MapResult(result);
        }

        public async Task<StatisticsDto> GetContactUsNumericalStatisticsByTypeAsync(string lang)
        {
            var result = await _statisticsService.GetContactUsNumericalStatisticsByTypeAsync(lang);
            return MapResult(result);
        }


        public async Task<StatisticsDto> GetPOSNumericalStatisticsByStatusAsync(string lang)
        {
            var result = await _statisticsService.GetPOSNumericalStatisticsByStatusAsync(lang);
            return MapResult(result);
        }

        public async Task<StatisticsDto> GetPOSNumericalStatisticsBySectorAsync(string lang)
        {
            var result = await _statisticsService.GetPOSNumericalStatisticsBySectorAsync(lang);
            return MapResult(result);
        }

        public async Task<StatisticsDto> GetPOSNumericalStatisticsByTypeAsync(string lang)
        {
            var result = await _statisticsService.GetPOSNumericalStatisticsByTypeAsync(lang);
            return MapResult(result);
        }

        public async Task<StatisticsDto> GetVendorNumericalStatisticsByStatusAsync(string lang)
        {
            var result = await _statisticsService.GetVendorNumericalStatisticsByStatusAsync(lang);
            return MapResult(result);
        }
    }
}
