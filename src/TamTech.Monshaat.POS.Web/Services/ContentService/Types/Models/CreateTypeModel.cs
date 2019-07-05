using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Types.Models
{
    public class CreateTypeModel :TypeModel
    {
        [JsonProperty("isofficial")]
        public bool IsOfficial { get; set; }

        
    }
}
