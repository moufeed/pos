using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using TamTech.Monshaat.POS.MCI.EFile2.Services;
using TamTech.Monshaat.POS.Web.SDK.Core.Extensions;
using TamTech.Monshaat.POS.MCI.EFile2.Utilities;
using Microsoft.Extensions.Logging;
using System;

namespace TamTech.Monshaat.POS.MCI.EFile2.Filters
{


    public class AuthorizeEFile : ActionFilterAttribute, IActionFilter
    {
        #region Props  
        private readonly IEFileIdentityProviderService _eFileService;
        public readonly ILogger _logger;
        #endregion

        #region Ctors  
        public AuthorizeEFile(IEFileIdentityProviderService eFileService, ILogger<AuthorizeEFile> logger)
        {
            _eFileService = eFileService;
            _logger = logger;
        }
        #endregion

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string efile_access_token = null;
            bool isAuthenticated = false;
            string username = null;
            try
            {
                var controller = context.Controller as Controller;

                if (controller != null)
                {
                    // Case 1 : when access token cookie of EFile2 not exist...
                    efile_access_token = controller.Request.Cookies[Constants.EFileTokenCookieName];
                    if (string.IsNullOrWhiteSpace(efile_access_token))
                    {
                        await controller.HttpContext.SignOutAsync();
                        // await HttpContext.SignOutAsync();
                        context.Result = RedirectToRegisterVendor();
                        return;
                    }

                    // Case 2 : when access token not valid...
                    isAuthenticated = await _eFileService.IsAuthenticatedAsync(efile_access_token);
                    if (!isAuthenticated)
                    {
                        await controller.HttpContext.SignOutAsync();
                        controller.Response.Cookies.Delete(Constants.EFileTokenCookieName);
                        context.Result = RedirectToRegisterVendor();
                        return;
                    }

                    // Case 3 : when username of EFile2 does not match username of (Http Context Identity)...
                    username = await _eFileService.GetUsernameByAccessTokenAsync(efile_access_token);
                    if (username != controller.HttpContext.User.Identity.GetUsername())
                    {
                        await controller.HttpContext.SignOutAsync();// await _signInManager.SignOutAsync();
                        controller.Response.Cookies.Delete(Constants.EFileTokenCookieName);
                        await _eFileService.LogoutAsync(efile_access_token);
                        context.Result = RedirectToRegisterVendor();
                        return;
                    }

                    if (context.Result == null)
                        await next();
                }
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, $"efile_access_token : {efile_access_token}",
                                        $"isAuthenticated : {isAuthenticated}",
                                        $"username : {username}");
                throw;
            }
        }


        private RedirectToRouteResult RedirectToRegisterVendor()
        {
            return new RedirectToRouteResult(new RouteValueDictionary {
                                      { "Controller", Constants.VendorController },
                                      { "Action", Constants.RegisterAction },
                                      { "Area", "Portal" }});
        }
    }

    public class UnauthorizedResult : ActionResult
    {
        public override void ExecuteResult(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = 401;
        }
    }



}

