using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;    
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.MCI.EFile2.Services;
using TamTech.Monshaat.POS.IdentityService.Services;   
using TamTech.Monshaat.POS.Web.SDK.Core.Enums;
using TamTech.Monshaat.POS.Web.SDK.Core.Settings.Utilities;
using TamTech.Monshaat.POS.Web.SDK.Services.Identity;            
using TamTech.Monshaat.POS.Web.SDK.Services.Identity.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.Identity.Models.Params;
using TamTech.Monshaat.POS.Web.SDK.Services.Identity.Auth.Models;

namespace TamTech.Monshaat.POS.MCI.EFile2.Utilities
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

            string pass = $"{Constants.UserSecret}{username}";
            /// << check user credential 'username-password' at identity server and register user when not existed  >>  
            var checkedIdS4 = await _authService.ValidateVendorCredentialAsync(
                                                                    new SignupByName
                                                                    {
                                                                        Username = username,
                                                                        Password = pass
                                                                    }
                                                                    , TamTech.Monshaat.POS.IdentityService.Utilities.Constants.IDS4ApiKey
                                                                    , TamTech.Monshaat.POS.IdentityService.Utilities.Constants.IDS4SecretValue);
            if (!checkedIdS4.Success || !checkedIdS4.Data)
            {
                return false; 
            }
           
            var token = await _tokenTamService.GetTokenAsync(new IdentityService.Models.GetTokenModel
            {
                Username = username,
                Password = pass
            });      
            if (token == null)
            {
                return false;
            }  
            var claims = await _tokenTamService.GetUserClaimsAsync(token.AccessToken, PermissionTypeEnum.User);


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
                RolesNames = new List<string> { SettingsHelpers.VendorRoleName }
            });
            return res.Success;
        }

        public async Task<bool> CheckAciveVendor(string username)
        {

            var IsActiveResult = await _usersManagerService.CheckUserAccountIsActivatedAsync(new UserNameModel { UserName = username });
            if (IsActiveResult.Data)
            {
                var roles = await _rolesService.GetUserRolesAsync(username); ;
                if (roles != null && roles.Select(r => r.Name).Contains(SettingsHelpers.VendorRoleName))
                {
                    return true;
                }
            } 
            return false;
        }

    }
}