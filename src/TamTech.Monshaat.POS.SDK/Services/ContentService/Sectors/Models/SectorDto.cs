using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Common;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Sectors.Models
{
    public class SectorDto : BaseLookupDto
    {
        [JsonProperty("parentid")]
        public int? ParentId { get; set; }
    }
}
