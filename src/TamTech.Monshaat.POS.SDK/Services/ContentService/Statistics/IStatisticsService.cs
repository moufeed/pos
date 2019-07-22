using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Statistics.Models;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Statistics
{
    public interface IStatisticsService
    {
        Task<IRequestProviderResult<StatisticsDto>> GetPOSNumericalStatisticsByStatusAsync(string lang);

        Task<IRequestProviderResult<StatisticsDto>> GetPOSNumericalStatisticsBySectorAsync(string lang);

        Task<IRequestProviderResult<StatisticsDto>> GetPOSNumericalStatisticsByTypeAsync(string lang);

        Task<IRequestProviderResult<StatisticsDto>> GetVendorNumericalStatisticsByStatusAsync(string lang);

        Task<IRequestProviderResult<StatisticsDto>> GetContactUsNumericalStatisticsByStatusAsync(string lang); 

        Task<IRequestProviderResult<StatisticsDto>> GetContactUsNumericalStatisticsByTypeAsync(string lang);
      
    }
}
