using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TamTechSDK.Common.Services.ContentService.Products.Models;

namespace TamTechSDK.Web.Models.Shared.Products
{
    public class ProductFormVM
    {

        public Guid Id { get; set; }


        public string Name { get; set; }


        public Dictionary<string, string> Description { get; set; } = new Dictionary<string, string>();


        public string ShortDescription { get; set; }


        public string FullDescription { get; set; }


        public int StockQuantity { get; set; }


        public double DiscountPrice { get; set; }


        public double Price { get; set; }


        public bool Published { get; set; }


        public string MainImageUrl { get; set; }


        public string SKU { get; set; }


        public int Rate { get; set; }


        public List<Guid> Categories { get; set; } = new List<Guid>();


        public Guid Brand { get; set; }


        public int MaximumCartQuantity { get; set; }


        public bool IsShipEnabled { get; set; }


        public bool IsFreeShipping { get; set; }


        public decimal Weight { get; set; }


        public decimal Length { get; set; }


        public decimal Width { get; set; }


        public decimal Height { get; set; }


        public Dictionary<string, string> Specifications { get; set; } = new Dictionary<string, string>();


        public List<ProductAttributeVM> Attributes { get; set; } = new List<ProductAttributeVM>();


        public List<string> Images { get; set; } = new List<string>();

        public List<ProductCombinationVM> Combinations { get; set; } = new List<ProductCombinationVM>();

        //private ICollection<ProductCombinationVM> _productAttributeCombinations;
        //public ICollection<ProductCombinationVM> ProductAttributeCombinations
        //{
        //    get { return _productAttributeCombinations ?? (_productAttributeCombinations = new List<ProductCombinationVM>()); }
        //    set { _productAttributeCombinations = value; }
        //}


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
