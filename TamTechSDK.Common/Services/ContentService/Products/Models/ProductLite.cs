using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Products.Models
{
    public class ProductLite
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public int StockQuantity { get; set; }

        public double OldPrice { get; set; }

        public double Price { get; set; }

        public bool Published { get; set; }

        public string ThumbnailUrl { get; set; }

        public string SKU { get; set; }

        public List<string> Categories { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
