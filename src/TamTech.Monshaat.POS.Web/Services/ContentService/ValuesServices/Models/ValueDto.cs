using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;

namespace TamTech.Monshaat.POS.Web.Services.ValuesServices.Models
{
   public class ValueDto : BaseLookupDto
    {
        public int AttId { get; set; }
        public string AttributeName { get; set; }
    }
}
