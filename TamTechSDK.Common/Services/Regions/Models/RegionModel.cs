using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Services.Shared.Models;

namespace TamTechSDK.Common.Services.Regions.Models
{
   public class RegionModel : BaseLookupModel
    {
        public int? ParentId { get; set; }

        public bool IsOfficial { get; set; }
    }
}
