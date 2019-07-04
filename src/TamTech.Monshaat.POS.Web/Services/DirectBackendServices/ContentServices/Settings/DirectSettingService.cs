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
        public async Task<List<SettingDto>> GetListByKeysAsync(List<string> keys)
        {
            var result = await _service.GetListByKeysAsync(keys, null);
            return result?.Select(m => m.MapToFrontDto()).ToList();
        }
        public async Task<List<SettingDto>> GetByGroupIdsAsync(List<int> groupIds)
        {
            var result = await _service.GetByGroupIdsAsync(groupIds, null);
            return result?.Select(m => m.MapToFrontDto()).ToList();
        }
        public async Task<List<SettingDto>> GetListByIdsAsync(List<int> ids)
        {
            var result = await _service.GetListByIdsAsync(ids, null);
            return result?.Select(m => m.MapToFrontDto()).ToList();
        }


        public async Task<List<SettingDto>> GetListBySharedKeyAsync(string sharedkey)
        {
            var result = await _service.GetListBySharedKeyAsync(sharedkey, null);
            return result?.Select(m => m.MapToFrontDto()).ToList();
        }
        public async Task<List<SettingDto>> GetListBySharedKeysAsync(List<string> sharedkeys)
        {
            var result = await _service.GetListBySharedKeysAsync(sharedkeys, null);
            return result?.Select(m => m.MapToFrontDto()).ToList();
        }
        public async Task<List<SettingDto>> GetByGroupIdAsync(int groupId)
        {
            var result = await _service.GetByGroupIdAsync(groupId, null);
            return result?.Select(m => m.MapToFrontDto()).ToList();
        }
        public async Task<SettingDto> GetByIdAsync(int id)
        {
            var result = await _service.GetByIdAsync(id, null);
            return result?.MapToFrontDto();
        }







        public async Task<List<SettingDto>> GetEnabledListByKeysAsync(List<string> keys)
        {
            var result = await _service.GetListByKeysAsync(keys, true);
            return result?.Select(m => m.MapToFrontDto()).ToList();
        }
        public async Task<List<SettingDto>> GetEnabledByGroupIdsAsync(List<int> groupIds)
        {
            var result = await _service.GetByGroupIdsAsync(groupIds, true);
            return result?.Select(m => m.MapToFrontDto()).ToList();
        }
        public async Task<List<SettingDto>> GetEnabledListByIdsAsync(List<int> ids)
        {
            var result = await _service.GetListByIdsAsync(ids, true);
            return result?.Select(m => m.MapToFrontDto()).ToList();
        }

        public async Task<List<SettingDto>> GetEnabledListBySharedKeyAsync(string sharedkey)
        {
            var result = await _service.GetListBySharedKeyAsync(sharedkey, true);
            return result?.Select(m => m.MapToFrontDto()).ToList();
        }

        public async Task<List<SettingDto>> GetEnabledListBySharedKeysAsync(List<string> sharedkeys)
        {
            var result = await _service.GetListBySharedKeysAsync(sharedkeys, true);
            return result?.Select(m => m.MapToFrontDto()).ToList();
        }
        public async Task<List<SettingDto>> GetEnabledByGroupIdAsync(int groupId)
        {
            var result = await _service.GetByGroupIdAsync(groupId, true);
            return result?.Select(m => m.MapToFrontDto()).ToList();
        }
        public async Task<SettingDto> GetEnabledByIdAsync(int id)
        {
            var result = await _service.GetByIdAsync(id, true);
            return result?.MapToFrontDto();
        }






        public async Task<List<SettingDto>> GetAllAsync()
        {
            var result = await _service.GetAllAsync();
            return result?.Select(m => m.MapToFrontDto()).ToList();
        }






    }
}
