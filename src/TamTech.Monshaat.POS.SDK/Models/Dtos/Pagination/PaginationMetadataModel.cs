using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Pagination
{
    public class PaginationMetadataModel
    {
        [JsonProperty("totalcount")]
        public int TotalCount { get; set; }

        [JsonProperty("pagesize")]
        public int PageSize { get; set; }

        [JsonProperty("pagenumber")]
        public string PageNumber { get; set; }

        [JsonProperty("totalpages")]
        public int TotalPages { get; set; }

        [JsonProperty("previouspage")]
        public bool PreviousPage { get; set; } = false;

        [JsonProperty("nextpage")]
        public bool NextPage { get; set; } = false;

         
    }
}