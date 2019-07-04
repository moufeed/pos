using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Models.Attachments;

namespace TamTechSDK.Common.Services.ContentService.Contact.Models
{
    public class CreateModel : ContactBaseModel
    {
        public int TypeId { get; set; }
         
        public List<AttachmentModel> Attachments { get; set; }
    }
}
