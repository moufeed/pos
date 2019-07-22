using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Menus.Models
{
    public class UpdateMenuItemDto
    {
        [Required]
        [JsonProperty("rootmenuid")]
        public Guid RootMenuId { get; set; }

        [Required]
        [JsonProperty("key")]
        public string Key { get; set; }

     //   [Required]
        [JsonProperty("itemtype")]
        public string ItemType { get; set; }

        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }

     //   [Required]
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("urltarget")]
        public string UrlTarget { get; set; }

        [JsonProperty("displayorder")]
        public int DisplayOrder { get; set; }

        [JsonProperty("Lang")]
        public string Lang { get; set; }
    }
}
