using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Sliders.Models
{
    public class CreateSliderItemDto
    {
        [Required]
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [Required]
        [JsonProperty("sliderid")]
        public Guid SliderId { get; set; }
 
        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }

        
        [JsonProperty("mainimage")]
        public string MainImage { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("urltarget")]
        public string UrlTarget { get; set; }

        [JsonProperty("displayorder")]
        public int DisplayOrder { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [Required]
        public IFormFile NewFile { get; set; }
    }
}
