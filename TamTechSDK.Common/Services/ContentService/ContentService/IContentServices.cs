using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.ContentService.Models;

namespace TamTechSDK.Common.Services.ContentService
{
   public interface IContentServices
    {

        Task<IRequestProviderResult<List<string>>> ProductHints();

        Task<IRequestProviderResult<List<KeyValuePair<Guid, string>>>> GetProductsNames();


        Task<Dictionary<string, NumericalStatisticsDto>> GetNumericalStatisticsAsync(List<string> types, string lang);

    }
}
