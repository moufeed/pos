using System;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.Identity;
using TamTech.Monshaat.POS.Web.Services.Identity.Auth.Models;
using TamTech.Monshaat.POS.Web.Services.Identity.Models;
using TamTech.Monshaat.POS.Web.Services.Identity.Settings;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.IdentityService
{
    public class AuthService : IAuthService
    {
        private readonly IRequestProvider _requestProvider;
        private readonly IIdentityBackendSettings _backendSettings;

        public AuthService(IRequestProvider requestProvider,
            IIdentityBackendSettings backendSettings
        )
        {
            _requestProvider = requestProvider;
            _backendSettings = backendSettings;
        }

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

        public async Task<IRequestProviderResult<UserModel>> SignupByNameAsync(SignupByName model) 
        {
            return await _requestProvider.PostAsync<UserModel, SignupByName>(_backendSettings.RegisterUserAsyncEndpoint, model);
        }
    }
}
