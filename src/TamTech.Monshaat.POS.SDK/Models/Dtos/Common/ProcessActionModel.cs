using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Common
{
    public class ProcessActionModel
    {
        [JsonProperty("actionid")]
        public int ActionId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("notemandatory")]
        public bool NoteMandatory { get; set; }

    }
}
