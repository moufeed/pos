using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Services.Shared.Models;

namespace TamTechSDK.Common.Services.Attributes.Models
{
    public class AttributeDto  : BaseLookupDto
    {
        public List<ValueDto> Values { get; set; }

        public int ChoiceType { get; set; }

        public int InputType { get; set; }

        public bool IsMandatory { get; set; }


    }
}
