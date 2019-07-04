using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Web.Models.Admin.Values;

namespace TamTechSDK.Web.Models.Admin.Attributes
{
    public class AttributeVM : BaseVM
    {
        public List<ValueVM> Values { get; set; }

        public int ChoiceType { get; set; }

        public int InputType { get; set; }

        public bool IsMandatory { get; set; }
    }
}
