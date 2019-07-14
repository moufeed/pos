using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.Models.Dtos.Filter
{
    public class DTFilter
    {
        [JsonProperty("search")]
        public Dictionary<string, object> Search { get; set; }

        [JsonProperty("sortby")]
        public string SortBy { get; set; }

        [JsonProperty("descending")]
        public bool Descending { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("pagenumber")]
        public int PageNumber { get; set; } = 1;

        [JsonProperty("pagesize")]
        public int PageSize { get; set; } = 10;
    }
}
