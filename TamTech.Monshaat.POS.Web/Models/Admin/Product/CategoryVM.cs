using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTechSDK.Web.Models.Admin.Product
{
    public class CategoryVM
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string CategoryType { get; set; }
    }
}
