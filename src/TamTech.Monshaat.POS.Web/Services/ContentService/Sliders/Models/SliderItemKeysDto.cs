using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Sliders.Models
{
    public class SliderItemKeysDto
    {

        [Required]
        [JsonProperty("sliderid")]
        public Guid SliderId { get; set; }

        [Required]
        [JsonProperty("id")]
        public Guid Id { get; set; }

         
        [JsonProperty("lang")]
        public string Lang { get; set; }


    }
}
