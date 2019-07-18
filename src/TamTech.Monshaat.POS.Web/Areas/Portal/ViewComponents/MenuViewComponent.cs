using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Services.ContentService.Menus;
using TamTech.Monshaat.POS.Web.Services.ContentService.Menus.Enums;
using TamTech.Monshaat.POS.Web.Services.ContentService.Menus.Models;

namespace TamTech.Monshaat.POS.Web.Areas.Portal.ViewComponents
{
    public class MenuViewComponent: ViewComponent
    {
        private readonly IPortalMenusService _publicMenusService;
        private static int conter = 0;
        

        public MenuViewComponent(IPortalMenusService publicMenusService)
        {
            _publicMenusService = publicMenusService;
            var culture = CultureInfo.CurrentCulture.Name;
           
        }


      

        public async Task<IViewComponentResult> InvokeAsync()
        {
            conter++;
            try
            {
                var menu = await _publicMenusService.GetNavbarMenuAsync();
                if (menu.Success)
                {
                    ViewData["counter"] = conter;
                    return View("~/Areas/Portal/Views/Shared/Components/menu/Default.cshtml",menu.Data);
                }
            }
            catch (Exception ex)
            {
                 
            }
            return View("~/Areas/Portal/Views/Shared/Components/menu/Default.cshtml");
        }
 
    }
}
