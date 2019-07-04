using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Types.Models
{
   public  class TypeDto : BaseLookupDto
    {
        public Dictionary<string, object> Options { get; set; }
    }
}
