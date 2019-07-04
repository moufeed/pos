using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TamTechSDK.Common.Services.ContentService.Menus.Models
{
    public class CreateMenuItemDto
    {
        [Required]
        [JsonProperty("rootmenuid")]
        public Guid MenuId { get; set; }

        [JsonProperty("parentkey")]
        public string ParentKey { get; set; }

        [Required]
        [JsonProperty("itemtype")]
        public string ItemType { get; set; }

        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }

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
