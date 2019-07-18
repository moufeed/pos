using Microsoft.AspNetCore.Authorization;

namespace TamTech.Monshaat.POS.SDK.Core.Authorizations
{
    public class PermissionAuthorize : AuthorizeAttribute
    {

        public PermissionAuthorize(string permissions)
        {
            _permissions = permissions;
        }

        string _permissions;

        public string Permissions
        {
            get
            {
                return _permissions;
            }
            set
            {
                _permissions = value;
                Policy = $"{"_Permission"}.{value.ToString()}";
            }
        }
    }
}
