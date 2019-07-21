using System;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.MCI.EFile2.Services;  

namespace TamTech.Monshaat.POS.Web.MinistryServices.EFile2
{
    public class FakeEFileIdentityProviderService : IEFileIdentityProviderService
    {




        public FakeEFileIdentityProviderService()
        {

        }

        public async Task<bool> IsAuthenticatedAsync(string access_token)
        {
            return "ABCD".Contains(access_token) && access_token.Length == 1;
        }


        public async Task<string> GetUsernameByAccessTokenAsync(string access_token)
        {
            switch (access_token)
            {
                default:
                case "A":
                    return "1099800391";
                case "B":
                    return "1099999998";
                case "C":
                    return "1099999996";
                case "D":
                    return "1099999994";
            }
        }


        public async Task<bool> LogoutAsync(string access_token)
        {

            return true;
        }

        public string GetLoginUrl(string returnUrl = null)
        {
            return $"/?access_token={RandomString(1)}";

        }

        private Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCD";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}  