using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.EFile2.Utilities.Services;
using TamTechSDK.Common.Services.Identity;
using TamTechSDK.Common.Services.Identity.Models.Params;
using TamTechSDK.Web.Extensions;

namespace TamTechSDK.Web.Filters
{


    public class UserActivityFilter : ActionFilterAttribute, IActionFilter
    {

        private readonly IUsersManagerService _usersManagerService;

        public UserActivityFilter(IUsersManagerService usersManagerService)
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

                if (context.Result == null)
                    await next();
            }
        }



    }

}

