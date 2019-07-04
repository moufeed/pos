using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Web.Models.Admin.Contact
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
