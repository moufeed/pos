using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TamTechSDK.Web.Models.Admin.Product
{
    public class ProductAttributeValueEditingVM
    {
        [Required]
        public string OriginalValue { get; set; }

        [Required]
        public string AttributeName { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public string Value { get; set; }


        public double Price { get; set; }
    }
}
