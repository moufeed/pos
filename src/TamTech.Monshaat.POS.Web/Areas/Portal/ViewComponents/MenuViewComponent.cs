using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Core.Extensions;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Menus;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Menus.Enums;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Menus.Models;

namespace TamTech.Monshaat.POS.Web.Areas.Portal.ViewComponents
{
    public class MenuViewComponent: ViewComponent
    {
        private readonly IPortalMenusService _publicMenusService;
        private static int conter = 0;
        public readonly ILogger _logger;

        public MenuViewComponent(IPortalMenusService publicMenusService, ILogger<MenuViewComponent> logger)
        {
            _publicMenusService = publicMenusService;
            var culture = CultureInfo.CurrentCulture.Name;
            _logger = logger;
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
                _logger.LogException(ex);
            }
            return View("~/Areas/Portal/Views/Shared/Components/menu/Default.cshtml");
        }
 
    }
}
