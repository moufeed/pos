using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.Services.ContentService.Models;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Sliders.Models
{
    public class SliderItemDto
    {
        public Guid Id { get; set; }

        public Guid SliderId { get; set; }

        public string UrlTarget { get; set; }

        public string Url  { get; set; }

        public string Title { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool Published { get; set; }

        public bool Deleted { get; set; }

        public int DisplayOrder { get; set; }

        public string Summary { get; set; }


        [JsonProperty("image")]
        public string MainImage { get; set; }

        public string Lang { get; set; }

        public bool Locked { get; set; }

    }
}
