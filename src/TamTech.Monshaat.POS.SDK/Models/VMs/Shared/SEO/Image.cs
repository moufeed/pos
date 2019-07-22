using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.SDK.Models.VMs.Shared.SEO
{
    public class Image
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = "ImageObject";

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public double Width { get; set; } = 125;

        [JsonProperty("height")]
        public double Height { get; set; } = 125;
    }
}


