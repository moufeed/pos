using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Regions.Models
{
   public class RegionModel : BaseLookupModel
    {
        [JsonProperty("parentid")]
        public int? ParentId { get; set; }

        [JsonProperty("isofficial")]
        public bool IsOfficial { get; set; }
    }
}
