using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.SDK.Services.POSs.Models
{
     
    public class SpecificationDto : BaseSpecificationModel
    {
        [JsonProperty("attname")]
        public string AttName { get; set; }

        [JsonProperty("values")]
        public Dictionary<int, string> Values { get; set; }
    }
}
