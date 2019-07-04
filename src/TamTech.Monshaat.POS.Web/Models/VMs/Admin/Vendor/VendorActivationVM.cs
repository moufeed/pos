using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Web.Models.Admin.Vendor
{
    public class VendorActivationVM
    {
        public Guid Id { get; set; }
        public bool Checked { get; set; }

        public string Name { get; set; }
    }
}
