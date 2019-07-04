using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Services.ContentService.Brands.Models;
using TamTechSDK.Common.Services.ContentService.Categories.Models;

namespace TamTechSDK.Common.Services.ContentService.Products.Models
{
    public class Product
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }
         
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public Dictionary<string, string> Description { get; set; } = new Dictionary<string, string>();

        [JsonProperty("shortdescription")]
        public string ShortDescription { get; set; }

        [JsonProperty("fulldescription")]
        public string FullDescription { get; set; }

        [JsonProperty("stockquantity")]
        public int StockQuantity { get; set; }

        [JsonProperty("discountprice")]
        public double DiscountPrice { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("published")]
        public bool Published { get; set; }

        [JsonProperty("mainimageurl")]
        public string MainImageUrl { get; set; }

        [JsonProperty("sku")]
        public string SKU { get; set; }

        [JsonProperty("rate")]
        public int Rate { get; set; }

        [JsonProperty("categories")]
        public List<Category> Categories { get; set; } = new List<Category>();

        [JsonProperty("brand")]
        public Brand Brand { get; set; } = new Brand();

        [JsonProperty("maximumcartquantity")]
        public int MaximumCartQuantity { get; set; }

        [JsonProperty("isshipenabled")]
        public bool IsShipEnabled { get; set; }

        [JsonProperty("isfreeshipping")]
        public bool IsFreeShipping { get; set; }

        [JsonProperty("weight")]
        public decimal Weight { get; set; }

        [JsonProperty("length")]
        public decimal Length { get; set; }

        [JsonProperty("width")]
        public decimal Width { get; set; }

        [JsonProperty("height")]
        public decimal Height { get; set; }

        [JsonProperty("specifications")]
        public Dictionary<string, string> Specifications { get; set; } = new Dictionary<string, string>();

        [JsonProperty("attributes")]
        public List<ProductAttribute> Attributes { get; set; } = new List<ProductAttribute>();

        [JsonProperty("images")]
        public List<string> Images { get; set; } = new List<string>();


        [JsonProperty("combinations")]
        public List<ProductCombination> Combinations { get; set; } = new List<ProductCombination>();

        [JsonProperty("MetaDescription")]
        public string MetaDescription { get; set; }

        [JsonProperty("publishedDate")]
        public DateTime? PublishedDate { get; set; }

        [JsonProperty("modifiedDate")]
        public DateTime? ModifiedDate { get; set; }

        [JsonProperty("seoMarkups")]
        public string SEOMarkup { get; set; }

        // ----- used in shop/products/details/ -------------------------------------------------------------
        public string Currency { get; set; } = "SAR";

        public string DiscountedPercentage
        {

            get
            {
                if (DiscountPrice <= 0)
                {
                    return "";
                }
                return $"{100 - Convert.ToInt32(((DiscountPrice / Price) * 100))} %";
            }
        }


        public bool HasDiscount
        {
            get
            {
                return (DiscountPrice > 0 && DiscountPrice < Price);
            }
        }

        public string OldPrice
        {
            get
            {
                return DiscountPrice > 0 ? $"{Price} {Currency}" : "";
            }
        }

        public string NewPrice
        {
            get
            {
                return DiscountPrice == 0 ? $"{Price} {Currency}" : $"{DiscountPrice} {Currency}";
            }
        }


    }
}
