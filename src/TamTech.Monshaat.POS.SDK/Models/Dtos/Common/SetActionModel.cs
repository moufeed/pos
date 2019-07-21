using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Common
{
    public class SetActionModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("actionid")]
        public int ActionId { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }
}
