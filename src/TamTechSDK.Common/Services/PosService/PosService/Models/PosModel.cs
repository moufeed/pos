using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Models.Attachments;

namespace TamTechSDK.Common.Services.PosService.PosService.Models
{
    public class PosModel : BasePosModel
    {
        public List<SpecificationModel> Specifications { get; set; }

        public List<AttachmentModel> Attachments { get; set; }

        public string OtherSector { get; set; }
    }
}
