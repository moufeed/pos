using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Types.Models
{
    public class TypeModel : BaseLookupModel
    {
        [JsonProperty("parentid")]
        public int? ParentId { get; set; }

        [JsonProperty("options")]
        public Dictionary<string, object> Options { get; set; }
    }
}
