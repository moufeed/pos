using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.IdentityService.Models;

namespace TamTech.Monshaat.POS.IdentityService.Services
{
    public class AuthTamService : IAuthTamService
    {
        public async Task<AuthTamResultModel> LoginAsync(LoginTamModel model)
        {
            var client = new TokenClient("http://localhost:50383/connect/token", "password_client", "h8yI4DydzI5ZsKCMGTs9hfTdI1vRS3qfTo9Go92q3aM=");

            var token = client.RequestResourceOwnerPasswordAsync(model.Username, model.Password, scope: "offline_access content.api openid profile").GetAwaiter().GetResult();
           var result =  new AuthTamResultModel { Successed = true };
             if (token.IsError || string.IsNullOrWhiteSpace( token.AccessToken))
             {
                 result.Successed = false;
             }

            return result;
        }



     
    }
}
