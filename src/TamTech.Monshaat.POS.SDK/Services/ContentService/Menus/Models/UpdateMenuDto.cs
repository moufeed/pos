using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Menus.Models
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

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }
}
