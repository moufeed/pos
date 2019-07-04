using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTechSDK.Web.Models.Admin.Product
{
    public class ProductLiteVM
    {
        public Guid Id { get; set; }


        public string Name { get; set; }


        public string ShortDescription { get; set; }


        public string FullDescription { get; set; }


        public int StockQuantity { get; set; }


        public double Price { get; set; }


        public bool Published { get; set; }


        public string MainImageUrl { get; set; }


        public string SKU { get; set; }
    }
}
