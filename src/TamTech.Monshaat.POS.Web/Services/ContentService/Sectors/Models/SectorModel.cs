using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Sectors.Models
{
    public class SectorModel : BaseLookupModel
    {
        [JsonProperty("parentid")]
        public int? ParentId { get; set; }
    }
}
