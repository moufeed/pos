using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Products.Models
{
    public class PublishDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }
}
