using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.ContentService.Core.Domain.Models.Results;
using TamTech.Monshaat.POS.Web.Core.Enums;
using TamTech.Monshaat.POS.Web.Core.Settings.Utilities;
using TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Menus.Mapper;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Menus.Models;
using TamTechSDK.Web.Services.ContentService.Menus.PublicService;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Menus
{
    public class DirectMenusServices : BaseDirectService, TamTech.Monshaat.POS.Web.Services.ContentService.Menus.IMenusServices
    {


        #region Props  
        private readonly SettingsHelpers _settingsHelpers;
        private readonly TamTech.ContentService.Services.Menus.IMenuService _menuService;
        private readonly TamTech.ContentService.Services.Utilities.Content.ICCUService _contentUtilities;
        #endregion


        #region Ctors
        public DirectMenusServices(TamTech.ContentService.Services.Menus.IMenuService menuService,
            TamTech.ContentService.Services.Utilities.Content.ICCUService contentUtilities,
            SettingsHelpers settingsHelpers
            )
        {
            _menuService = menuService;
            _contentUtilities = contentUtilities;
            _settingsHelpers = settingsHelpers;
        }
        #endregion

        #region Utilities

        private IRequestProviderResult<TResult> MapRequestProviderResult<TResult>(
           IReturnResultModel<TResult> inputResult)
        {
            IRequestProviderResult<TResult> _resultModel = new RequestProviderResult<TResult>();
            _resultModel.Success = inputResult.Success;
            _resultModel.StatusCode = (System.Net.HttpStatusCode)((int)inputResult.StatusCode);
            _resultModel.Data = inputResult.Data;
            _resultModel.Messages = _resultModel.Success ? null : _resultModel.Messages = new Dictionary<string, List<string>>();
            foreach (var error in inputResult.ModelState)
            {
                var errorMessages = new List<string>();
                if (error.Value.Errors.Count > 0)
                {
                    foreach (var value in error.Value.Errors)
                    {
                        errorMessages.Add(value.ErrorMessage);
                    }

                    _resultModel.Messages.Add(error.Key, errorMessages);
                }
            }
            return _resultModel;
        }

        private IRequestProviderResult<TResult> GetRequestProviderResult<TResult>(TResult data)
        {
            IRequestProviderResult<TResult> _resultModel = new RequestProviderResult<TResult>();
            _resultModel.Success = true;
            _resultModel.StatusCode = System.Net.HttpStatusCode.OK;
            _resultModel.Data = data;
            return _resultModel;
        }


        public async Task RefreshCachedMenusAsync()
        {
            if (await _settingsHelpers.CheckCachedNavbarAsync())
            {
                CashedMenusService._navbar = (await GetPublicBySettingIdAsync((int)SettingKeysEnum.Navbar)).Data;
            }
        }

        #region Deserialize
        public TResult DeserializeFromObject<TResult>(dynamic inputObject)
        {
            string serialized = JsonConvert.SerializeObject(inputObject);
            TResult handledResult = JsonConvert.DeserializeObject<TResult>(serialized);
            return handledResult;
        }
        #endregion

        #endregion

        #region Service

        public async Task<IRequestProviderResult<Dictionary<string, Dictionary<string, string>>>> GetListsModulesForMenuItemsTypesAsync(List<string> model, string lang)
        {
            var results = await _contentUtilities.GetListsModulesForMenuItemsTypesAsync(model, lang);
            return ReturnRequestProviderResult(results);
        }



        #region {Public Menus}  


        //public async Task<IRequestProviderResult<MenuDto>> GetPublicDynamicBySlugAsync(string slug)
        //{
        //    var menus = await _menuService.GetPublicDynamicBySlugAsync(slug);
        //    return GetRequestProviderResult(menus.MapToFrontendDto());
        //}


        public async Task<IRequestProviderResult<MenuDto>> GetPublicByKeyAsync(string key)
        {
            var result = await _menuService.GetPublicByKeyAsync(key);
            return ReturnRequestProviderResult (result?.MapToFrontendDto());
        }


        public async Task<IRequestProviderResult<MenuDto>> GetPublicBySettingIdAsync(int settingId)
        {
            var result = await _menuService.GetPublicBySettingIdAsync(settingId);
            return ReturnRequestProviderResult(result?.MapToFrontendDto());
        }





        public async Task<IRequestProviderResult<Dictionary<string, dynamic>>> GetPublicDynamicMenuItemsTypesListsByTypesAsync(List<string> model, string lang)
        {
            // TODO: language parameter not called
            //var results = await _menuService.GetPublicDynamicMenuItemsTypesListsByTypesAsync(model);
            //return GetRequestProviderResult(results);

            throw new NotImplementedException("the method not implemented in DirectMenusServices");
        }

        #endregion 

        #region {Menus Manager}  

        #region {Get} 

        public async Task<IRequestProviderResult<List<MenuLiteDto>>> GetAllAsync(string lang)
        {
            var menus = await _menuService.GetAllExceptSoftDeletedAsync(lang);
            var menusLite = menus != null ? menus.Select(m => m.MapToFrontendLiteDto()).ToList() : new List<MenuLiteDto>();
            return GetRequestProviderResult(menusLite);
        }

        public async Task<IRequestProviderResult<MenuDto>> GetByIdAsync(Guid id, string lang)
        {
            var menus = await _menuService.GetByIdExceptSoftDeletedAsync(id, lang);
            //return GetRequestProviderResult();

            return ReturnResult(menus?.MapToFrontendDto(), menus != null);
        }


        #endregion


        #region  {Menu}  Create / Edit / Delete  

        public async Task<IRequestProviderResult<Guid>> CreateAsync(CreateMenuDto model)
        {
            var result = await _menuService.CreateAsync(model?.MapToBackendDto());
            return MapRequestProviderResult(result);
        }
        public async Task<IRequestProviderResult<bool>> EditAsync(UpdateMenuDto model)
        {
            var result = await _menuService.EditAsync(model?.MapToBackendDto());
            return MapRequestProviderResult(result);
        }
        public async Task<IRequestProviderResult<bool>> DeleteByIdAsync(Guid id)
        {
            var result = await _menuService.SoftDeleteAsync(id);
            return MapRequestProviderResult(result);
        }


        #endregion


        #region {Menu Items}  Create / Edit / Delete / Publish 

        public async Task<IRequestProviderResult<string>> CreateMenuItemAsync(CreateMenuItemDto model)
        {
            var result = await _menuService.CreateMenuItemAsync(model?.MapToBackendDto());
            if (result.Success)
            {
                await RefreshCachedMenusAsync();
            }
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> EditMenuItemAsync(UpdateMenuItemDto model)
        {
            var result = await _menuService.EditMenuItemAsync(model?.MapToBackendDto());
            if (result.Success)
            {
                await RefreshCachedMenusAsync();
            }
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> PublishMenuItemAsync(MenuItemKeysDto model)
        {
            var result = await _menuService.PublishMenuItemAsync(model?.MapToBackendPublishDto());
            if (result.Success)
            {
                await RefreshCachedMenusAsync();
            }
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> DeleteMenuItemAsync(MenuItemKeysDto model)
        {
            var result = await _menuService.HardDeleteMenuItemAsync(model?.MapToBackendDto());
            if (result.Success)
            {
                await RefreshCachedMenusAsync();
            }
            return MapRequestProviderResult(result);
        }

        #endregion

        #endregion

        #endregion

    }
}
