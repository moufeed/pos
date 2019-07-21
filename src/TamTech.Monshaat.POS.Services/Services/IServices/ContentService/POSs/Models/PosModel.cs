using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TamTech.Monshaat.POS.Web.Models.Dtos.Attachments;

namespace TamTech.Monshaat.POS.Web.Services.POSs.Models
{
    public class PosModel : BasePosModel
    {
        [JsonProperty("specifications")]
        public List<SpecificationModel> Specifications { get; set; }

        [JsonProperty("attachments")]
        public List<AttachmentModel> Attachments { get; set; }

    }
}
