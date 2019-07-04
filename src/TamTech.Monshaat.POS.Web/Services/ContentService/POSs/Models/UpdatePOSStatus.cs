using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.POSs.Models
{
    public class UpdatePOSStatus
    {
        public string Lang { get; set; }
        public Guid POSId { get; set; }

        public int ActionId { get; set; }

        public string Notes { get; set; }
    }
}
