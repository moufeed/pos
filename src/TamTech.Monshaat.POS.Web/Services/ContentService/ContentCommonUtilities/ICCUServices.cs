using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks; 
using TamTech.Monshaat.POS.Web.Services.ContentService.ContentCommonUtilities.Models;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.ContentCommonUtilities
{
   public interface ICCUServices
    {
         

        Task<Dictionary<string, NumericalStatisticsDto>> GetNumericalStatisticsAsync(List<string> types, string lang);

    }
}
