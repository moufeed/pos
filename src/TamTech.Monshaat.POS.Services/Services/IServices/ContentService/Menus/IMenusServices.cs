using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Menus.Models;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Menus
{
    public interface IMenusServices
    {

      
        #region {Public Menus}  

        //   Task<IRequestProviderResult<MenuDto>> GetPublicDynamicByKeyAsync(string key);

       Task<IRequestProviderResult<MenuDto>> GetPublicByKeyAsync( string lang);

        Task<IRequestProviderResult<MenuDto>> GetPublicBySettingIdAsync(int settingId);
        #endregion




        #region {Menus Manager}  

        #region {Get} 

        Task<IRequestProviderResult<List<MenuLiteDto>>> GetAllAsync(string lang);
       

        Task<IRequestProviderResult<MenuDto>> GetByIdAsync(Guid id ,string lang);
       

        #endregion


        #region  {Menu}  Create / Edit / Delete / Publish 

        Task<IRequestProviderResult<Guid>> CreateAsync(CreateMenuDto menu);

        Task<IRequestProviderResult<bool>> EditAsync(UpdateMenuDto menu);

        Task<IRequestProviderResult<bool>> DeleteByIdAsync(Guid id);


        #endregion


        #region {Menu Items}  Create / Edit / Delete / Publish 

        Task<IRequestProviderResult<string>> CreateMenuItemAsync(CreateMenuItemDto model);
       

        Task<IRequestProviderResult<bool>> EditMenuItemAsync(UpdateMenuItemDto model);  


        Task<IRequestProviderResult<bool>> PublishMenuItemAsync(MenuItemKeysDto model);


        Task<IRequestProviderResult<bool>> DeleteMenuItemAsync(MenuItemKeysDto model);


         #endregion

        #endregion

    }
}
