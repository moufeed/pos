using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Enums;
using TamTech.Monshaat.POS.Web.Services.ContentService.Menus;
using TamTech.Monshaat.POS.Web.Services.ContentService.Menus.Models;

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

        public async Task<MenuDto> GetNavbarMenuAsync()
        {
            var request = await _menusServices.GetPublicBySettingIdAsync((int)SettingKeysEnum.Navbar);
            return request.Data;
        }

        #endregion
    }
}
