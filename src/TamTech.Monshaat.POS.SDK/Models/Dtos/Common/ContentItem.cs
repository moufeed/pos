using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTech.Monshaat.POS.Web.Models.Dtos.Slugs;

namespace TamTech.Monshaat.POS.Web.Models.Dtos.Common
{
    public class ContentItem
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
 
        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("createddate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("modifieddate")]
        public DateTime? ModifiedDate { get; set; }

        [JsonProperty("modifieruserid")]
        public string ModifierUserId { get; set; }

        [JsonProperty("creatoruserid")]
        public string CreatorUserId { get; set; }

        [JsonProperty("clientid")]
        public string ClientId { get; set; }

        [JsonProperty("published")]
        public bool Published { get; set; }
       
        [JsonProperty("=")]
        public List<string> Tags { get; set; } = new List<string>();

        [JsonProperty("displayorder")]
        public int DisplayOrder { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("mainimage")]
        public string MainImage { get; set; }

        [JsonProperty("section")]
        public string Section { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("metadescription")]
        public string MetaDescription { get; set; }

        [JsonProperty("seomarkup")]
        public string SEOMarkup { get; set; }

        [JsonProperty("publisheddate")]
        public DateTime? PublishedDate { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

        [JsonProperty("othersslug")]
        public string OthersSlug { get; set; }

        [JsonProperty("authorname")]
        public string AuthorName { get; set; }

        [JsonProperty("customdate")]
        public DateTime? CustomDate { get; set; }

        [JsonProperty("slugs")]
        public List<SlugModel> Slugs { get; set; }
    }
}
