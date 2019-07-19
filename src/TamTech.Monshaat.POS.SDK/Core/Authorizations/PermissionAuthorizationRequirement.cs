using Microsoft.AspNetCore.Authorization;

namespace TamTech.Monshaat.POS.SDK.Core.Authorizations
{
    public class PermissionAuthorizationRequirement : IAuthorizationRequirement
    {
        public PermissionAuthorizationRequirement(string[] permissions)
        {
            Permissions = permissions;
        }

        public string[] Permissions { get; private set; }
    }
}
