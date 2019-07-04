using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Web.Models.Shared.SEO
{
    public class ProductSEO : SeoSchema
    {

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("Category")]
        public List<string> Category { get; set; }
    }
}
