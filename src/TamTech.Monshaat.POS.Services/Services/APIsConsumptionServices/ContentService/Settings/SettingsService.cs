using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Settings.Settings;
using TamTech.Monshaat.POS.Web.Services.ContentService.Settings;
using TamTech.Monshaat.POS.Web.Services.ContentService.Settings.Models;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Settings
{
    public class SettingsService : BaseAPIService ,ISettingService
    {
        #region Props                       
        private readonly ISettingsApiSettings _apiSettings;
        #endregion


        #region Ctors
        public SettingsService(IRequestProvider requestProvider, ISettingsApiSettings apiSettings)
            : base(requestProvider)
        {         
            _apiSettings = apiSettings;
        }
        #endregion


        public async Task<IRequestProviderResult<List<SettingDto>>> GetByGroupIdAsync(int groupId)
        {
            return await ReqProvider.GetAsync<List<SettingDto>, List<object>>(_apiSettings.GetByGroupIdEndpoint, new List<object> { groupId }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<List<SettingDto>>> GetByGroupIdsAsync(List<int> groupIds)
        {
            ApiRequestModel<List<int>> Data = new ApiRequestModel<List<int>>()
            {
                 Data = groupIds, 
            };
            return await ReqProvider.GetAsync<List<SettingDto>, ApiRequestModel<List<int>>>(_apiSettings.GetByGroupIdsEndpoint, Data, PassParamsBy.Body);
              
        }

        public async Task<IRequestProviderResult<SettingDto>> GetByIdAsync(int id)
        {
            return await ReqProvider.GetAsync<SettingDto, List<object>>(_apiSettings.GetByIdEndpoint, new List<object> { id }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<List<SettingDto>>> GetEnabledByGroupIdAsync(int groupId)
        {
            return await ReqProvider.GetAsync<List<SettingDto>, List<object>>(_apiSettings.GetByGroupIdEndpoint, new List<object> { groupId  }, PassParamsBy.Route);
            
        }

        public async Task<IRequestProviderResult<List<SettingDto>>> GetEnabledByGroupIdsAsync(List<int> groupIds)
        {
            ApiRequestModel<List<int>> Data = new ApiRequestModel<List<int>>()
            {
                Data = groupIds 
            };
            return await ReqProvider.GetAsync<List<SettingDto>, ApiRequestModel<List<int>>>(_apiSettings.GetByGroupIdsEndpoint, Data, PassParamsBy.Body);
        }

        public async Task<IRequestProviderResult<SettingDto>> GetEnabledByIdAsync(int id)
        {
            return await ReqProvider.GetAsync<SettingDto, List<object>>(_apiSettings.GetByIdEndpoint, new List<object> { id}, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<List<SettingDto>>> GetEnabledListByIdsAsync(List<int> ids)
        {
            
                 ApiRequestModel<List<int>> Data = new ApiRequestModel<List<int>>()
                 {
                     Data = ids, 
                 };
            return await ReqProvider.GetAsync<List<SettingDto>, ApiRequestModel<List<int>>>(_apiSettings.GetListByIdsEndpoint, Data, PassParamsBy.Body);
        }

        public async Task<IRequestProviderResult<List<SettingDto>>> GetEnabledListByKeysAsync(List<string> keys)
        {
            
                 ApiRequestModel<List<string>> Data = new ApiRequestModel<List<string>>()
                 {
                     Data = keys, 
                 };
            return await ReqProvider.GetAsync<List<SettingDto>, ApiRequestModel<List<string>>>(_apiSettings.GetListByKeysEndpoint, Data, PassParamsBy.Body);
        }

        public async Task<IRequestProviderResult<List<SettingDto>>> GetEnabledListBySharedKeyAsync(string sharedkey)
        {
             return await ReqProvider.GetAsync<List<SettingDto>, List<object>>(_apiSettings.GetListBySharedKeyEndpoint, new List<object> { sharedkey }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<List<SettingDto>>> GetEnabledListBySharedKeysAsync(List<string> sharedkeys)
        {
            
             ApiRequestModel<List<string>> Data = new ApiRequestModel<List<string>>()
             {
                  Data = sharedkeys, 
             };
            return await ReqProvider.GetAsync<List<SettingDto>, ApiRequestModel<List<string>>>(_apiSettings.GetListBySharedKeysEndpoint, Data, PassParamsBy.Body);
        }

        public async Task<IRequestProviderResult<List<SettingDto>>> GetListByIdsAsync(List<int> ids)
        {
            

              ApiRequestModel<List<int>> Data = new ApiRequestModel<List<int>>()
              {
                  Data = ids, 
              };
            return await ReqProvider.GetAsync<List<SettingDto>, ApiRequestModel<List<int>>>(_apiSettings.GetListByIdsEndpoint, Data, PassParamsBy.Body);
        }

        public async Task<IRequestProviderResult<List<SettingDto>>> GetListByKeysAsync(List<string> keys)
        {
            ApiRequestModel<List<string>> Data = new ApiRequestModel<List<string>>()
            {
                Data = keys, 
            };
            return await ReqProvider.GetAsync<List<SettingDto>, ApiRequestModel<List<string>>>(_apiSettings.GetListByKeysEndpoint, Data, PassParamsBy.Body);
        }

        public async Task<IRequestProviderResult<List<SettingDto>>> GetListBySharedKeyAsync(string sharedkey)
        {
            return await ReqProvider.GetAsync<List<SettingDto>, List<object>>(_apiSettings.GetListBySharedKeyEndpoint, new List<object> { sharedkey }, PassParamsBy.Route);
        }
    }
}
