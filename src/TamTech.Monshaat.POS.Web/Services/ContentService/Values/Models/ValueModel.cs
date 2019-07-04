using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Values.Models
{
    public class ValueModel : BaseLookupModel
    {
        public int AttId { get; set; }

        public int GroupId { get; set; }

        public bool IsOfficial { get; set; }

    }
}
