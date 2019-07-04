using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.PosService.PosService.Models
{
   public class UpdatePosModel : PosModel
    {
        public Guid Id { get; set; }
        public string userId { get; set; }
    }
}
