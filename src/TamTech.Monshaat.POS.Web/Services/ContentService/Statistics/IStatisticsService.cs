using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Services.ContentService.Statistics.Models;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Statistics
{
    public interface IStatisticsService
    {
        Task<StatisticsDto> GetPOSNumericalStatisticsByStatusAsync(string lang);

        Task<StatisticsDto> GetPOSNumericalStatisticsBySectorAsync(string lang);

        Task<StatisticsDto> GetPOSNumericalStatisticsByTypeAsync(string lang);

        Task<StatisticsDto> GetVendorNumericalStatisticsByStatusAsync(string lang);

        Task<StatisticsDto> GetContactUsNumericalStatisticsByStatusAsync(string lang); 

        Task<StatisticsDto> GetContactUsNumericalStatisticsByTypeAsync(string lang);
      
    }
}
