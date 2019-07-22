using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Sliders.Models
{
    public class CreateSliderDto
    {

        [Required]
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }

        [Required]
        [JsonProperty("key")]
        public string Key { get; set; }


        //[JsonProperty("position")]
        //public string Position { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }


      
    }
}
