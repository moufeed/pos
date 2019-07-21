using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Types.Models
{
   public class UpdateTypeModel : TypeModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
