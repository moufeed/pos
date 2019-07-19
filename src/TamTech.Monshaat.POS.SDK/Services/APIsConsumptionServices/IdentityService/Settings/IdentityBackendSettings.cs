using System;  
using TamTech.Monshaat.POS.Web.Models.Shared;

namespace TamTech.Monshaat.POS.Web.Services.Identity.Settings
{
    public class IdentityBackendSettings : IIdentityBackendSettings
    {
        private string  _identityServiceUrl;


        public IdentityBackendSettings(BackendApiSettingsModel settings  )
        {
            _identityServiceUrl = settings.Url.TrimEnd('/');
           
        }

       
       //public string  IdentityServiceUrl =>  _identityServiceUrl;

      //  public string ClientId => "clientapp";

      //  public string ClientSecret => "h8yI4DydzI5ZsKCMGTs9hfTdI1vRS3qfTo9Go92q3aM=";

        public string IdentityEndpoint => $"{_identityServiceUrl}/connect/authorize";

        public string UserInfoEndpoint => $"{_identityServiceUrl}/connect/userinfo";

        public string TokenEndpoint => $"{_identityServiceUrl}/connect/token";

        public string LogoutEndpoint => $"{_identityServiceUrl}/connect/endsession";

        public string IdentityCallback => $"{_identityServiceUrl}/signin-oidc";

        public string LogoutCallback => $"{_identityServiceUrl}/signout-callback-oidc";


        public string GetUsersEndpoint => $"{_identityServiceUrl}/api/0.1/usersmanager/Get";

        public string GetUserByUserNameEndpoint => $"{_identityServiceUrl}/api/0.1/usersmanager/GetByUserName";

        public string RegisterUserAsyncEndpoint => $"{_identityServiceUrl}/api/0.1/usersmanager/RegisterAsync";

        public string BlockUserAsyncEndpoint => $"{_identityServiceUrl}/api/0.1/usersmanager/BlockAsync";

        public string UnblockUserAsyncEndpoint => $"{_identityServiceUrl}/api/0.1/usersmanager/UnblockAsync";

        public string GetRolesEndpoint => $"{_identityServiceUrl}/api/0.1/roles/Get";



        public string SignupEndpoint => $"{_identityServiceUrl}/api/0.1/users/signupbymobilenumber";

        public string ConfirmnumberEndpoint => $"{_identityServiceUrl}/api/0.1/users/confirmmobilenumber";

        public string UpdateMobileNumber => $"{_identityServiceUrl}/api/0.1/users/updatemobilenumber";

        public string ChangePasswordEndPoint => throw new NotImplementedException();

        public string CheckUserAccountIsActivatedEndpoint => $"{_identityServiceUrl}/api/0.1/usersmanager/CheckUserAccountIsActivatedAsync";

        public string GetUserRolesEndpoint => $"{_identityServiceUrl}/api/0.1/roles/GetUserRolesAsync";

        public string AddUserToRolesEndpoint => $"{_identityServiceUrl}/api/0.1/usersmanager/AddUserToRolesAsync";
  
        public string ValidatePOSAdminCredentialEndpoint => $"{_identityServiceUrl}/api/0.1/users/ValidatePOSAdminCredentialAsync";

        public string ValidateVendorCredentialEndpoint => $"{_identityServiceUrl}/api/0.1/users/ValidateVendorCredentialAsync";
       
    }
}
