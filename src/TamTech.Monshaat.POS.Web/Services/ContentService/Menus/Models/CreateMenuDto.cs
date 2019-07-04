using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using TamTech.Monshaat.POS.Web.Core.Helpers;
using Microsoft.Extensions.Localization;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Menus.Models
{
    public class CreateMenuDto
    {
        [Required]
        [JsonProperty("key")]
        [RegularExpression(Constants.SlugRegx)]
        public string Key { get; set; }


        [JsonProperty("title")]
        public string Title { get; set; }

        [Required]
        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("Lang")]
        public string Lang { get; set; }

    }
}
