using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Products.Models
{
    public class ProductCombinationEditing
    {
         
        [JsonProperty("productid")]
        public Guid ProductId { get; set; }


         
        [JsonProperty("attributesvalues")]
        public IEnumerable<string> AttributesValues { get; set; }


        [JsonProperty("originalattributesvalues")]
        public string OriginalAttributesValues { get; set; }


        [JsonProperty("sku")]
        public string Sku { get; set; }
 


        [JsonProperty("quantity")]
        public int Quantity { get; set; }



        [JsonProperty("price")]
        public double Price { get; set; }
    }
}
