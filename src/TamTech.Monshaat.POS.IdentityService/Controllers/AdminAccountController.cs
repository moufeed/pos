using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TamTech.Monshaat.POS.IdentityService.Models;
using TamTech.Monshaat.POS.IdentityService.Services;
using TamTech.Monshaat.POS.IdentityService.Utilities;
using TamTech.Monshaat.POS.SDK.Services.ExternalServices.Authentications;
using TamTech.Monshaat.POS.SDK.Services.ExternalServices.Authentications.Models;
using TamTech.Monshaat.POS.Web.Services.Identity;

namespace TamTech.Monshaat.POS.IdentityService.Controllers
{

    public abstract class AdmibAccountController : Controller
    {
        #region Props  
        private readonly IExternalAuthService _externalAuthService;
        private readonly ITokenTamService _tokenTamService;
        private readonly IAuthService _authService;
        #endregion

        #region Ctors  
        public AdmibAccountController(IExternalAuthService externalAuthService, ITokenTamService tokenTamService, IAuthService authService)
        {
            _externalAuthService = externalAuthService;
            _tokenTamService = tokenTamService;
            _authService = authService;
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
                ModelState.AddModelError(nameof(model.Username), "The Username or Password is wrong!");
                return View(BuildLoginViewModel(model));
            }


            /// << check user credential 'username-password' at identity server and register user when not existed  >>  
            var checkedIdS4 = await _authService.ValidatePOSAdminCredentialAsync(
                                                                    new Web.Services.Identity.Auth.Models.SignupByName
                                                                    {
                                                                        Username = model.Username,
                                                                        Password = model.Password
                                                                    }
                                                                    , Constants.IDS4ApiKey
                                                                    , Constants.IDS4SecretValue);
            if (!checkedIdS4.Success || !checkedIdS4.Data)
            {
                ModelState.AddModelError("credential", "Failed to invoke identifier!");
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
                ModelState.AddModelError("token", "Failed to invoke token!");
                return View(BuildLoginViewModel(model));
            }

            /// << call claims principal from identity server4  >>  
            var claims = await _tokenTamService.GetUserClaimsAsync(token.AccessToken);


            /// << Signin to context  >>  
            await HttpContext.SignInAsync(
                  CookieAuthenticationDefaults.AuthenticationScheme,
                  new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)),
                  new AuthenticationProperties());


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
