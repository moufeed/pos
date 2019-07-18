using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters; 
using TamTech.Monshaat.POS.Web.Core.Settings.Utilities;

namespace TamTech.Monshaat.POS.Web.Core.Filters
{ 
    public class AdminFilter : ActionFilterAttribute, IActionFilter
    {  
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var controller = context.Controller as Controller;

            if (controller != null)
            {

                controller.ViewBag.AppVersion = SettingsHelpers.AppVersion; 
            } 

        }
    }
}
