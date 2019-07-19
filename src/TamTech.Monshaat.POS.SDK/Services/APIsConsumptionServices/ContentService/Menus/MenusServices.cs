using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Menus.Settings;
using TamTech.Monshaat.POS.Web.Services.ContentService.Menus;
using TamTech.Monshaat.POS.Web.Services.ContentService.Menus.Models;    

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Menus
{
    public class MenusServices : BaseAPIService ,IMenusServices
    {

        #region Props              
        private readonly IMenuApiSettings _menuApiSettings;
        private readonly IMenuItemApiSettings _menuItemApiSettings;
        #endregion


        #region Ctors
        public MenusServices(IRequestProvider requestProvider,
                               IMenuApiSettings menuApiSettings,
                               IMenuItemApiSettings MenuItemApiSettings
                               )   : base(requestProvider)
        {     
            _menuApiSettings = menuApiSettings;
            _menuItemApiSettings = MenuItemApiSettings;
        }


        #endregion




        #region {Menu}       
        #region {Public}    

        public async Task<IRequestProviderResult<MenuDto>> GetPublicByKeyAsync(string key)
        {
            return await ReqProvider.GetAsync<MenuDto, List<object>>(_menuApiSettings.GetPublicByKeyAsyncEndpoint, new List<object> { key }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<MenuDto>> GetPublicBySettingIdAsync(int settingId)
        {
            return await ReqProvider.GetAsync<MenuDto, List<object>>(_menuApiSettings.GetPublicBySettingIdEndpoint, new List<object> { settingId }, PassParamsBy.Route);
        }

        #endregion


        #region {Menus Manager}  
        #region {Get}      

        public async Task<IRequestProviderResult<List<MenuLiteDto>>> GetAllAsync(string lang)
        {
            return await ReqProvider.GetAsync<List<MenuLiteDto> ,List<object>>(_menuApiSettings.GetAllAsyncEndpoint, new List<object> { lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<MenuDto>> GetByIdAsync(Guid id, string lang)
        {
            return await ReqProvider.GetAsync<MenuDto, List<object>>(_menuApiSettings.GetByIdAsyncEndpoint, new List<object> { id , lang }, PassParamsBy.Route);
        }

        #endregion

        #region  {Menu}  Create / Edit / Delete / Publish 

        public async Task<IRequestProviderResult<Guid>> CreateAsync(CreateMenuDto menu)
        {
            var result = await ReqProvider.PostAsync<Guid, CreateMenuDto>(_menuApiSettings.CreateAsyncEndpoint, menu);

            return result;
        }


        public async Task<IRequestProviderResult<bool>> EditAsync(UpdateMenuDto menu)
        {
            var result = await ReqProvider.PostAsync<bool, UpdateMenuDto>(_menuApiSettings.EditAsyncEndpoint, menu);

            return result;
        }

        public async Task<IRequestProviderResult<bool>> DeleteByIdAsync(Guid id)
        {
            var result = await ReqProvider.PostAsync<bool, Guid>(_menuApiSettings.SoftDeleteAsyncEndpoint, id);
            return result;
        }

        #endregion
        #endregion
        #endregion

        #region {Menu Items}  

        #region {Menu Items}  Create / Edit / Delete / Publish 

        public async Task<IRequestProviderResult<string>> CreateMenuItemAsync(CreateMenuItemDto model)
        {
            return await ReqProvider.PostAsync<string, CreateMenuItemDto>(_menuItemApiSettings.CreateMenuItemAsyncEndpoint, model);
        }

        public async Task<IRequestProviderResult<bool>> EditMenuItemAsync(UpdateMenuItemDto model)
        {
            return await ReqProvider.PostAsync<bool, UpdateMenuItemDto>(_menuItemApiSettings.EditMenuItemAsyncEndpoint, model);
        }


        public async Task<IRequestProviderResult<bool>> PublishMenuItemAsync(MenuItemKeysDto model)
        {
            return await ReqProvider.PostAsync<bool, MenuItemKeysDto>(_menuItemApiSettings.PublishMenuItemAsyncEndpoint, model);
        }

        public async Task<IRequestProviderResult<bool>> DeleteMenuItemAsync(MenuItemKeysDto model)
        {
            return await ReqProvider.PostAsync<bool, MenuItemKeysDto>(_menuItemApiSettings.DeleteMenuItemAsyncEndpoint, model);
        }

        #endregion
        #endregion


    }
}
