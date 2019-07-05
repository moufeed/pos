using System.Collections.Generic;
using Newtonsoft.Json;
using TamTech.Monshaat.POS.Web.Models.Dtos.Attachments;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Vendors.Models
{
    public class CreateVendorModel : VendorModel
    {
        [JsonProperty("attachments")]
        public List<AttachmentModel> Attachments { get; set; }
    }
}