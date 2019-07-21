using TamTech.Monshaat.POS.Web.SDK.Models.Shared;

namespace TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Biography.settings
{
    public class BiographyApiSettings : BaseAPISettings, IBiographyApiSettings
    {
        public BiographyApiSettings(BackendApiSettingsModel settings, string controller) : base(settings, controller)
        {
        }

        public string GetByGroupIdEndpoint => $"{_AdminPath}/GetByGroupIdAsync";

        public string EditEndpoint => $"{_AdminPath}/EditAsync";

        public string GetAllEndpoint => $"{_PortlPath}/GetAllAsync";
    }
}
