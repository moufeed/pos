using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Slugs; 

namespace TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Pagination
{
    public class PagedResultModel<TCollection>
    {
        [JsonProperty("data")]
        public TCollection Data { get; set; }

        [JsonProperty("pagination")]
        public PaginationMetadataModel Pagination { get; set; }

        [JsonProperty("sectionsslugs")]
        public List<SlugModel> SectionsSlugs { get; set; }
    }
}
