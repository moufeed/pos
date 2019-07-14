using Microsoft.AspNetCore.Mvc;

namespace TamTech.Monshaat.POS.Web.Areas.Identity.Controllers
{
    public interface IAccountController
    {
        IActionResult AccessDenied(string returnUrl = "");
        IActionResult Blocked(string returnUrl = "");
        IActionResult Info(string returnUrl = "");
    }
}