using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.PosService.PosService.Models
{
     
    public class SpecificationDto : BaseSpecificationModel
    {
        public string AttName { get; set; }

        public Dictionary<int, string> Values { get; set; }
    }
}
