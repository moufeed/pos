using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.Identity;
using TamTech.Monshaat.POS.Web.Services.Identity.Auth.Models;
using TamTech.Monshaat.POS.Web.Services.Identity.Models;
using TamTech.Monshaat.POS.Web.Services.Identity.Settings;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.IdentityService
{
    public class AuthService : BaseAPIService, IAuthService
    {                                      
        private readonly IIdentityBackendSettings _backendSettings;

        public AuthService(IRequestProvider requestProvider,      IIdentityBackendSettings backendSettings  )    :base(requestProvider)   
        {              
            _backendSettings = backendSettings;
        }

        public async Task<IRequestProviderResult<bool>> ResetPOSAdminPasswordAsync(ResetPOSAdminPasswordModel model, string secretKey, string secretValue)
        {
            return await ReqProvider.PostAsync<bool, ResetPOSAdminPasswordModel>(_backendSettings.RegisterUserAsyncEndpoint, model,
                new Dictionary<string, string> { { secretKey, secretValue } });
        }            
        public async Task<IRequestProviderResult<UserModel>> SignupByNameAsync(SignupByName model)
        {
            return await ReqProvider.PostAsync<UserModel, SignupByName>(_backendSettings.RegisterUserAsyncEndpoint, model);
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

     

       
    }
}
