using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Models.VMs.Shared.SEO
{
    public class ArticleModel : SeoSchema
    {

        [JsonProperty("headline")]
        public string Headline { get; set; }

        [JsonProperty("author")]
        public Person Author { get; set; } = new Person();

        [JsonProperty("publisher")]
        public Organization Publisher { get; set; } = new Organization();

    }
}

