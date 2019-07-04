using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Statistics.Models
{
    public class StatisticsDto
    {
        public List<NumericalStatisticsItemDto> Statistics { get; set; }

        public List<string> Labels { get; set; }
        public List<int> Data { get; set; }
    }
}
