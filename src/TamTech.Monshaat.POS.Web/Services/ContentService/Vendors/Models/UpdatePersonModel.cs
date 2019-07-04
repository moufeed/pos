using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Vendors.Models
{
    public class UpdatePersonModel : PersonModel
    {
        public UpdateVendorModel Vendor { get; set; }

        public Guid Id { get; set; }
    }
}
