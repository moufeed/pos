using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Products.Models
{
    public class ProductAttributeEditing
    {
        [Required]
        [JsonProperty("ProductId")]
        public Guid ProductId { get; set; }

        [Required]
        [JsonProperty("type")]
        public string Type { get; set; }

        [Required]
        [JsonProperty("originalname")]
        public string OriginalName { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }


        [JsonProperty("returnproductcombinations")]
        public bool ReturnProductCombinations { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }
}
