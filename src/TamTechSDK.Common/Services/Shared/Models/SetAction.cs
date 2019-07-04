using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.Shared.Models
{
    public class SetAction
    {
        public Guid Id { get; set; }

        public int ActionId { get; set; }

        public string Notes { get; set; }

        public string Lang { get; set; }
    }
}
