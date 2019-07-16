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
using TamTech.Monshaat.POS.Web.Services.Identity;

namespace TamTech.Monshaat.POS.IdentityService.Controllers
{     

    public abstract  class AccountController :  Controller
    {  
        #region Props  
        private readonly IAuthTamService _authTamService;
        private readonly ITokenTamService _tokenTamService;
        private readonly IAuthService _authService;
        #endregion

        #region Ctors  
        public AccountController(IAuthTamService authTamService, ITokenTamService  tokenTamService)
        {
            _authTamService = authTamService;
            _tokenTamService = tokenTamService;
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
                     

            var token = await   _tokenTamService.GetTokenAsync(model.Username);    
            if (token == null)
            {
              //  ResetPOSAdminPasswordAsync
            }
               if (token == null)
            {
                ModelState.AddModelError("token", "Failed to invoke identifier!");
                return View(BuildLoginViewModel(model));
            }
                  
            var claims = await _tokenTamService.GetUserClaimsAsync(token.AccessToken);        
                 
         
            await HttpContext.SignInAsync(
                  CookieAuthenticationDefaults.AuthenticationScheme,
                  new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)),
                  new AuthenticationProperties());


         //   var user = HttpContext.User;
       //     var isAuthenticated = HttpContext.User.Identity.IsAuthenticated;    

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

     
        #endregion
    }


}
