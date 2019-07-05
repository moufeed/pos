using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Vendors.Models
{
    public class CreatePersonModel : PersonModel
    {
        [JsonProperty("vendor")]
        public CreateVendorModel Vendor { get; set; }
    }
}
