using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.SDK.Models.Dtos.SelectList
{
    public class SelectListItemModel
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }
    }
}
