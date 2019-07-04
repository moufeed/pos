using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Services.ContentService.Menus.Models;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Menus
{
    public interface IPortalMenusService
    {
        Task<MenuDto> GetNavbarMenuAsync();
    }
}
