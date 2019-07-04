using System.Collections.Generic;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Services.ContentService.Settings.Models;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Settings
{
    public interface ISettingService
    {

        Task<List<SettingDto>> GetByGroupIdsAsync(List<int> groupIds);

        Task<List<SettingDto>> GetListByKeysAsync(List<string> keys);

        Task<List<SettingDto>> GetListByIdsAsync(List<int> ids);

        Task<List<SettingDto>> GetListBySharedKeyAsync(string sharedkey);

        Task<List<SettingDto>> GetByGroupIdAsync(int groupId);

        Task<SettingDto> GetByIdAsync(int id);

        Task<List<SettingDto>> GetEnabledByGroupIdsAsync(List<int> groupIds);

        Task<List<SettingDto>> GetEnabledListByKeysAsync(List<string> keys);

        Task<List<SettingDto>> GetEnabledListByIdsAsync(List<int> ids);

        Task<List<SettingDto>> GetEnabledListBySharedKeyAsync(string sharedkey);

        Task<List<SettingDto>> GetEnabledListBySharedKeysAsync(List<string> sharedkeys);

        Task<List<SettingDto>> GetEnabledByGroupIdAsync(int groupId);

        Task<SettingDto> GetEnabledByIdAsync(int id);

    }
}
