using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Common;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Sliders.Models
{
    public class SliderItemDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("sliderid")]
        public Guid SliderId { get; set; }

        [JsonProperty("urltarget")]
        public string UrlTarget { get; set; }

        [JsonProperty("url")]
        public string Url  { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("createddate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("modifieddate")]
        public DateTime? ModifiedDate { get; set; }

        [JsonProperty("published")]
        public bool Published { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("displayorder")]
        public int DisplayOrder { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }


        [JsonProperty("image")]
        public string MainImage { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

    }
}
