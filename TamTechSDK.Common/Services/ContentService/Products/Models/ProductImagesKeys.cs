using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Products.Models
{
    public class ProductImagesModel
    {
        [Required]
        [JsonProperty("images")]
        public List<string> images { get; set; }


        [Required]
        [JsonProperty("productid")]
        public Guid ProductId { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }
}
