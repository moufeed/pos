using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Web.Models.Shared.SEO
{
    public class Organization
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = "Organization";

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public Image Logo { get; set; } = new Image();
    }
}



