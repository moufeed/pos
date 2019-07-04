using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.ValuesServices.Models
{
    public class CreateValueModel : ValueModel
    {
        public bool IsOfficial { get; set; }

        public int GroupId { get; set; }
    }
}
