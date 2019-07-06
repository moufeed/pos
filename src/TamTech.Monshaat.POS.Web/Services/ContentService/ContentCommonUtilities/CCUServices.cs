using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.ContentCommonUtilities.Models;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.ContentCommonUtilities
{
    public class CCUServices : ICCUServices
    {
         
        Task<IRequestProviderResult<Dictionary<string, NumericalStatisticsDto>>> ICCUServices.GetNumericalStatisticsAsync(List<string> types, string lang)
        {
            throw new NotImplementedException();
        }
    }
}
