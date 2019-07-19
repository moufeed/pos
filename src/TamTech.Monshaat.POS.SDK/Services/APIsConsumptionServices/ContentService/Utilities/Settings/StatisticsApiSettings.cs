using TamTech.Monshaat.POS.Web.Models.Shared;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Utilities.Settings
{
    public class StatisticsApiSettings : BaseAPISettings, IStatisticsApiSettings
    {
        public StatisticsApiSettings(BackendApiSettingsModel settings, string controller) : base(settings, controller)
        {
        }

        public string GetPOSNumericalStatisticsByStatusEndpoint => $"{_AdminPath}/GetPOSNumericalStatisticsByStatusAsync";

        public string GetPOSNumericalStatisticsBySectorEndpoint => $"{_AdminPath}/GetPOSNumericalStatisticsBySectorAsync";

        public string GetPOSNumericalStatisticsByTypeEndpoint => $"{_AdminPath}/GetPOSNumericalStatisticsByTypeAsync";

        public string GetVendorNumericalStatisticsByStatusEndpoint => $"{_AdminPath}/GetVendorNumericalStatisticsByStatusAsync";

        public string GetContactUsNumericalStatisticsByStatusEndpoint => $"{_AdminPath}/GetContactUsNumericalStatisticsByStatusAsync";

        public string GetContactUsNumericalStatisticsByTypeEndpoint => $"{_AdminPath}/GetContactUsNumericalStatisticsByTypeAsync";
    }
}
