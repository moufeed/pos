using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.Models.Dtos.Attachments;

namespace TamTech.Monshaat.POS.Web.Services.POSs.Models
{
    public class PosModel : BasePosModel
    {
        public List<SpecificationModel> Specifications { get; set; }

        public List<AttachmentModel> Attachments { get; set; }

        public string OtherSector { get; set; }
    }
}
