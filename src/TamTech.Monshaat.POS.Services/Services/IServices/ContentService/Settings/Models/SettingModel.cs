using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Settings.Models
{
    public class SettingModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("genericfield")]
        public string GenericField { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
