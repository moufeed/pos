using IdentityModel.Client;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;       
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.IdentityService.Models;
using TamTech.Monshaat.POS.IdentityService.Utilities;
using TamTech.Monshaat.POS.Web.SDK.Core.Enums;
using TamTech.Monshaat.POS.Web.SDK.Core.Extensions;
using TamTech.Monshaat.POS.Web.SDK.Core.Settings.Utilities;
using TamTech.Monshaat.POS.Web.SDK.Models.Shared;

namespace TamTech.Monshaat.POS.IdentityService.Services
{
    public class TokenTamService : ITokenTamService
    {

        private readonly BackendApiSettings _settings;
        public readonly ILogger _logger;

        public TokenTamService(BackendApiSettings settings, ILogger<TokenTamService> logger)
        {
            _settings = settings;
            _settings.Url = _settings.Url.TrimEnd('/');
            _logger = logger;
        }

        public async Task<TokenModel> GetTokenAsync(GetTokenModel model)
        {
            string username = null;
            try
            {
                username = model.Username;
                if (model == null || string.IsNullOrWhiteSpace(model.Username) || string.IsNullOrWhiteSpace(model.Password)) return null;
                var client = new TokenClient($"{_settings.Url}/connect/token", _settings.ClientId, _settings.ClientSecret);

                var token = client.RequestResourceOwnerPasswordAsync(model.Username, model.Password, scope: _settings.ClientScope).GetAwaiter().GetResult();

                if (token.IsError || string.IsNullOrWhiteSpace(token.AccessToken))
                {
                    return null;
                }
                var result = token.MapToModel();
                return result;
            }
            catch (Exception ex)
            {      
                _logger.LogException(ex, username);
                throw;
            }
        }


        public async Task<List<Claim>> GetUserClaimsAsync(string accessToken, PermissionTypeEnum permission)
        {
            try
            {
                var info = await SendAsync($"{_settings.Url}/connect/userinfo", accessToken);

            if (info == null) return null;
            List<Claim> claims = new List<Claim>()
            {
                new Claim(Constants.JWTClaimName, accessToken)  ,    
            
            };
          

            bool isVendor = false;
            bool claimTypeIsRole = false;    
            foreach (var pair in info)
            {

               if (permission == PermissionTypeEnum.User &&
                     "Role".Equals(pair.Key, StringComparison.InvariantCultureIgnoreCase))
                {
                    claimTypeIsRole = true;
                }
                var val = pair.Value.ToString();
                if (!string.IsNullOrWhiteSpace(val) && val.StartsWith('[') && val.EndsWith(']'))
                {     
                    var value = JsonConvert.DeserializeObject<List<string>>(val);
                    foreach (var v in value)
                    {
                        claims.Add(new Claim(pair.Key, v));
                        if (claimTypeIsRole && SettingsHelpers.VendorRoleName.Equals(v))
                        {
                            isVendor = true;
                        }
                    } 
                }
                else
                {
                    claims.Add(new Claim(pair.Key, val));
                    if (claimTypeIsRole && SettingsHelpers.VendorRoleName.Equals(val))
                    {
                        isVendor = true;
                    }
                }
               
            }

            /// <  add Admin permission when permission type is Admin.  > 
            if (permission == PermissionTypeEnum.Admin)
            {
                claims.Add(new Claim(Constants.PermissionClaimName, permission.ToString()));
            }
            else
            {
                /// <  add Vendor permission when the user has a Vender role.  > 
                if (isVendor)
                {
                    claims.Add(new Claim(Constants.PermissionClaimName, PermissionTypeEnum.Vendor.ToString()));
                }
                else
                {   /// <  add Vendor permission when the user has not a role.  > 
                    claims.Add(new Claim(Constants.PermissionClaimName, permission.ToString()));
                }
            }
                
               


            return claims;

            }
            catch (Exception ex)
            {
                _logger.LogException(ex, accessToken, permission);
                throw;
            }
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
                _logger.LogException(ex, uri, token);
                throw new Exception("Http Request Provider Exception - ", ex);
            }
        }
    }

   
}
