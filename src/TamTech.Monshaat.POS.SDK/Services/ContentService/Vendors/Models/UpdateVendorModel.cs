using System;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Vendors.Models
{
    public class UpdateVendorModel : VendorModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}