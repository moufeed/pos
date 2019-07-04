using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTechSDK.Common.Services.ContentService.Products.Models;

namespace TamTechSDK.Web.Models.Admin
{
    public class _ProductView
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public int StockQuantity { get; set; }

        public double OldPrice { get; set; }

        public double Price { get; set; }

        public bool Published { get; set; }

        public string ThumbnailUrl { get; set; }

        public string SKU { get; set; }

        public Guid Brand { get; set; }

        public List<Guid> Categories { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<string> Pictures { get; set; }

        public int MaximumCartQuantity { get; set; }

        public bool IsShipEnabled { get; set; }

        public bool IsFreeShipping { get; set; }

        public decimal Weight { get; set; }

        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public bool Deleted { get; set; }

        public Dictionary<string, string> Specifications { get; set; } = new Dictionary<string, string>();

        public List<ProductAttribute> Attributes { get; set; } = new List<ProductAttribute>();

        public List<string> Images { get; set; } = new List<string>();

        public List<IFormFile> Files { get; set; } = new List<IFormFile>();
    }
}
