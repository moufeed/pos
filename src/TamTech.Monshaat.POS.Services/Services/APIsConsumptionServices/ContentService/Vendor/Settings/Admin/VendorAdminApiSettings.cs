using TamTech.Monshaat.POS.Web.Models.Shared;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Vendor.Settings
{
    public class VendorAdminApiSettings : BaseAPISettings, IVendorAdminApiSettings
    {
        public VendorAdminApiSettings(BackendApiSettingsModel settings, string controller) : base(settings, controller)
        {
        }

        public string GetVendorActionsEndpoint => $"{_AdminPath}/GetVendorActionsAsync";

        public string GetExceptSoftDeletedEndpoint => $"{_AdminPath}/GetExceptSoftDeletedAsync";

        public string GetByIdExceptSoftDeletedEndpoint => $"{_AdminPath}/GetByIdExceptSoftDeletedAsync";

        public string SetActionEndpoint => $"{_AdminPath}/SetActionAsync";

        public string SoftDeleteEndpoint => $"{_AdminPath}/SoftDeleteAsync";

        public string ActivateEndpoint => $"{_AdminPath}/ActivateAsync";

        public string GetStatusHistoriesListEndpoint => $"{_AdminPath}/GetStatusHistoriesListAsync";
    }
}
