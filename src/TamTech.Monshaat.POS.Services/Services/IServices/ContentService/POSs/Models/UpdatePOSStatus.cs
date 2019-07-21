using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.Services.POSs.Models
{
    public class UpdatePOSStatus
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }
        [JsonProperty("id")]
        public Guid POSId { get; set; }

        [JsonProperty("actionid")]
        public int ActionId { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }
    }
}
