using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Attributes.Models
{
    public class ValueDto : BaseLookupDto
    {
        [JsonProperty("attid")]
        public int AttId { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("checked")]
        public bool Checked { get; set; }

    }
}
