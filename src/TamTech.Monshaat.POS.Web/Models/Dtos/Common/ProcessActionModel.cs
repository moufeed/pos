using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Models.Dtos.Common
{
    public class ProcessActionModel
    {
        public int ActionId { get; set; }

        public string Name { get; set; }

        public bool NoteMandatory { get; set; }

    }
}
