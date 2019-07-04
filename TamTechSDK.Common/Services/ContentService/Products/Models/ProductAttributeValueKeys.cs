using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Products.Models
{
    public class ProductAttributeValueKeys
    {
        [Required]
        [JsonProperty("attributename")]
        public string AttributeName { get; set; }


        [Required]
        [JsonProperty("productid")]
        public Guid ProductId { get; set; }


        [Required]
        [JsonProperty("value")]
        public string Value { get; set; }

     
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }
}
