using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace TamTech.Monshaat.POS.Web.Models.VMs.Admin.Sliders
{
    public class UpdateSliderItemVm
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

        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }

        //  [Required]
        [JsonProperty("image")]
        public string Image { get; set; }

        [Required]
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("urltarget")]
        public string UrlTarget { get; set; }

        [JsonProperty("displayorder")]
        public int DisplayOrder { get; set; }

        public bool Published { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
