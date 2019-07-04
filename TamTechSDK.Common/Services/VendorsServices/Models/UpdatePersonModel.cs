using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.VendorsServices.Models
{
    public class UpdatePersonModel : PersonModel
    {
        public UpdateVendorModel Vendor { get; set; }

        public Guid Id { get; set; }
    }
}
