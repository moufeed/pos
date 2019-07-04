using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TamTechSDK.Common.Services.ContentService.Menus.Models
{
    public class MenuItemKeysDto
    {
        [Required]
        [JsonProperty("rootmenuid")]
        public Guid RootMenuId { get; set; }

        [Required]
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

    }
}
