using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Services.ExternalServices.CommercialRegister.Models
{
   public class CRIncludeNationalIdResultModel
    {
        public CRIncludeNationalIdResultModel(bool successed)
        {
            Successed = successed;
        }

        public bool Successed { get; set; }
    }
}
