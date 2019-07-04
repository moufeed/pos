using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TamTechSDK.Common.Services.ContentService.Menus.Models
{
    public class UpdateMenuDto
    {
        [Required]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }

        [Required]
        [JsonProperty("position")]
        public string Position { get; set; }

        [Required]
        [JsonProperty("key")]
        public string Key { get; set; }

        public string Lang { get; set; }
    }
}
