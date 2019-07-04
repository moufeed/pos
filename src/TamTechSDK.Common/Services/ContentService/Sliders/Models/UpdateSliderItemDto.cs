using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Sliders.Models
{
    public class UpdateSliderItemDto
    {

        [Required]
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [Required]
        [JsonProperty("sliderid")]
        public Guid SliderId { get; set; }

        [Required]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        //[Required]
        [JsonProperty("title")]
        public string Title { get; set; }

        [Required]
        [JsonProperty("mainimage")]
        public string MainImage { get; set; }

          //  [Required]
        [JsonProperty("summary")]
        public string Summary { get; set; }

        
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("urltarget")]
        public string UrlTarget { get; set; }

        [JsonProperty("displayorder")]
        public int DisplayOrder { get; set; }

        public bool Published { get; set; }

        public bool Deleted { get; set; }

        public DateTime CreatedDate { get; set; }





    }
}
