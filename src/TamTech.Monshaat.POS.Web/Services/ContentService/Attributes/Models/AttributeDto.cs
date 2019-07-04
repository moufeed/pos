using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Attributes.Models
{
    public class AttributeDto  : BaseLookupDto
    {
        public List<ValueDto> Values { get; set; }

        public int ChoiceType { get; set; }

        public int InputType { get; set; }

        public bool IsMandatory { get; set; }


    }
}
