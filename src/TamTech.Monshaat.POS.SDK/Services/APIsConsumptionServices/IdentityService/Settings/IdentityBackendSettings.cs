using System;  
using TamTech.Monshaat.POS.Web.SDK.Models.Shared;

namespace TamTech.Monshaat.POS.Web.SDK.Services.Identity.Settings
{
    public class IdentityBackendSettings : IIdentityBackendSettings
    {
        private string  _identityServiceUrl;


        public IdentityBackendSettings(BackendApiSettings settings  )
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


        public string GetUsersEndpoint => $"{_identityServiceUrl}/api/usersmanager/Get";

        public string GetUserByUserNameEndpoint => $"{_identityServiceUrl}/api/usersmanager/GetByUserName";

        public string RegisterUserAsyncEndpoint => $"{_identityServiceUrl}/api/usersmanager/RegisterAsync";

        public string BlockUserAsyncEndpoint => $"{_identityServiceUrl}/api/usersmanager/BlockAsync";

        public string UnblockUserAsyncEndpoint => $"{_identityServiceUrl}/api/usersmanager/UnblockAsync";

        public string GetRolesEndpoint => $"{_identityServiceUrl}/api/roles/Get";



        public string SignupEndpoint => $"{_identityServiceUrl}/api/users/signupbymobilenumber";

        public string ConfirmnumberEndpoint => $"{_identityServiceUrl}/api/users/confirmmobilenumber";

        public string UpdateMobileNumber => $"{_identityServiceUrl}/api/users/updatemobilenumber";

        public string ChangePasswordEndPoint => throw new NotImplementedException();

        public string CheckUserAccountIsActivatedEndpoint => $"{_identityServiceUrl}/api/usersmanager/CheckUserAccountIsActivatedAsync";

        public string GetUserRolesEndpoint => $"{_identityServiceUrl}/api/roles/GetUserRolesAsync";

        public string AddUserToRolesEndpoint => $"{_identityServiceUrl}/api/usersmanager/AddUserToRolesAsync";
  
        public string ValidatePOSAdminCredentialEndpoint => $"{_identityServiceUrl}/api/users/ValidatePOSAdminCredentialAsync";

        public string ValidateVendorCredentialEndpoint => $"{_identityServiceUrl}/api/users/ValidateVendorCredentialAsync";
       
    }
}
