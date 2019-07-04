using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Services.Shared.Models;

namespace TamTechSDK.Common.Services.PosService.PosService.Models
{
    public class POSStatusHistoryDto : StatusHistoryDto
    {
        public int ActionId { get; set; }

        public string ActionName { get; set; }
    }
}
