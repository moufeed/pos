using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Web.Models.Shared
{
    public class ActionVm
    {
        public Guid Id { get; set; }

        public int ActionId { get; set; }

        public string Notes { get; set; }

        public string Lang { get; set; }

        public string Email { get; set; }
    }
}
