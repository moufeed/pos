using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.POSs.Models
{
   public class PosDto : PosBaseDto
    {
        public List<SpecificationDto> Specifications { get; set; }
        public List<POSStatusHistoryDto> StatusHistories { get; set; }
        public List<string> Images { get; set; }

       
    }
}
