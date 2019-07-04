using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.PosService.PosService.Models
{

    public class BaseSpecificationModel
    {
        public int AttId { get; set; }

        public int InputType { get; set; }

        public List<int> Values { get; set; }

        public object Value { get; set; }
    }


    public class SpecificationModel : BaseSpecificationModel
    {
         
    }
}
