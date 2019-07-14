using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;    
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.EFile2.Utilities.Services;
using TamTech.Monshaat.POS.Web.Services.Identity;
using TamTech.Monshaat.POS.Web.Services.Identity.Models;
using TamTech.Monshaat.POS.Web.Services.Identity.Models.Params;

namespace TamTech.Monshaat.POS.EFile2.Utilities
{
    public class IdentityUtilities
    {
        private readonly IEFileIdentityProviderService _eFileService;
        private readonly HttpContext _httpContext;
        private readonly IUsersManagerService _usersManagerService;
        private readonly IRolesService _rolesService;




        public IdentityUtilities(IEFileIdentityProviderService eFileService,
            IUsersManagerService usersManagerService,
            IRolesService rolesService,
                                    IHttpContextAccessor httpContextAccessor)
        {
            _eFileService = eFileService;
            _usersManagerService = usersManagerService;
            _httpContext = httpContextAccessor.HttpContext;
            _rolesService = rolesService;
        }



        public async Task<bool> Signup(string efile_access_token)
        {
            var username = await _eFileService.GetUsernameByAccessTokenAsync(efile_access_token);

            if (string.IsNullOrWhiteSpace(username)) return false;

            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                using (var scope = await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadUncommitted))
                {
                    user = new ApplicationUser
                    {
                        UserName = username,
                        // PhoneNumber = efile_access_token,
                    };
                    var result = await _userManager.CreateAsync(user);
                    if (!result.Succeeded)
                    {
                        scope.Rollback();
                        throw new Exception(result.Errors.Select(e => e.Description)?.FirstOrDefault());
                    }

                    // var roles = _appSettings.GetVendorRoleName();
                    //  if (roles != null && roles.Count > 0)
                    // {
                    //var addingToRoleResult = await _userManager.AddToRolesAsync(user, new List<string> { Helpers.VendorRole });

                    //if (!addingToRoleResult.Succeeded)
                    //{
                    //    scope.Rollback();
                    //    throw new Exception(result.Errors.Select(e => e.Description)?.FirstOrDefault());
                    //}
                    // }

                    scope.Commit();
                }
            }

            await _signInManager.SignInAsync(user, false);
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