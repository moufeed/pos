using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTechSDK.Web.Models.Admin.Product
{
    public class BrandVM
    {

        public string Name { get; set; }


        public string ImageUrl { get; set; }


        public List<CategoryVM> Categories { get; set; } = new List<CategoryVM>();


        public int Order { get; set; }
    }
}
