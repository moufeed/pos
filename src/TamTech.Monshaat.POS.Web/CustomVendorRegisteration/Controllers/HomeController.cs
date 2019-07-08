using Microsoft.AspNetCore.Mvc;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("Identity/V/[controller]/[Action]")]
        public IActionResult Index()
        {
           return Redirect("~/");

        }
    }
}