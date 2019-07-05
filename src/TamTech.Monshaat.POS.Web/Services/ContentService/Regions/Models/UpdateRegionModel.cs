using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Regions.Models
{
    public class UpdateRegionModel : RegionModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
