

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Slugs
{
    public class SlugModel
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("modifieddate")]
        public DateTime ModifiedDate { get; set; }

        [JsonProperty("slugs")]
        public Dictionary<string,string> Slugs { get; set; }

        public Guid Id { get; set; }
    }
}
