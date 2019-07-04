using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace TamTechSDK.Common.Services.ContentService.Products.Models
{

    public class ProductAttributeKeys
    {

        [Required]
        [JsonProperty("productid")]
        public Guid ProductId { get; set; }


        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        
 
        [JsonProperty("lang")]
        public string Lang { get; set; }



    }

}

