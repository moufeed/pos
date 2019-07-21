using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Core.Enums;
using TamTech.Monshaat.POS.Web.SDK.Core.Extensions;
using TamTech.Monshaat.POS.Web.SDK.Services.Identity;
using TamTech.Monshaat.POS.Web.SDK.Services.Identity.Models.Params;

namespace TamTech.Monshaat.POS.Web.SDK.Core.Filters
{
    public class ActiveVendor : ActionFilterAttribute, IActionFilter
    {
        private readonly IUsersManagerService _usersManagerService;

        public ActiveVendor(IUsersManagerService usersManagerService)
        {
            _usersManagerService = usersManagerService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var controller = context.Controller as Controller;

            if (controller != null)
            {
                if (controller.HttpContext.User.Identity.IsAuthenticated)
                {
                    if (controller.HttpContext.User.Identity.GetPermission() == PermissionTypeEnum.Admin.ToString())
                    {
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary {
                                      { "Controller","account" },
                                      { "Action", "AccessDenied" },
                                      { "Area", "Identity" }});
                        return;
                    }
                    else
                    {    
                        var IsActiveResult = await _usersManagerService.CheckUserAccountIsActivatedAsync(new UserNameModel { UserName = controller.HttpContext.User.Identity.GetUsername() });

                        if (!IsActiveResult.Data)
                        {
                            context.Result = new RedirectToRouteResult(new RouteValueDictionary {
                                      { "Controller","account" },
                                      { "Action", "blocked" },
                                      { "Area", "Identity" }});
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

