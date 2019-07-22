using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Values.Models
{
    public class UpdateValueModel : ValueModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
    }
}
