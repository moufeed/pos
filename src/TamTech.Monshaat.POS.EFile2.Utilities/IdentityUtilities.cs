using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;    
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.EFile2.Utilities.Services;
using TamTech.Monshaat.POS.IdentityService.Services;
using TamTech.Monshaat.POS.Web.Core.Constants;
using TamTech.Monshaat.POS.Web.Services.Identity;
using TamTech.Monshaat.POS.Web.Services.Identity.Auth.Models;
using TamTech.Monshaat.POS.Web.Services.Identity.Models;
using TamTech.Monshaat.POS.Web.Services.Identity.Models.Params;

namespace TamTech.Monshaat.POS.EFile2.Utilities
{
    public class IdentityUtilities
    {


        #region Props  
        private readonly IEFileIdentityProviderService _eFileService;
        private readonly HttpContext _httpContext;
        private readonly IUsersManagerService _usersManagerService;
        private readonly IRolesService _rolesService;
        private readonly IAuthService _authService;
        private readonly ITokenTamService _tokenTamService;
        #endregion

        #region Ctors     
        public IdentityUtilities(IEFileIdentityProviderService eFileService,
            IUsersManagerService usersManagerService,
            IRolesService rolesService,
            IAuthService authService,
            ITokenTamService tokenTamService,
                                    IHttpContextAccessor httpContextAccessor)
        {
            _eFileService = eFileService;
            _usersManagerService = usersManagerService;
            _httpContext = httpContextAccessor.HttpContext;
            _rolesService = rolesService;
            _authService =  authService;
            _tokenTamService = tokenTamService;
        }     
        #endregion



        public async Task<bool> Signup(string efile_access_token)
        {
            var username = await _eFileService.GetUsernameByAccessTokenAsync(efile_access_token);

            if (string.IsNullOrWhiteSpace(username)) return false;

            var info = await _usersManagerService.GetUserByUsernameAsync(username);
            if (info.Data == null || !info.Success)
            {
              var  result = await _authService.SignupByNameAsync(new SignupByName
                {
                    Username = username,
                    Password = $"{TamTech.Monshaat.POS.IdentityService.Utilities.Constants.SecretKey}{username}",
                });
               
            }
            var token = await _tokenTamService.GetTokenAsync(username);      
            if (token == null)
            {
                return false;
            }  
            var claims = await _tokenTamService.GetUserClaimsAsync(token.AccessToken);


            await _httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)),
                new AuthenticationProperties());    
         
            return true;
        }



        public async Task<bool> Signout(string efile_access_token)
        {
            await _httpContext.SignOutAsync();
            await _eFileService.LogoutAsync(efile_access_token);
            return true;
        }



        public async Task<bool> AddUserToVendorRole(string username)
        {
            var res = await _usersManagerService.AddUserToRolesAsync(new AddUserToRolesModel 
            {
                      UserName = username    ,
                RolesNames = new List<string> { Helpers.VendorRole }
            });
            return res.Success;
        }

        public async Task<bool> CheckAciveVendor(string username)
        {

            var IsActiveResult = await _usersManagerService.CheckUserAccountIsActivatedAsync(new UserNameModel { UserName = username });
            if (IsActiveResult.Data)
            {
                var roles = await _rolesService.GetUserRolesAsync(username); ;
                if (roles != null && roles.Select(r => r.Name).Contains(Helpers.VendorRole))
                {
                    return true;
                }
            } 
            return false;
        }

    }
}