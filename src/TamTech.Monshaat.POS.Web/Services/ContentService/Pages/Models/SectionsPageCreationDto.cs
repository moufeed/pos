using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Pages.Models
{
    public  class CreateSectionsPageDto
    {
        [Required]
        [JsonProperty("t")]
        public string Title { get; set; }

         
        [JsonProperty("slug")]
        public string Slug { get; set; }


        [JsonProperty("k")]
        public List<string> Keywords { get; set; }

        [Required]
        [JsonProperty("c")]
        public Dictionary<string, string> Content { get; set; }

        [Required]
        [JsonProperty("summary")]
        public string Summary { get; set; }


        [JsonProperty("mainimage")]
        public string MainImage { get; set; }


        [JsonProperty("section")]
        public string Section { get; set; }
         

        [JsonProperty("displayorder")]
        public int DisplayOrder { get; set; }

        public string AuthorName { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("MetaDescription")]
        public string MetaDescription { get; set; }
        public string Key { get; set; }
    }
}
