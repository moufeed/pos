using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.Models.Dtos.Attachments;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Contact.Models
{
    public class CreateModel : ContactBaseModel
    {
        public int TypeId { get; set; }
         
        public List<AttachmentModel> Attachments { get; set; }
    }
}
