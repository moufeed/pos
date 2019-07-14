using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.Identity.Settings
{
    public class IdentityBackendSettings : IIdentityBackendSettings
    {
        private string _identityServiceUrl;


        public IdentityBackendSettings(string identityServiceUrl = "http://localhost:50383/")
        {
            _identityServiceUrl = identityServiceUrl;
           
        }

       
        public string IdentityEndpointBase => _identityServiceUrl;

        public string ClientId => "clientapp";

        public string ClientSecret => "h8yI4DydzI5ZsKCMGTs9hfTdI1vRS3qfTo9Go92q3aM=";

        public string IdentityEndpoint => $"{IdentityEndpointBase}/connect/authorize";

        public string UserInfoEndpoint => $"{IdentityEndpointBase}/connect/userinfo";

        public string TokenEndpoint => $"{IdentityEndpointBase}/connect/token";

        public string LogoutEndpoint => $"{IdentityEndpointBase}/connect/endsession";

        public string IdentityCallback => $"{IdentityEndpointBase}/signin-oidc";

        public string LogoutCallback => $"{IdentityEndpointBase}/signout-callback-oidc";


        public string GetUsersEndpoint => $"{IdentityEndpointBase}/api/0.1/usersmanager/Get";

        public string GetUserByUserNameEndpoint => $"{IdentityEndpointBase}/api/0.1/usersmanager/GetByUserName";

        public string RegisterUserAsyncEndpoint => $"{IdentityEndpointBase}/api/0.1/usersmanager/RegisterAsync";

        public string BlockUserAsyncEndpoint => $"{IdentityEndpointBase}/api/0.1/usersmanager/BlockAsync";

        public string UnblockUserAsyncEndpoint => $"{IdentityEndpointBase}/api/0.1/usersmanager/UnblockAsync";

        public string GetRolesEndpoint => $"{IdentityEndpointBase}/api/0.1/roles/Get";



        public string SignupEndpoint => $"{IdentityEndpointBase}/api/0.1/users/signupbymobilenumber";

        public string ConfirmnumberEndpoint => $"{IdentityEndpointBase}/api/0.1/users/confirmmobilenumber";

        public string UpdateMobileNumber => $"{IdentityEndpointBase}/api/0.1/users/updatemobilenumber";

        public string ChangePasswordEndPoint => throw new NotImplementedException();

        public string CheckUserAccountIsActivatedEndpoint => $"{IdentityEndpointBase}/api/0.1/usersmanager/CheckUserAccountIsActivatedAsync";

        public string GetUserRolesEndpoint => $"{IdentityEndpointBase}/api/0.1/roles/GetUserRolesAsync";

        public string AddUserToRolesEndpoint => $"{IdentityEndpointBase}/api/0.1/roles/AddUserToVendorRoleAsync";
    }
}
