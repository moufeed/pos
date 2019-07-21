using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Menus.Models;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Menus
{
    public interface IPortalMenusService
    {
        Task<IRequestProviderResult<MenuDto>> GetNavbarMenuAsync();
    }
}
