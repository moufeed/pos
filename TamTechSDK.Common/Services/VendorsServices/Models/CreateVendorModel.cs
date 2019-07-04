using System.Collections.Generic;
using TamTechSDK.Common.Models.Attachments;

namespace TamTechSDK.Common.Services.VendorsServices.Models
{
    public class CreateVendorModel : VendorModel
    {
        public List<AttachmentModel> Attachments { get; set; }
    }
}