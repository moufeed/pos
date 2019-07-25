using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TamTech.Monshaat.POS.IdentityService.Models;
using TamTech.Monshaat.POS.IdentityService.Services;
using TamTech.Monshaat.POS.IdentityService.Utilities;
using TamTech.Monshaat.POS.SDK.Models.VMs.Identity;
using TamTech.Monshaat.POS.SDK.Services.ExternalServices.Authentications;
using TamTech.Monshaat.POS.SDK.Services.ExternalServices.Authentications.Models;
using TamTech.Monshaat.POS.Web.SDK.Core.Enums;
using TamTech.Monshaat.POS.Web.SDK.Core.Extensions;
using TamTech.Monshaat.POS.Web.SDK.Services.Identity;
using TamTech.Monshaat.POS.Web.SDK.Services.Identity.Auth.Models;

namespace TamTech.Monshaat.POS.IdentityService.Controllers
{

    public abstract class AdminAccountController : Controller
    {
        #region Props  
        private readonly IExternalAuthService _externalAuthService;
        private readonly ITokenTamService _tokenTamService;
        private readonly IAuthService _authService;
        public readonly ILogger _logger;
        #endregion

        #region Ctors  
        public AdminAccountController(IExternalAuthService externalAuthService,
            ITokenTamService tokenTamService,
            IAuthService authService,
            ILogger<AdminAccountController> logger
            )
        {
            _externalAuthService = externalAuthService;
            _tokenTamService = tokenTamService;
            _authService = authService;
            _logger = logger;
        }
        #endregion


        #region Endpoints 
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            LoginTamViewModel model = BuildLoginViewModel(returnUrl);

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginTamInputModel model)
        {
            string username = null;
            try
            {
                username = model.Username;
                /// <<  validate model state  >>  
                if (!ModelState.IsValid) return View(BuildLoginViewModel(model));


                /// << external authentication provider  >>  
                var adResult = await _externalAuthService.LoginAsync(new ExternalLoginModel()
                {
                    Username = model.Username,
                    Password = model.Password
                });
                if (!adResult.Successed)
                {
                    ModelState.AddModelError(nameof(model.Username), "اسم المستخدم أو كلمة المرور خطأ!");
                    return View(BuildLoginViewModel(model));
                }


                /// << check user credential 'username-password' at identity server and register user when not existed  >>  
                var checkedIdS4 = await _authService.ValidatePOSAdminCredentialAsync(
                                                                        new SignupByName
                                                                        {
                                                                            Username = model.Username,
                                                                            Password = model.Password
                                                                        }
                                                                        , Constants.IDS4ApiKey
                                                                        , Constants.IDS4SecretValue);
                if (!checkedIdS4.Success || !checkedIdS4.Data)
                {
                    _logger.LogException(new Exception("Failed to invoke identifier! at TamTech.Monshaat.POS.IdentityService.Controllers.AdminAccountController.Login(LoginTamInputModel model) "),
                                            checkedIdS4);
                    ModelState.AddModelError("credential", "فشل أثناء التعرف على المسخدم");  //Failed to invoke identifier!
                    return View(BuildLoginViewModel(model));
                }

                /// << call jwt token from identity server4  >>  
                var token = await _tokenTamService.GetTokenAsync(new GetTokenModel
                {
                    Username = model.Username,
                    Password = model.Password
                });
                if (token == null)
                {
                    _logger.LogException(new Exception("Failed to invoke token! at TamTech.Monshaat.POS.IdentityService.Controllers.AdminAccountController.Login(LoginTamInputModel model) "),
                                         token);
                    ModelState.AddModelError("token", "فشل أثناء الحصول على رمز المستخدم");   //"Failed to invoke token!"
                    return View(BuildLoginViewModel(model));
                }

                /// << call claims principal from identity server4  >>  
                var claims = await _tokenTamService.GetUserClaimsAsync(token.AccessToken, PermissionTypeEnum.Admin);


                /// << Signin to context  >>  
                await HttpContext.SignInAsync(
                      CookieAuthenticationDefaults.AuthenticationScheme,
                      new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)),
                      new AuthenticationProperties());


                if (Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, username);
                throw;
            }

        }
        #endregion



        [HttpGet]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            try
            {
                await HttpContext.SignOutAsync();
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);   
            }
            return View("LoggedOut", new LoggedOutViewModel());
        }
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

        private LoginTamViewModel BuildLoginViewModel(LoginTamInputModel model)
        {
            var vm = BuildLoginViewModel(model.ReturnUrl);
            vm.Username = model.Username;
            vm.RememberLogin = model.RememberLogin;
            return vm;
        }


        #endregion
    }


}
