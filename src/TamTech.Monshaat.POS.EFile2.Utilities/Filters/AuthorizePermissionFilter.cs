using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using TamTech.Monshaat.POS.EFile2.Utilities.Services;  

namespace TamTech.Monshaat.POS.EFile2.Utilities.Filters
{


    public class AuthorizePermission : ActionFilterAttribute, IActionFilter
    {
      
        public AuthorizePermission()
        {     
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
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
             

               if( context.Result == null)
               await next();
            }
        }


        private RedirectToRouteResult RedirectToRegisterVendor()
        {
            return new RedirectToRouteResult( new RouteValueDictionary {
                                      { "Controller", Constants.VendorController },
                                      { "Action", Constants.RegisterAction },
                                      { "Area", "Portal" }});
        }
    }

    

    

   
}

