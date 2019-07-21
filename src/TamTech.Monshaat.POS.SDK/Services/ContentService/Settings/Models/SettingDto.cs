using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Settings.Models
{
    public class SettingDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("groupid")]
        public int GroupId { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("sharedkey")]
        public string SharedKey { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("lasted")]
        public bool Lasted { get; set; }

        [JsonProperty("updated")]
        public bool Updated { get; set; }

        [JsonProperty("genericfield")]
        public string GenericField { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
