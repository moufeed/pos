using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.CustomVendorRegisteration
{
    public class CustomHelper
    {

        public static string GenerateAccessToken(string userId, string username)
        {
            var t = TamTech.Monshaat.POS.Web.Core.Helpers.Helpers.Base64Encode($"{userId}_us3rn@me_ef2_{username}");
            return t;
        }
           public static string GetUsernameFromAccessToken(string access_token)
        {
            var t = TamTech.Monshaat.POS.Web.Core.Helpers.Helpers.Base64Decode(access_token);
            var uname = t.Split("_us3rn@me_ef2_")[1];
            return uname;
        }


    }
}
