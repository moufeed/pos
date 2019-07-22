using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Menus.Models
{
   public  class MenuItemDto
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("urltarget")]
        public string UrlTarget { get; set; }

        [JsonProperty("itemtype")]
        public string ItemType { get; set; }

        [JsonProperty("published")]
        public bool Published { get; set; }

        [JsonProperty("displayorder")]
        public int DisplayOrder { get; set; }

        [JsonProperty("menuitems")]
        public List<MenuItemDto> MenuItems { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }
}
