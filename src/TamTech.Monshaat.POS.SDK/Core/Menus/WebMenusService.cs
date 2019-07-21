using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Core.Enums;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Menus;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Menus.Models;

namespace TamTechSDK.Web.Services.ContentService.Menus.PublicService
{
    public class WebPublicMenusService : IPortalMenusService
    {


        #region Props  
        public readonly IMenusServices _menusServices;
        #endregion


        #region Ctors
        public WebPublicMenusService(IMenusServices menusServices)
        {
            _menusServices = menusServices;
        }
        #endregion




        #region Utilities

        public async Task<IRequestProviderResult<MenuDto>> GetNavbarMenuAsync()
        {
            var request = await _menusServices.GetPublicBySettingIdAsync((int)SettingKeysEnum.Navbar);
            return request;
        }

        #endregion
    }
}
