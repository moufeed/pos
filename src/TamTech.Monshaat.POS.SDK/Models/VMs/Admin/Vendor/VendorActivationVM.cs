using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.SDK.Models.VMs.Admin.Vendor
{
    public class VendorActivationVM
    {
        public Guid Id { get; set; }
        public bool Checked { get; set; }

        public string Name { get; set; }
    }
}
