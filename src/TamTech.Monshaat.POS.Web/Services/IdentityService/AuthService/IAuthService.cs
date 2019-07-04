using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.Identity.Auth.Models;

namespace TamTech.Monshaat.POS.Web.Services.Identity
{
    public  interface IAuthService
    {

        Task<IRequestProviderResult<bool>> GenerateResetPasswordByEmailSendig(string email);
        Task<IRequestProviderResult<bool>> ResetPassword(ResetPassword model);

        Task<IRequestProviderResult<bool>> ChangePassword(ChangePassword model);

       
    }
}
