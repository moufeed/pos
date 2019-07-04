using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TamTechSDK.Common.Services.ContentService.Products.Models;
using TamTechSDK.Web.Models.Shared.Products;
namespace TamTechSDK.Web.Models.Admin.Product
{
    public class _ProductVM
    {

        public Guid Id { get; set; }


        public string Name { get; set; }


        public Dictionary<string, string> Description { get; set; }


        public string ShortDescription { get; set; }


        public string FullDescription { get; set; }


        public int StockQuantity { get; set; }


        public double DiscountPrice { get; set; }


        public double Price { get; set; }


        public bool Published { get; set; }


        public string ThumbnailUrl { get; set; }


        public string SKU { get; set; }


        public int Rate { get; set; }


        public List<CategoryVM> Categories { get; set; } = new List<CategoryVM>();


        public BrandVM Brand { get; set; } = new BrandVM();


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



    }
}
