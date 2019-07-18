using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Services.ExternalServices.CommercialRegister.Models;

namespace TamTech.Monshaat.POS.Services.ExternalServices.CommercialRegister
{
    public interface ICRService
    {
        Task<CRIncludeNationalIdResultModel> CheckCRIncludePerson(CRIncludeNationalIdModel model);
    }
}
