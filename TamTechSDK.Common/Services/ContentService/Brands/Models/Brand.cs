using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TamTechSDK.Common.Services.ContentService.Categories.Models;

namespace TamTechSDK.Common.Services.ContentService.Brands.Models
{
    public class Brand
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("imageurl")]
        public string ImageUrl { get; set; }

        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        public string Lang { get; set; }
        [JsonProperty("MetaDescription")]
        public string MetaDescription { get; set; }

        [JsonProperty("publishedDate")]
        public DateTime? PublishedDate { get; set; }

        [JsonProperty("modifiedDate")]
        public DateTime? ModifiedDate { get; set; }

        [JsonProperty("seoMarkups")]
        public string SEOMarkup { get; set; }
    }
}
