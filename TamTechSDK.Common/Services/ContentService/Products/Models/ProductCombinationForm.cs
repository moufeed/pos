using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Products.Models
{
    public class ProductCombinationForm
    {
         
        [JsonProperty("productid")]
        public Guid ProductId { get; set; }


         
        [JsonProperty("Attributes")]
        public Dictionary<string, string> AttributesValues { get; set; }


        
        [JsonProperty("sku")]
        public string Sku { get; set; }
 


        [JsonProperty("quantity")]
        public int Quantity { get; set; }



        [JsonProperty("price")]
        public double Price { get; set; }


        [JsonProperty("discountprice")]
        public double DiscountPrice { get; set; }
         

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }
}
