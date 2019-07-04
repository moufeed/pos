using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Models.VMs.Shared.SEO
{
    public class Gallery : SeoSchema
    {
        public Person Author { get; set; } = new Person();
    }
}
