using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Products.Models
{
    public class ProductCombinationKeys
    {
        [Required]
        [JsonProperty("productid")]
        public Guid ProductId { get; set; }


        [Required]
        [JsonProperty("combinationkey")]
        public string CombinationKey { get; set; }



        [Required]
        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }
}
