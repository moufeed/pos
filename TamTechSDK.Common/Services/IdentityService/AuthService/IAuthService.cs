using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.Identity.Auth.Models;

namespace TamTechSDK.Common.Services.Identity
{
    public  interface IAuthService
    {

        Task<IRequestProviderResult<bool>> GenerateResetPasswordByEmailSendig(string email);
        Task<IRequestProviderResult<bool>> ResetPassword(ResetPassword model);

        Task<IRequestProviderResult<bool>> ChangePassword(ChangePassword model);

       
    }
}
