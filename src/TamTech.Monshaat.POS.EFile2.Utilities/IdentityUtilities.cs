using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.EFile2.Utilities.Services;
using TamTechBackendSDK.IdentityService.Data;
using TamTechBackendSDK.IdentityService.Models;

namespace TamTech.Monshaat.POS.EFile2.Utilities
{
    public class IdentityUtilities
    {
        private readonly IEFileIdentityProviderService _eFileService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly HttpContext _httpContext;
        private readonly TamTechBackendSDK.IdentityService.Services.IUserManagerService _usersManagerService;




        public IdentityUtilities(IEFileIdentityProviderService eFileService,
                                    UserManager<ApplicationUser> userManager,
                                    SignInManager<ApplicationUser> signInManager,
                                    ApplicationDbContext context,
                                    IHttpContextAccessor httpContextAccessor,
                                     TamTechBackendSDK.IdentityService.Services.IUserManagerService usersManagerService
            //, IAppSettingsService settings
            )
        {
            _eFileService = eFileService;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _httpContext = httpContextAccessor.HttpContext;
            _usersManagerService = usersManagerService;
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
            await _signInManager.SignOutAsync();
            await _eFileService.LogoutAsync(efile_access_token);
            return true;
        }



        public async Task<bool> AddUserToVendorRole(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            var addingToRoleResult = await _userManager.AddToRolesAsync(user, new List<string> { Helpers.VendorRole });
            return addingToRoleResult.Succeeded;
        }

        public async Task<bool> CheckAciveVendor(string username)
        { 
            var user = await _userManager.FindByNameAsync(username);
            var IsActiveResult = await _usersManagerService.CheckUserAccountIsActivatedAsync<bool>(username);
            if (IsActiveResult.Data)
            {
                var roles = await _userManager.GetRolesAsync(user); ;
                if (roles != null && roles.Contains(Helpers.VendorRole))
                {
                    return true;
                }
            } 
            return false;
        }

    }
}