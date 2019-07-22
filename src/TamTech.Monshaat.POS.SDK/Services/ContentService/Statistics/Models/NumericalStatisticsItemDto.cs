using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Statistics.Models
{
    public class NumericalStatisticsItemDto
    {
        [JsonProperty("Count")]
        public int Count { get; set; }

        [JsonProperty("Key")]
        public object Key { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Options")]
        public string Options { get; set; }


       
    }
}
