using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Settings.Models
{
    public class ApiRequestModel<T>
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("array")]
        public T Data { get; set; }
    }
}
