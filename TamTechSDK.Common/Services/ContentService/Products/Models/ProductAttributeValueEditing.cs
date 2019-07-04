using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TamTechSDK.Common.Services.ContentService.Products.Models
{
    public class ProductAttributeValueEditing
    {

        [Required]
        [JsonProperty("originalvalue")]
        public string OriginalValue { get; set; }

        [Required]
        [JsonProperty("attributename")]
        public string AttributeName { get; set; }


        [Required]
        [JsonProperty("productid")]
        public Guid ProductId { get; set; }


        [Required]
        [JsonProperty("value")]
        public string Value { get; set; }


        [JsonProperty("price")]
        public double Price { get; set; }


        [JsonProperty("returnproductcombinations")]
        public bool ReturnProductCombinations { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }
}
