using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Common;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Sliders.Models
{
    public class SliderDto : ContentItem
    {

     
        [JsonProperty("key")]
        public string Key { get; set; }


        [JsonProperty("locked")]
        public bool Locked { get; set; }

        //[JsonProperty("position")]
        //public string Position { get; set; }

        [JsonProperty("items")]
        public List<SliderItemDto> Items{ get; set; }
 
    }
}
