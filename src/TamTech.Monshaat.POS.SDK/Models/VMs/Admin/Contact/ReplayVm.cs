using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.SDK.Models.VMs.Admin.Contact
{
    public class ReplayVm
    {
        public Guid Id { get; set; }
        public string Replay { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public string ReplyType { get; set; }

    }
}
