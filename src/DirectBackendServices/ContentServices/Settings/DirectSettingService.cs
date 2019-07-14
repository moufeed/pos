using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Settings.Mapper;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Biographies.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Settings;
using TamTech.Monshaat.POS.Web.Services.ContentService.Settings.Models;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Settings
{
    public class DirectSettingService : BaseDirectService, ISettingService
    {
        TamTech.ContentService.Services.Settings.ISettingService _service;


        public DirectSettingService(TamTech.ContentService.Services.Settings.ISettingService BiographyService)
        {
            _service = BiographyService;
        }
        public async Task<IRequestProviderResult<List<SettingDto>>> GetListByKeysAsync(List<string> keys)
        {
            var result = await _service.GetListByKeysAsync(keys, null);
            return ReturnRequestProviderResult (result?.Select(m => m.MapToFrontDto()).ToList());
        }
        public async Task<IRequestProviderResult<List<SettingDto>>> GetByGroupIdsAsync(List<int> groupIds)
        {
            var result = await _service.GetByGroupIdsAsync(groupIds, null);
            return ReturnRequestProviderResult(result?.Select(m => m.MapToFrontDto()).ToList());
        }
        public async Task<IRequestProviderResult<List<SettingDto>>> GetListByIdsAsync(List<int> ids)
        {
            var result = await _service.GetListByIdsAsync(ids, null);
            return ReturnRequestProviderResult(result?.Select(m => m.MapToFrontDto()).ToList());
        }


        public async Task<IRequestProviderResult<List<SettingDto>>> GetListBySharedKeyAsync(string sharedkey)
        {
            var result = await _service.GetListBySharedKeyAsync(sharedkey, null);
            return ReturnRequestProviderResult(result?.Select(m => m.MapToFrontDto()).ToList());
        }
        public async Task<IRequestProviderResult<List<SettingDto>>> GetListBySharedKeysAsync(List<string> sharedkeys)
        {
            var result = await _service.GetListBySharedKeysAsync(sharedkeys, null);
            return ReturnRequestProviderResult(result?.Select(m => m.MapToFrontDto()).ToList());
        }
        public async Task<IRequestProviderResult<List<SettingDto>>> GetByGroupIdAsync(int groupId)
        {
            var result = await _service.GetByGroupIdAsync(groupId, null);
            return ReturnRequestProviderResult(result?.Select(m => m.MapToFrontDto()).ToList());
        }
        public async Task<IRequestProviderResult<SettingDto>> GetByIdAsync(int id)
        {
            var result = await _service.GetByIdAsync(id, null);
            return ReturnRequestProviderResult(result?.MapToFrontDto());
        }







        public async Task<IRequestProviderResult<List<SettingDto>>> GetEnabledListByKeysAsync(List<string> keys)
        {
            var result = await _service.GetListByKeysAsync(keys, true);
            return ReturnRequestProviderResult(result?.Select(m => m.MapToFrontDto()).ToList());
        }
        public async Task<IRequestProviderResult<List<SettingDto>>> GetEnabledByGroupIdsAsync(List<int> groupIds)
        {
            var result = await _service.GetByGroupIdsAsync(groupIds, true);
            return ReturnRequestProviderResult(result?.Select(m => m.MapToFrontDto()).ToList());
        }
        public async Task<IRequestProviderResult<List<SettingDto>>> GetEnabledListByIdsAsync(List<int> ids)
        {
            var result = await _service.GetListByIdsAsync(ids, true);
            return ReturnRequestProviderResult(result?.Select(m => m.MapToFrontDto()).ToList());
        }

        public async Task<IRequestProviderResult<List<SettingDto>>> GetEnabledListBySharedKeyAsync(string sharedkey)
        {
            var result = await _service.GetListBySharedKeyAsync(sharedkey, true);
            return ReturnRequestProviderResult(result?.Select(m => m.MapToFrontDto()).ToList());
        }

        public async Task<IRequestProviderResult<List<SettingDto>>> GetEnabledListBySharedKeysAsync(List<string> sharedkeys)
        {
            var result = await _service.GetListBySharedKeysAsync(sharedkeys, true);
            return ReturnRequestProviderResult(result?.Select(m => m.MapToFrontDto()).ToList());
        }
        public async Task<IRequestProviderResult<List<SettingDto>>> GetEnabledByGroupIdAsync(int groupId)
        {
            var result = await _service.GetByGroupIdAsync(groupId, true);
            return ReturnRequestProviderResult(result?.Select(m => m.MapToFrontDto()).ToList());
        }
        public async Task<IRequestProviderResult<SettingDto>> GetEnabledByIdAsync(int id)
        {
            var result = await _service.GetByIdAsync(id, true);
            return ReturnRequestProviderResult( result?.MapToFrontDto());
        }






        public async Task<IRequestProviderResult<List<SettingDto>>> GetAllAsync()
        {
            var result = await _service.GetAllAsync();
            return ReturnRequestProviderResult( result?.Select(m => m.MapToFrontDto()).ToList());
        }






    }
}
