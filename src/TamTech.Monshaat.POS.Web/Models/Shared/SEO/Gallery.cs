using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Web.Models.Shared.SEO
{
    public class Gallery : SeoSchema
    {
        public Person Author { get; set; } = new Person();
    }
}
