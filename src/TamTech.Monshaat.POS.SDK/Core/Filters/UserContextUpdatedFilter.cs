using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Extensions;
using TamTech.Monshaat.POS.Web.Services.Identity;  

namespace TamTech.Monshaat.POS.Web.Core.Filters
{


    public class UserContextUpdatedFilter : ActionFilterAttribute, IActionFilter
    {
        private readonly IRolesService _reolsService;

        public UserContextUpdatedFilter(IRolesService reolsService)
        {
            _reolsService = reolsService;
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
                        var roles = await _reolsService.GetUserRolesAsync(controller.HttpContext.User.Identity.GetUsername());
                        if (roles != null && roles.Count() > 0)
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