using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;  
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.Identity.Auth.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.Identity.Models;

namespace TamTech.Monshaat.POS.Web.SDK.Services.Identity
{
    public  interface IAuthService
    {
        Task<IRequestProviderResult<bool>> ValidateVendorCredentialAsync(SignupByName model, string secretKey, string secretValue);

        Task<IRequestProviderResult<bool>> ValidatePOSAdminCredentialAsync(SignupByName model, string secretKey, string secretValue);
     
        Task<IRequestProviderResult<bool>> GenerateResetPasswordByEmailSendig(string email);

        Task<IRequestProviderResult<bool>> ResetPassword(ResetPassword model);

        Task<IRequestProviderResult<bool>> ChangePassword(ChangePassword model);
                                                                                        
    }
}
