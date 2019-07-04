using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks; 
using TamTech.Monshaat.POS.Web.Services.ContentService.ContentService.Models;

namespace TamTech.Monshaat.POS.Web.Services.ContentService
{
   public interface IContentServices
    {
         

        Task<Dictionary<string, NumericalStatisticsDto>> GetNumericalStatisticsAsync(List<string> types, string lang);

    }
}
