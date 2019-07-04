using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Enums;
using TamTech.Monshaat.POS.Web.Services.ContentService.Settings;
using TamTech.Monshaat.POS.Web.Services.Email.Settings;
using TamTech.Monshaat.POS.Web.Models.VMs.Admin.Menus;

namespace TamTech.Monshaat.POS.Web.Core.Settings.Utilities
{
    public class SettingsHelpers
    {


        #region Props  
        private readonly ISettingService _settingService;
        public static string app_version;
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
            if (string.IsNullOrWhiteSpace(app_version))
            {
                var settings = await _settingService.GetByIdAsync((int)SettingKeysEnum.AppVersion);
                app_version = settings?.Value;
            }

        }



        public async Task<string> GetVersionAsync()
        {
            if (!string.IsNullOrWhiteSpace(app_version)) return app_version;
            var settings = await _settingService.GetByIdAsync((int)SettingKeysEnum.AppVersion);
            app_version = settings?.Value;
            return app_version;
        }

        public async Task<string> GetVendorRoleNameAsync()
        {

            var settings = await _settingService.GetByIdAsync((int)SettingKeysEnum.VendorRoleName);
            return settings?.Value;
        }


        public async Task<string> GetURlAsync()
        {

            var settings = await _settingService.GetByIdAsync((int)SettingKeysEnum.AppUrl);
            return settings?.Value;
        }


        public async Task<bool> DisplayTokenInWebViewAsync()
        {
            var settings = await _settingService.GetByIdAsync((int)SettingKeysEnum.DisplayTokenInWebView);
            return settings?.Value == "1";
        }

        public async Task<bool> CheckCachedNavbarAsync()
        {
            var settings = await _settingService.GetByIdAsync((int)SettingKeysEnum.CachedNavbar);
            return settings?.Value == "1";
        }

        public async Task<EmailFromInfo> GetEmailSettingsAsync()
        {

            var settings = await _settingService.GetEnabledListBySharedKeysAsync(
                new List<string> { SettingSharedKeysEnum.Email.ToString(), SettingSharedKeysEnum.Email_CC.ToString() });
            if (settings == null) return null;
            EmailFromInfo model = new EmailFromInfo
            {
                From = settings.FirstOrDefault(e => e.Key == SettingKeysEnum.Email_From.ToString())?.Value,
                FromName = settings.FirstOrDefault(e => e.Key == SettingKeysEnum.Email_FromName.ToString())?.Value,
                CC = settings.Where(e => e.SharedKey == SettingSharedKeysEnum.Email_CC.ToString())?.Select(c => c.Value)?.ToList(),
            };
            return model;
        }

        public async Task<List<string>> GetMenuItemsTypesAsync()
        {
            var settings = await _settingService.GetEnabledListBySharedKeyAsync(SettingSharedKeysEnum.ModulesOfMenuItemsTypes.ToString());
            return settings?.Select(s => s.Value)?.ToList();
        }
        public async Task<List<string>> GetNumericalStatisticsNamesAsync()
        {
            var settings = await _settingService.GetEnabledListBySharedKeyAsync(SettingSharedKeysEnum.NumericalStatisticsModulesNames.ToString());
            return settings?.Select(s => s.Value)?.ToList();
        }
        public async Task<List<StaticMenuItem>> GetStaticPagesAsync()
        {
            var settings = await _settingService.GetByIdAsync((int)SettingKeysEnum.StaticPages);
            return Helpers.Helpers.Deserialize<List<StaticMenuItem>>(settings?.Value);
        }

        #endregion
    }
}
