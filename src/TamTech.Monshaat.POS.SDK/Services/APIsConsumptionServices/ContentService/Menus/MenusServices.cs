using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Menus.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Menus.Settings;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Menus
{
    public class MenusServices : IMenusServices
    {

        #region Props 
        private readonly IRequestProvider _requestProvider;
        private readonly IMenuApiSettings _backendSettings;
        #endregion


        #region Ctors
        public MenusServices(IRequestProvider requestProvider,
                               IMenuApiSettings backendSettings
                               )
        {
            _requestProvider = requestProvider;
            _backendSettings = backendSettings;
        }


        #endregion


         

        #region Services


        #region {Public Menus}  
                                   
        public async Task<IRequestProviderResult<MenuDto>> GetPublicDynamicByKeyAsync(string key)
        {
            return await _requestProvider.GetAsync<MenuDto, List<string>>(_backendSettings.GetPublicDynamicByKeyAsyncEndpoint, new List<string> { key }, PassParamsBy.Route);
        }


        public async Task<IRequestProviderResult<MenuDto>> GetPublicByKeyAndLangAsync(string key, string lang)
        {
            throw new NotImplementedException();
        }

            #endregion




            #region {Menus Manager}  

            #region {Get} 

            public async Task<IRequestProviderResult<List<MenuLiteDto>>> GetAllAsync(string lang)
        {
            return await _requestProvider.GetAsync<List<MenuLiteDto>>(_backendSettings.GetAllAsyncEndpoint);
        }

        public async Task<IRequestProviderResult<MenuDto>> GetByIdAsync(Guid id ,string lang)
        {

           /* return new RequestProviderResult<MenuDto>
            {
                Success = true,
                Data = new MenuDto
                {
                    Id = new Guid("66d4dd29-9d2e-4328-b0b4-63e201733926"),
                    Position = "header",
                    Title = "main menu",
                    Key = "main_menu",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    MenuItems = new List<MenuItemDto>{

                      new MenuItemDto
                      {
                        Title ="home",
                        Url ="Url Url",
                        ItemType="page",
                        Published =true,
                        MenuItems = new  List<MenuItemDto>(),
                      },
                      new MenuItemDto
                      {
                        Title ="aboutus",
                        ItemType="dropdown",
                        Url ="Url",
                        Published =false,
                        MenuItems = new  List<MenuItemDto>(){
                            new MenuItemDto
                                      {
                                        Title ="aboutus-1-1",
                                        Url ="Url",
                                        ItemType= "page",
                                        Published =true,
                                        MenuItems = new  List<MenuItemDto>(),
                                      },
                            new MenuItemDto
                                      {
                                        Title ="aboutus-1-2",
                                        Url ="Url",
                                        ItemType= "page",
                                        Published =true,
                                        MenuItems = new  List<MenuItemDto>(),
                                      },
                        },
                      },
                      new MenuItemDto
                      {
                        Title ="services",
                        Url ="Url link",
                        Published =true,
                        ItemType="dropdown",
                        MenuItems = new  List<MenuItemDto>(){
                            new MenuItemDto
                              {
                                Title ="service-1",
                                Url ="Url",
                                ItemType= "dropdown",
                                Published =true,
                                MenuItems = new  List<MenuItemDto>(){

                                    new MenuItemDto
                                      {
                                        Title ="service-1-1",
                                        Url ="Url",
                                        ItemType= "page",
                                        Published =true,
                                        MenuItems = new  List<MenuItemDto>(),
                                      },
                                    new MenuItemDto
                                      {
                                        Title ="service-1-2",
                                        Url ="Url",
                                        ItemType= "page",
                                        Published =true,
                                        MenuItems = new  List<MenuItemDto>(),
                                      },
                                    new MenuItemDto
                                      {
                                        Title ="service-1-3",
                                        Url ="Url",
                                        ItemType= "dropdown",
                                        Published =true,
                                        MenuItems = new  List<MenuItemDto>(){
                                             new MenuItemDto
                                              {
                                                Title ="service-1-3-1",
                                                Url ="Url",
                                                ItemType= "page",
                                                Published =true,
                                                MenuItems = new  List<MenuItemDto>(),
                                              },
                                              new MenuItemDto
                                              {
                                                Title ="service-1-3-2",
                                                Url ="Url",
                                                ItemType= "page",
                                                Published =true,
                                                MenuItems = new  List<MenuItemDto>(),
                                              },
                                               new MenuItemDto
                                              {
                                                Title ="service-1-3-3",
                                                Url ="Url",
                                                ItemType= "dropdown",
                                                Published =true,
                                                MenuItems = new  List<MenuItemDto>(){
                                                       new MenuItemDto
                                              {
                                                Title ="service-1-3-3-1",
                                                Url ="",
                                                Published =true,
                                                MenuItems = new  List<MenuItemDto>(),
                                              },
                                                },
                                              },
                                        },
                                      },

                                },
                              },
                            new MenuItemDto
                              {
                                Title ="service-2",
                                Url ="",
                                Published =true,
                                MenuItems = new  List<MenuItemDto>(),
                              },
                            new MenuItemDto
                              {
                                Title ="service-3",
                                Url ="",
                                Published =true,
                                MenuItems = new  List<MenuItemDto>(),
                              }
                        },
                      }
                  }
                }
            }; */


             return await _requestProvider.GetAsync<MenuDto, List<Guid>>(_backendSettings.GetByIdAsyncEndpoint, new List<Guid> { id }, PassParamsBy.Route);
        }

        #endregion


        #region  {Menu}  Create / Edit / Delete / Publish 

        public async Task<IRequestProviderResult<Guid>> CreateAsync(CreateMenuDto menu)
        {
            var result = await _requestProvider.PostAsync<Guid, CreateMenuDto>(_backendSettings.CreateAsyncEndpoint, menu);

            return result;
        }


        public async Task<IRequestProviderResult<bool>> EditAsync(UpdateMenuDto menu)
        {
            var result = await _requestProvider.PostAsync<bool, UpdateMenuDto>(_backendSettings.EditAsyncEndpoint, menu);

            return result;
        }

        public async Task<IRequestProviderResult<bool>> DeleteByIdAsync(Guid id)
        {
            var result = await _requestProvider.PostAsync<bool, Guid>(_backendSettings.SoftDeleteAsyncEndpoint, id);
            return result;
        }

        #endregion


        #region {Menu Items}  Create / Edit / Delete / Publish 

        public async Task<IRequestProviderResult<string>> CreateMenuItemAsync(CreateMenuItemDto model)
        {
            return await _requestProvider.PostAsync<string, CreateMenuItemDto>(_backendSettings.CreateMenuItemAsyncEndpoint, model);
        }

        public async Task<IRequestProviderResult<bool>> EditMenuItemAsync(UpdateMenuItemDto model)
        {
            return await _requestProvider.PostAsync<bool, UpdateMenuItemDto>(_backendSettings.EditMenuItemAsyncEndpoint, model);
        }


        public async Task<IRequestProviderResult<bool>> PublishMenuItemAsync(MenuItemKeysDto model)
        {
            return await _requestProvider.PostAsync<bool, MenuItemKeysDto>(_backendSettings.PublishMenuItemAsyncEndpoint, model);
        }

        public async Task<IRequestProviderResult<bool>> DeleteMenuItemAsync(MenuItemKeysDto model)
        {
            return await _requestProvider.PostAsync<bool, MenuItemKeysDto>(_backendSettings.DeleteMenuItemAsyncEndpoint, model);
        }


        public async Task<IRequestProviderResult<Dictionary<string, dynamic>>> GetPublicDynamicMenuItemsTypesListsByTypesAsync(List<string> model, string lang)
        {
            // TODO: language parameter not called
            return await _requestProvider.PostAsync<Dictionary<string, dynamic>, List<string>>(_backendSettings.GetPublicDynamicMenuItemsTypesListsByTypesAsyncEndpoint, model);
        }

        public Task<IRequestProviderResult<Dictionary<string, Dictionary<string, string>>>> GetListsModulesForMenuItemsTypesAsync(List<string> model, string lang)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<MenuDto>> GetPublicByKeyAsync(string lang)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<MenuDto>> GetPublicBySettingIdAsync(int settingId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion

        #endregion
    }
}
