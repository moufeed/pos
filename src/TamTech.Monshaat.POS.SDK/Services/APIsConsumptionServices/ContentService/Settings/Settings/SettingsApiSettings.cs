using TamTech.Monshaat.POS.Web.SDK.Models.Shared;

namespace TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Settings.Settings
{
    public class SettingsApiSettings : BaseAPISettings, ISettingsApiSettings
    {
        public SettingsApiSettings(BackendApiSettings settings, string controller) : base(settings, controller)
        {
        }

        public string GetByIdEndpoint => $"{_PortlPath}/GetByIdAsync";

        public string GetByKeyEndpoint => $"{_PortlPath}/GetByKeyAsync";

        public string GetByGroupIdEndpoint => $"{_PortlPath}/GetByGroupIdAsync";

        public string GetListBySharedKeyEndpoint => $"{_PortlPath}/GetListBySharedKeyAsync";

        public string GetListBySharedKeysEndpoint => $"{_PortlPath}/GetListBySharedKeysAsync";

        public string GetAllEndpoint => $"{_PortlPath}/GetAllAsync";

        public string GetByGroupIdsEndpoint => $"{_PortlPath}/GetByGroupIdsAsync";

        public string GetListByKeysEndpoint => $"{_PortlPath}/GetListByKeysAsync";

        public string GetListByIdsEndpoint => $"{_PortlPath}/GetListByIdsAsync";
    }
}
