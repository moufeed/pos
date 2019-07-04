using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using TamTechSDK.Common.Services.Identity;
using TamTechSDK.Common.Services.Identity.Auth.Models;
using TamTechSDK.Web.Services.Configurations.Cultures;
using TamTechSDK.Web.Services.Telemetry;
using TamTechSDK.Web.Services.Validations;

namespace TamTechSDK.Web.Controllers.Identity
{

    public class AuthController : IdentityBaseController
    {

        #region Props  
        private readonly IAuthService _accountsService;
        private readonly IExpressionValidation _expressionValidation;
        #endregion


        #region Ctors 
        public AuthController(ITelemetryService telemetryClientService, IAuthService accountsService,
            IExpressionValidation expressionValidation)
            : base(telemetryClientService)
        {
            _expressionValidation = expressionValidation;
            _accountsService = accountsService;
        }
        #endregion

        #region Actions 
        public virtual async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpGet("[Area]/[Controller]/ForgotPassword")]
        public virtual async Task<IActionResult> ForgottenPassword()
        {
            return View("ForgottenPassword");
        }

        [HttpPost("[Area]/[Controller]/ForgotPassword")]
        public virtual async Task<IActionResult> ForgottenPassword(string email, IFormCollection collection)
        {

            if (_expressionValidation.EmailIsFormatted(email))
            {
                try
                {
                    var result = await _accountsService.GenerateResetPasswordByEmailSendig(email);

                    if (result.Success)
                    {
                        TempData["email"] = email;
                        return View("ForgottenPassword");
                    }
                }
                catch (Exception ex)
                {
                    TrackException(ex);
                }

                TempData["error"] = "oops!! something wrong. ";
                return View("ForgottenPassword");
            }
            else
            {
                TempData["error"] = "oops!! Invalid Email Format";
                return View("ForgottenPassword", ModelState);
            }

        }


        [HttpGet("[Area]/[Controller]/resetpassword")]
        public virtual async Task<IActionResult> Resetpassword()
        {
            ViewBag.Token = Request.Query["t"].ToString();
            ViewBag.UserId = Request.Query["u"].ToString();

            return View("ResetPassword");
        }

        [HttpPost("[Area]/[Controller]/resetpassword")]
        public virtual async Task<IActionResult> Resetpassword(ResetPassword model)
        {
            TempData["showMessage"] = null;


            try
            {
                if (ModelState.IsValid)
                {
                    if (string.Equals(model.NewPassword, model.ConfirmPassword))
                    {
                        var result = await _accountsService.ResetPassword(model);

                        if (result.Success)
                        {
                            TempData["showMessage"] = true;
                            return View("ResetPassword");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("password", "Password does not match the confirm password");
                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            ViewBag.Token = Request.Query["t"].ToString();
            ViewBag.UserId = Request.Query["u"].ToString();
            return View("ResetPassword", model);
        }


        #endregion
        [Authorize]
        [HttpGet("[Area]/[Controller]/ChangePassword")]
        public virtual async Task<IActionResult> ChangePassword()
        {
            return View();
        }


        [Authorize]
        [HttpPost("[Area]/[Controller]/ChangePassword")]
        public virtual async Task<IActionResult> ChangePassword(ChangePassword model)
        {
            TempData["showMessage"] = null;

            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _accountsService.ChangePassword(model);
                    if (result.Success)
                    {
                        TempData["showMessage"] = true;
                        return View("ChangePassword");
                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View();
        }




    }
}
