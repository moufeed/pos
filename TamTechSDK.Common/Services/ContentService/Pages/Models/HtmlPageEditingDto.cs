using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Pages.Models
{
    public class EditHtmlPageDto
    {
        [Required]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [Required]
        [JsonProperty("t")]
        public string Title { get; set; }


        [Required]
        [JsonProperty("slug")]
        public string Slug { get; set; }


        [JsonProperty("k")]
        public List<string> Keywords { get; set; }

        [Required]
        [JsonProperty("c")]
        public string Content { get; set; }

        [Required]
        [JsonProperty("summary")]
        public string Summary { get; set; }


        [JsonProperty("mainimage")]
        public string MainImage { get; set; }


        [JsonProperty("section")]
        public string Section { get; set; }


        [JsonProperty("displayorder")]
        public int DisplayOrder { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("MetaDescription")]
        public string MetaDescription { get; set; }

        [JsonProperty("seomarkup")]
        public string SEOMarkup { get; set; }


        public DateTime? PublishedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string AuthorName { get; set; }
        public string Key { get; set; }

    }
}
