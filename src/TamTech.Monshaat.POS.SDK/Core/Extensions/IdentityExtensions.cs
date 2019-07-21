using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using TamTech.Monshaat.POS.Web.SDK.Core.Constants;

namespace TamTech.Monshaat.POS.Web.SDK.Core.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetUserId(this IIdentity identity)
        {
            //((System.Security.Claims.ClaimsIdentity)HttpContext.User.Identity).Claims
            var claim = ((System.Security.Claims.ClaimsIdentity)identity).Claims.SingleOrDefault(c => c.Type == "sub");
            return claim?.Value;
        }
        public static string GetUsername(this IIdentity identity)
        {
            var claim = ((System.Security.Claims.ClaimsIdentity)identity).Claims.SingleOrDefault(c => c.Type == "preferred_username");
            return claim?.Value;
        }

        // Get Project Name
        public static string GetClientId(this IIdentity identity)
        {
            var claim = ((System.Security.Claims.ClaimsIdentity)identity).Claims.SingleOrDefault(c => c.Type == "client_id");
            return claim?.Value;
        }

        public static IEnumerable<System.Security.Claims.Claim> GetClaims(this IIdentity identity)
        {
            var claim = ((System.Security.Claims.ClaimsIdentity)identity).Claims;
            return claim;
        }

        // Get User Role
        public static List<string> GetUserRoles(this IIdentity identity)
        {
            var result = ((System.Security.Claims.ClaimsIdentity)identity).Claims.Where(c => c.Type == "role").Select(v => v.Value).ToList();
            return result;
        }

        public static string GetUserRolesCommaSeparated(this IIdentity identity)
        {
            var result = ((System.Security.Claims.ClaimsIdentity)identity).Claims.Where(c => c.Type == "role").Select(v => v.Value).ToList();
            return String.Join(",", result);
        }

        public static string GetPermission(this IIdentity identity)
        {
            var claim = ((System.Security.Claims.ClaimsIdentity)identity).Claims.SingleOrDefault(c => c.Type == CommonConstants.PermissionClaimName);
            return claim?.Value;
        }

        public static string GetAccessToken(this IIdentity identity)
        {
            {
                var claim = ((System.Security.Claims.ClaimsIdentity) identity).Claims.SingleOrDefault(c =>   c.Type == "jwt");
                return claim?.Value;
            }
        }
    }
}
