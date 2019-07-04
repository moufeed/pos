using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Web.Models.Shared.SEO
{
    public class Person
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = "Person";

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
