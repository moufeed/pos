using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.MCIServices.Models;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;

namespace TamTech.Monshaat.POS.MCIServices
{
    public interface IMCIServices
    {
        Task<IRequestProviderResult<AuthenticateADResultModel>> AuthenticateByAD(ADUserModel lang);

        Task<IRequestProviderResult<PersonsOfCRResultModel>> GetAllPersonsForCR(GetAllPersonsForCRModel model);

        Task<IRequestProviderResult<BaseResultModel>> SendEmail(SendEmailModel model);

    }
}
