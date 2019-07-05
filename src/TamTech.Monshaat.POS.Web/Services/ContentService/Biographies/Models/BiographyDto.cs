using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Biographies.Models
{
    public class BiographyDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("group_id")]
        public int GroupId { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("generic_field")]
        public string GenericField { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
