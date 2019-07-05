using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.Models.Dtos.Attachments
{
    public class AttachmentModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("fullurl")]
        public string FullUrl { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("genericfield")]
        public string GenericField { get; set; }
    }
}
