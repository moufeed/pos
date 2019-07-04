using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Web.Models.Shared.Products
{
    public class ProductAttributeVM
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<ProductAttributeValueVM> Values { get; set; }
    }


}
