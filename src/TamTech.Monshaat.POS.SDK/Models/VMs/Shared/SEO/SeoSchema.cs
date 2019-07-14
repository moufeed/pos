using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Models.VMs.Shared.SEO
{
    public class SeoSchema
    {
        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("@context")]
        public string Context { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("Image")]
        public string Image { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("datePublished")]
        public string PublishedDate { get; set; }

        [JsonProperty("dateModified")]
        public string ModifiedDate { get; set; }


    }
}
