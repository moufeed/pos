using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Enums;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Menus;
using TamTech.Monshaat.POS.Web.Services.ContentService.Menus.Models;

namespace TamTechSDK.Web.Services.ContentService.Menus.PublicService
{
    public class CashedMenusService : IPortalMenusService
    {


        #region Props 
        public static MenuDto _navbar;


        public readonly IMenusServices _menusServices;
        #endregion


        #region Ctors
        public CashedMenusService(IMenusServices menusServices)
        {
            _menusServices = menusServices;
        }
        #endregion




        #region Utilities

        public async Task<IRequestProviderResult<MenuDto>> GetNavbarMenuAsync()
        {

            var result = new RequestProviderResult<MenuDto>();
            var lang = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

            if (_navbar == null || _navbar == default(MenuDto) || _navbar.Lang.Equals(lang, StringComparison.InvariantCultureIgnoreCase))
            {
                var nav = await _menusServices.GetPublicBySettingIdAsync((int)SettingKeysEnum.Navbar);
                result.Success = nav.Success;
                result.Data = nav.Data;
                result.Messages = nav.Messages;
                result.StatusCode = nav.StatusCode;
                result.JsonHeader = nav.JsonHeader;
            }
            return result;


        }

        #endregion
    }
}
