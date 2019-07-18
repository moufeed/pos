using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Enums;
using TamTech.Monshaat.POS.Web.Services.ContentService.Settings;    
using TamTech.Monshaat.POS.Web.Models.VMs.Admin.Menus;

namespace TamTech.Monshaat.POS.Web.Core.Settings.Utilities
{
    public class SettingsHelpers
    {


        #region Props  
        private readonly ISettingService _settingService;

        public static string AppVersion;
         public static string VendorRoleName;
        // public static string app_Url; 
        #endregion


        #region Ctors
        public SettingsHelpers(ISettingService settingService)
        {
            _settingService = settingService;

        }
        #endregion




        #region Utilities
        public async Task PrepareCashedSettingsAsync()
        {
            if (string.IsNullOrWhiteSpace(AppVersion) || string.IsNullOrWhiteSpace(VendorRoleName))
            {
                var settings = await _settingService.GetEnabledListByIdsAsync(
                    new List<int> { (int)SettingKeysEnum.AppVersion, (int)SettingKeysEnum.VendorRoleName });
                if (settings.Success == true)
                {
                    AppVersion = settings.Data?.SingleOrDefault(s => s.Id == (int)SettingKeysEnum.AppVersion)?.Value;
                    VendorRoleName = settings.Data?.SingleOrDefault(s => s.Id == (int)SettingKeysEnum.VendorRoleName)?.Value;
                }
            }
        }



        public async Task<string> GetVersionAsync()
        {
            if (!string.IsNullOrWhiteSpace(AppVersion)) return AppVersion;
            var settings = await _settingService.GetByIdAsync((int)SettingKeysEnum.AppVersion);
            AppVersion = settings?.Data?.Value;
            return AppVersion;
        }

        public async Task<string> GetVendorRoleNameAsync()
        {
            if (!string.IsNullOrWhiteSpace(VendorRoleName)) return VendorRoleName;
            var settings = await _settingService.GetByIdAsync((int)SettingKeysEnum.VendorRoleName);
            VendorRoleName = settings?.Data?.Value;
            return VendorRoleName;
        }


        public async Task<string> GetURlAsync()
        {

            var settings = await _settingService.GetByIdAsync((int)SettingKeysEnum.AppUrl);
            return settings?.Data?.Value;
        }


        public async Task<bool> DisplayTokenInWebViewAsync()
        {
            var settings = await _settingService.GetByIdAsync((int)SettingKeysEnum.DisplayTokenInWebView);
            return settings?.Data?.Value == "1";
        }

        public async Task<bool> CheckCachedNavbarAsync()
        {
            var settings = await _settingService.GetByIdAsync((int)SettingKeysEnum.CachedNavbar);
            return settings?.Data?.Value == "1";
        }

        //public async Task<EmailFromInfo> GetEmailSettingsAsync()
        //{

        //    var settings = await _settingService.GetEnabledListBySharedKeysAsync(
        //        new List<string> { SettingSharedKeysEnum.Email.ToString(), SettingSharedKeysEnum.Email_CC.ToString() });
        //    if (settings.Data == null || !settings.Success) return null;
        //    EmailFromInfo model = new EmailFromInfo
        //    {
        //        From = settings.Data.FirstOrDefault(e => e.Key == SettingKeysEnum.Email_From.ToString())?.Value,
        //        FromName = settings.Data.FirstOrDefault(e => e.Key == SettingKeysEnum.Email_FromName.ToString())?.Value,
        //        CC = settings.Data.Where(e => e.SharedKey == SettingSharedKeysEnum.Email_CC.ToString())?.Select(c => c.Value)?.ToList(),
        //    };
        //    return model;
        //}

        public async Task<List<string>> GetMenuItemsTypesAsync()
        {
            var settings = await _settingService.GetEnabledListBySharedKeyAsync(SettingSharedKeysEnum.ModulesOfMenuItemsTypes.ToString());
            return settings.Data?.Select(s => s.Value)?.ToList();
        }
        public async Task<List<string>> GetNumericalStatisticsNamesAsync()
        {
            var settings = await _settingService.GetEnabledListBySharedKeyAsync(SettingSharedKeysEnum.NumericalStatisticsModulesNames.ToString());
            return settings.Data?.Select(s => s.Value)?.ToList();
        }
        public async Task<List<StaticMenuItem>> GetStaticPagesAsync()
        {
            var settings = await _settingService.GetByIdAsync((int)SettingKeysEnum.StaticPages);
            return Helpers.Helpers.Deserialize<List<StaticMenuItem>>(settings.Data?.Value);
        }

        #endregion
    }
}
