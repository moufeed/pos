using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Sectors.Models
{
   public class CreateSectorModel : SectorModel
    {
        [JsonProperty("isofficial")]
        public bool IsOfficial { get; set; }
    }
}
