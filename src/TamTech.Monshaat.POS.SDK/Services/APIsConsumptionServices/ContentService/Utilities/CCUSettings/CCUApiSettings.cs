using TamTech.Monshaat.POS.Web.Models.Shared;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Utilities.Settings
{
    public class CCUServiceSettings : BaseAPISettings , ICCUApiSettings
    {
        public CCUServiceSettings(BackendApiSettingsModel settings, string controller) : base(settings, controller)
        {
        }

        public string GetNumericalStatisticsEndpoint => $"{_AdminPath}/GetNumericalStatisticsAsync";
        public string GetListsModulesForMenuItemsTypesEndpoint => $"{_AdminPath}/GetListsModulesForMenuItemsTypesAsync";
    }
}
