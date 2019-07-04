using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Products.Models
{
    public class ProductCombination
    {

        [JsonProperty("attributesvalues")]
        public string AttributesValues { get; set; } = "";


        
        [JsonProperty("sku")]
        public string Sku { get; set; }
 


        [JsonProperty("quantity")]
        public int Quantity { get; set; }



        [JsonProperty("price")]
        public double Price { get; set; }


        [JsonProperty("discountprice")]
        public double DiscountPrice { get; set; }


        [JsonProperty("published")]
        public bool Published { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }
}
