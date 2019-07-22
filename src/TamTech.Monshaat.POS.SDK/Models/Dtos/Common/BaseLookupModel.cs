using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Common
{
    public class BaseLookupModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("displayorder")]
        public int DisplayOrder { get; set; }

        [JsonProperty("genericfield")]
        public string GenericField { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

    }
}
