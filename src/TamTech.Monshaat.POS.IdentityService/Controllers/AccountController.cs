using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TamTech.Monshaat.POS.IdentityService.Models;
using TamTech.Monshaat.POS.IdentityService.Services;
using TamTech.Monshaat.POS.IdentityService.Utilities;

namespace TamTech.Monshaat.POS.IdentityService.Controllers
{     

    public abstract  class AccountController :  Controller
    {  
        #region Props  
        private readonly IAuthTamService _authTamService;
        #endregion

        #region Ctors  
        public AccountController(IAuthTamService authTamService)
        {
            _authTamService = authTamService;
        }
        #endregion


        #region Endpoints 
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            LoginTamViewModel model  = BuildLoginViewModel(returnUrl);
         
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginTamInputModel model)
        {

            if (!ModelState.IsValid) return View( BuildLoginViewModel(model));

            //if(string.IsNullOrWhiteSpace(model.Username) || string.IsNullOrWhiteSpace(model.Password))
            //{
            //    return BadRequest("The Username and Password is required");  
            //}
            var adResult = await _authTamService.LoginAsync(new LoginTamModel()
                                                            {
                                                                Username = model.Username,
                                                                Password = model.Password
                                                            });
            if (!adResult.Successed)
            {
                ModelState.AddModelError(nameof(model.Username) , "The Username or Password is wrong!");
                return View(BuildLoginViewModel(model));
            }

            var client = new TokenClient("http://localhost:50383/connect/token", "password_client", "h8yI4DydzI5ZsKCMGTs9hfTdI1vRS3qfTo9Go92q3aM=");

            var token =   client.RequestResourceOwnerPasswordAsync(model.Username, model.Password, scope: "offline_access content.api identity.api openid profile").GetAwaiter().GetResult();

           if(token.IsError)
            {   
                ModelState.AddModelError(nameof(model.Username), token.Error);
                return View(BuildLoginViewModel(model));
            }


            var info = await SendAsync("http://localhost:50383/connect/userinfo", token.AccessToken);

            var claims = new List<Claim>()
               {
                        new Claim(Constants.JWTClaimName, token.AccessToken)
               };

          foreach (var pair in info )
            {
                var val = pair.Value.ToString();
                if (!string.IsNullOrWhiteSpace(val) && val.StartsWith('[') && val.EndsWith(']'))
                {
                    var value = JsonConvert.DeserializeObject<List<string>>(val);
                    value.ForEach(c => claims.Add(new Claim(pair.Key, c)));
                }
                else
                {
                    claims.Add(new Claim(pair.Key, val)  ) ;
                }
            }
                 
         
            await HttpContext.SignInAsync(
                  CookieAuthenticationDefaults.AuthenticationScheme,
                  new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)),
                  new AuthenticationProperties());


            var user = HttpContext.User;
            var isAuthenticated = HttpContext.User.Identity.IsAuthenticated;    

            if (Url.IsLocalUrl(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }       
            return Redirect("~/");                
          
        }         
        #endregion

        #region Utilities  
        private LoginTamViewModel BuildLoginViewModel(string returnUrl)
        {
          
            return new LoginTamViewModel
            {
                AllowRememberLogin = false,
                EnableLocalLogin = true,
                ReturnUrl = returnUrl,       
            };
        }

        private LoginTamViewModel  BuildLoginViewModel(LoginTamInputModel model)
        {
            var vm =  BuildLoginViewModel(model.ReturnUrl);
            vm.Username = model.Username;
            vm.RememberLogin = model.RememberLogin;
            return vm;
        }

        public async Task<Dictionary<string, object>> SendAsync(string uri, string token = null)
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
        #endregion
    }


}
