using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Content.Mapper
{
    public static class ContentMapper
    {

        public static TamTech.Monshaat.POS.Web.Services.ContentService.ContentService.Models.NumericalStatisticsDto MapToFrontEndNumericalStatisticsDto(this TamTech.ContentService.Services.Content.Models.NumericalStatisticsDto item)
        {
            return new TamTech.Monshaat.POS.Web.Services.ContentService.ContentService.Models.NumericalStatisticsDto
            {
                Count = item.Count,
                PublishedCount = item.PublishedCount,
                UnpublishedCount = item.UnpublishedCount

            };
        }

    }
}
