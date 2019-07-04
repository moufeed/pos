using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.UtilitiesServices.Mapper
{
    public static class StatisticsMapper
    {

        public static TamTech.Monshaat.POS.Web.Services.Utilities.Models.NumericalStatisticsItemDto MapToFrontNumericalStatisticsItemDto(this TamTech.ContentService.Services.Statistics.Models.NumericalStatisticsItemDto item)
        {
            return new TamTech.Monshaat.POS.Web.Services.Utilities.Models.NumericalStatisticsItemDto
            {
                Count = item.Count,
                Description = item.Description,
                Key = item.Key
            };
        }
    }
}
