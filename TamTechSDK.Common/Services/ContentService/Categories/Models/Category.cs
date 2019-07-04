using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Categories.Models
{
   public class Category
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("imageurl")]
        public string ImageUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("categorytype")]
        public string CategoryType { get; set; }


        [JsonProperty("metadescription")]
        public string MetaDescription { get; set; }

        [JsonProperty("publisheddate")]
        public DateTime? PublishedDate { get; set; }

        [JsonProperty("modifieddate")]
        public DateTime? ModifiedDate { get; set; }

        [JsonProperty("seomarkups")]
        public string SEOMarkup { get; set; }
    }
}
