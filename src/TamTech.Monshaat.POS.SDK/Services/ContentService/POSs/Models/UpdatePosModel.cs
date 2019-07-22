using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.SDK.Services.POSs.Models
{
   public class UpdatePosModel : PosModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("userid")]
        public string userId { get; set; }
    }
}
