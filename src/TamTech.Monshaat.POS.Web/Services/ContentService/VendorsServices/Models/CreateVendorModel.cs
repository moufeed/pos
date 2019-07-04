using System.Collections.Generic;
using TamTech.Monshaat.POS.Web.Models.Dtos.Attachments;

namespace TamTech.Monshaat.POS.Web.Services.VendorsServices.Models
{
    public class CreateVendorModel : VendorModel
    {
        public List<AttachmentModel> Attachments { get; set; }
    }
}