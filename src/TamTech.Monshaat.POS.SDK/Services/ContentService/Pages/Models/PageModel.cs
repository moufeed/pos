using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Pages.Models
{
    public class PageModel
    {
        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }


        [JsonProperty("slug")]
        public string Slug { get; set; }


        [JsonProperty("k")]
        public List<string> Keywords { get; set; }
         
        [Required]
        [JsonProperty("summary")]
        public string Summary { get; set; }


        [JsonProperty("mainimage")]
        public string MainImage { get; set; }


        [JsonProperty("section")]
        public string Section { get; set; }


        [JsonProperty("displayorder")]
        public int DisplayOrder { get; set; }

        [JsonProperty("authorname")]
        public string AuthorName { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("MetaDescription")]
        public string MetaDescription { get; set; }
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("publisheddate")]
        public DateTime? PublishedDate { get; set; }

        [JsonProperty("modifieddate")]
        public DateTime? ModifiedDate { get; set; }

        [JsonProperty("seomarkup")]
        public string SEOMarkup { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }
    }
}
