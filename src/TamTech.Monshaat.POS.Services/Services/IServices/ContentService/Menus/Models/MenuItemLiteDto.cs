using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Menus.Models
{
    public class MenuItemLiteDto
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("urltarget")]
        public string UrlTarget { get; set; }

        [JsonProperty("published")]
        public bool Published { get; set; }

        [JsonProperty("displayorder")]
        public int DisplayOrder { get; set; }
    }
}
