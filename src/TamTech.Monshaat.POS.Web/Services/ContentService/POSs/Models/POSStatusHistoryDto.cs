using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;

namespace TamTech.Monshaat.POS.Web.Services.POSs.Models
{
    public class POSStatusHistoryDto : StatusHistoryDto
    {
        public int ActionId { get; set; }

        public string ActionName { get; set; }
    }
}
