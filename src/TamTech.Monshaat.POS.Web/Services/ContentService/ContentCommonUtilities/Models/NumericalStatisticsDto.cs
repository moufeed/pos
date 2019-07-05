using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.ContentCommonUtilities.Models
{
    public class NumericalStatisticsDto
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("publishedcount")]
        public int PublishedCount { get; set; }

        [JsonProperty("unpublishedcount")]
        public int UnpublishedCount { get; set; }
    }
}
