using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;    
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using TamTech.Monshaat.POS.MCI.EFile2.Utilities;
using Microsoft.Extensions.Logging;
using System;
using TamTech.Monshaat.POS.Web.SDK.Core.Extensions;

namespace TamTech.Monshaat.POS.MCI.EFile2.Filters
{


    public class AuthorizePermission : ActionFilterAttribute, IActionFilter
    {
        #region Props 
        public readonly ILogger _logger;
        #endregion

        #region Ctors  
        public AuthorizePermission(ILogger<AuthorizePermission> logger)
        {
            _logger = logger;
        }
        #endregion
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            try
            {
                var controller = context.Controller as Controller;

                if (controller != null)
                {
                    // Case 1 : when access token cookie of EFile2 not exist...
                    var efile_access_token = controller.Request.Cookies[Constants.EFileTokenCookieName];
                    if (string.IsNullOrWhiteSpace(efile_access_token))
                    {
                        await controller.HttpContext.SignOutAsync();
                        // await HttpContext.SignOutAsync();
                        context.Result = RedirectToRegisterVendor();
                        return;
                    }


                    if (context.Result == null)
                        await next();
                }
            }
            catch (Exception ex)
            {
                _logger.LogException(ex );
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






}

