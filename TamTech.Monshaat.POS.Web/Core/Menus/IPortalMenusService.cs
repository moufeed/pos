using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Services.ContentService.Menus.Models;

namespace TamTechSDK.Common.Services.ContentService.Menus
{
    public interface IPortalMenusService
    {
        Task<MenuDto> GetNavbarMenuAsync();
    }
}
