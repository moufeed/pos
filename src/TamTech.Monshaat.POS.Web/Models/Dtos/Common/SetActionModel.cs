using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Models.Dtos.Common
{
    public class SetActionModel
    {
        public Guid Id { get; set; }

        public int ActionId { get; set; }

        public string Notes { get; set; }

        public string Lang { get; set; }
    }
}
