using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.POSs.Models
{
   public class UpdatePosModel : PosModel
    {
        public Guid Id { get; set; }
        public string userId { get; set; }
    }
}
