using TamTech.Monshaat.POS.Web.SDK.Models.Shared;

namespace TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Pos.Settings
{
    public class PosAdminApiSettings : BaseAPISettings, IPosAdminApiSettings
    {
        public PosAdminApiSettings(BackendApiSettings settings, string controller) : base(settings, controller)
        {
        }

        public string GetExceptSoftDeletedEndpoint => $"{_AdminPath}/GetExceptSoftDeletedAsync";

        public string GetByIdExceptSoftDeletedEndpoint => $"{_AdminPath}/GetByIdExceptSoftDeletedAsync";

        public string SoftDeleteEndpoint => $"{_AdminPath}/SoftDeleteAsync";

        public string GetPOSActionsEndpoint => $"{_AdminPath}/GetPOSActionsAsync";

        public string SetActionEndpoint => $"{_AdminPath}/SetActionAsync";

        public string PublishEndpoint => $"{_AdminPath}/PublishAsync";

        public string GetStatusHistoriesListEndpoint => $"{_AdminPath}/GetStatusHistoriesListAsync";
    }
}
