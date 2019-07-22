using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.MCI.Services.Models;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;

namespace TamTech.Monshaat.POS.MCI.Services
{
    public interface IMCIServices
    {
        Task<IRequestProviderResult<AuthenticateADResultModel>> AuthenticateByAD(ADUserModel lang);

        Task<IRequestProviderResult<PersonsOfCRResultModel>> GetAllPersonsForCR(GetAllPersonsForCRModel model);

        Task<IRequestProviderResult<BaseResultModel>> SendEmail(SendEmailModel model);

    }
}
