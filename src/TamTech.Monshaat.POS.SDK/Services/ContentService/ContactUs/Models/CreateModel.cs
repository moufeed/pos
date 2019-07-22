using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Attachments;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.ContactUs.Models
{
    public class CreateModel : ContactBaseModel
    {
        [JsonProperty("typeid")]
        public int TypeId { get; set; }
         
        [JsonProperty("attachments")]
        public List<AttachmentModel> Attachments { get; set; }
    }
}
