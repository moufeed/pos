using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Models.VMs.Shared.SEO
{
    public class ProductSEO : SeoSchema
    {

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("Category")]
        public List<string> Category { get; set; }
    }
}
