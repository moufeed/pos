using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Admin.Values;

namespace TamTech.Monshaat.POS.Web.SDK.Models.VMs.Admin.Attributes
{
    public class AttributeVM : BaseVM
    {
        public List<ValueVM> Values { get; set; }

        public int ChoiceType { get; set; }

        public int InputType { get; set; }

        public bool IsMandatory { get; set; }
    }
}
