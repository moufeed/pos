using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.IdentityService.Models;
using TamTech.Monshaat.POS.IdentityService.Utilities;

namespace TamTech.Monshaat.POS.IdentityService.Services
{
    public class TokenTamService : ITokenTamService
    {    
        public async Task<TokenModel> GetTokenAsync(GetTokenModel model)
        {
            
            if (model == null || string.IsNullOrWhiteSpace(model.Username)|| string.IsNullOrWhiteSpace(model.Password)) return null;
            var client = new TokenClient("http://localhost:50383/connect/token", "password_client", "h8yI4DydzI5ZsKCMGTs9hfTdI1vRS3qfTo9Go92q3aM=");

            var token = client.RequestResourceOwnerPasswordAsync(model.Username, model.Password, scope: "offline_access content.api openid profile").GetAwaiter().GetResult();
           
            if (token.IsError || string.IsNullOrWhiteSpace( token.AccessToken))
             {
                 return null;
             }
            var result = token.MapToModel();
            return result;
        }


        public async Task<List<Claim>> GetUserClaimsAsync(string accessToken)
        {
            var info = await SendAsync("http://localhost:50383/connect/userinfo", accessToken);

            if (info == null) return null;
            List<Claim> claims = new List<Claim>()
            {
                new Claim(Constants.JWTClaimName, accessToken)
            };

            foreach (var pair in info)
            {
                var val = pair.Value.ToString();
                if (!string.IsNullOrWhiteSpace(val) && val.StartsWith('[') && val.EndsWith(']'))
                {
                    var value = JsonConvert.DeserializeObject<List<string>>(val);
                    value.ForEach(c => claims.Add(new Claim(pair.Key, c)));
                }
                else
                {
                    claims.Add(new Claim(pair.Key, val));
                }
            }

            return claims;


        }


        private async Task<Dictionary<string, object>> SendAsync(string uri, string token = null)
        {
            try
            {
                var httpClient = new HttpClient();

                if (!string.IsNullOrEmpty(token))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(uri),
                };

                HttpResponseMessage response = await httpClient.SendAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string serialized = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(serialized);
                    return data;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Http Request Provider Exception - ", ex);
            }
        }
    }
}
