using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Products.Models
{
    public class ProductAttribute 
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        //[JsonProperty("required")]
        //public bool Required { get; set; }

        //[JsonProperty("currentvalue")]
        //public int CurrentValue { get; set; }

        [JsonProperty("values")]
        public IEnumerable<ProductAttributeValue> Values { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    public class ProductAttributeValue
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        //[JsonProperty("ProductId")]
        //public Guid ProductId { get; set; }

        //[JsonProperty("quantity")]
        //public int Quantity { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

    }

}
