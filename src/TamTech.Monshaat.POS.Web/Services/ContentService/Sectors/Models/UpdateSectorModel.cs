using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Sectors.Models
{
   public class UpdateSectorModel : SectorModel
    {
        public int Id { get; set; }

        public bool IsOfficial { get; set; }
    }
}
