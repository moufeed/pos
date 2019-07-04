using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTechSDK.Web.Models.Shared.Products
{
    public class ProductCombinationVM
    {

        public string ProductId { get; set; }

        public string AttributesValues { get; set; }

        public int Quantity { get; set; }

        public string Sku { get; set; }

        public double Price { get; set; }


        public bool Published { get; set; }


        public double DiscountPrice { get; set; }

    }

}
