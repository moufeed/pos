using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TamTechSDK.Web.Models.Shared.Products
{
    public class ProductCombinationFormVM
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public Dictionary<string, string> Attributes { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Sku { get; set; }

        public double Price { get; set; }

        [Required]
        public string ProductSku { get; set; }


        public double DiscountPrice { get; set; }

        public string CombinationKey { get; set; }

    }
}
