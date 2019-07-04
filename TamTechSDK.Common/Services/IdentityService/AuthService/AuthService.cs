using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.Identity.Auth.Models;

namespace TamTechSDK.Common.Services.Identity
{
    public class AuthService : IAuthService
    {
        public Task<IRequestProviderResult<bool>> ChangePassword(ChangePassword model)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> GenerateResetPasswordByEmailSendig(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> ResetPassword(ResetPassword password)
        {
            throw new NotImplementedException();
        }
    }
}
