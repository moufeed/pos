using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Regions.Models
{
   public class RegionModel : BaseLookupModel
    {
        public int? ParentId { get; set; }

        public bool IsOfficial { get; set; }
    }
}
