using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.PosService.Sectors.Models
{
   public class UpdateSectorModel : SectorModel
    {
        public int Id { get; set; }

        public bool IsOfficial { get; set; }
    }
}
