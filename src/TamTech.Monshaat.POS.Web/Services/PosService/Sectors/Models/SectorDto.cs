using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Services.Shared.Models;

namespace TamTechSDK.Common.Services.PosService.Sectors.Models
{
    public class SectorDto : BaseLookupDto
    {
        public int? ParentId { get; set; }
    }
}
