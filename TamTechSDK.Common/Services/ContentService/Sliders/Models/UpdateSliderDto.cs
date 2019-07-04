using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Sliders.Models
{
    public class UpdateSliderDto
    {

        [Required]
        public Guid Id { get; set; }

        [Required]
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }


        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

        //[JsonProperty("position")]
        //public string Position { get; set; }


        [JsonProperty("summary")]
        public string Summary { get; set; }

        public bool Published { get; set; }

        public List<UpdateSliderItemDto> Items { get; set; }

     
    }
}
