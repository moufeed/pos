using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Products.Models
{
    public class PublicProductFiltrationModel
    {
        [JsonProperty("sortby")]
        public string SortBy { get; set; } = null;  

        [JsonProperty("desc")]
        public bool Desc { get; set; } = false;

        [JsonProperty("pagesize")]
        public int PageSize { get; set; } = 10;


        //[JsonProperty("continuationtoken")]
        //public string ContinuationToken { get; set; } = null; 


        [JsonProperty("pagenumber")]
        public string PageNumber { get; set; } = null;


        [JsonProperty("minprice")]
        public double? MinPrice { get; set; } = null;

        [JsonProperty("maxprice")]
        public double? MaxPrice { get; set; } = null;

        [JsonProperty("categoryid")]
        public string CategoryId { get; set; } = null;

        [JsonProperty("brands")]
        public string Brands { get; set; } 

        [JsonProperty("brandid")]
        public string BrandId { get; set; }

        


    }
}
