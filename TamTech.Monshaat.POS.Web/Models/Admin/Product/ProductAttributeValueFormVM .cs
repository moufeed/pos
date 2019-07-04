using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TamTechSDK.Web.Models.Admin.Product
{
    public class ProductAttributeValueFormVM
    {
        [Required]
        public string Value { get; set; }

        [Required]
        public string AttributeName { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        public double Price { get; set; } = 0;
    }
}
