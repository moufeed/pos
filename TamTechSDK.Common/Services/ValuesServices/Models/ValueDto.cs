using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Services.Shared.Models;

namespace TamTechSDK.Common.Services.ValuesServices.Models
{
   public class ValueDto : BaseLookupDto
    {
        public int AttId { get; set; }
        public string AttributeName { get; set; }
    }
}
