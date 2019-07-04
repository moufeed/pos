using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;
using TamTechBackendSDK.Common.Extensions;
using TamTechBackendSDK.IdentityService.Models;

namespace TamTechSDK.Web.Filters
{


    public class UserContextUpdatedFilter : ActionFilterAttribute, IActionFilter
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserContextUpdatedFilter(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var controller = context.Controller as Controller;

            if (controller != null)
            {


                if (controller.HttpContext.User.Identity.IsAuthenticated)
                {
                    var contextRoles = controller.HttpContext.User.Identity.GetUserRoles();
                    if (contextRoles == null || contextRoles.Count == 0)
                    {
                        var user = await _userManager.FindByIdAsync(controller.HttpContext.User.Identity.GetUserId());
                        var roles = await _userManager.GetRolesAsync(user);
                        if (roles != null && roles.Count > 0)
                        {
                            context.Result = new RedirectToRouteResult(new RouteValueDictionary {
                                      { "Controller","OAuth" },
                                      { "Action", "Logout" } ,
                                      {"returnUrl",controller.HttpContext.Request.Path } });
                            return;
                        }
                    }
                }





                if (context.Result == null)
                    await next();
            }
        }

    }
}