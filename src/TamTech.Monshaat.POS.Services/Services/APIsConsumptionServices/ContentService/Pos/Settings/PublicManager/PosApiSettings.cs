using TamTech.Monshaat.POS.Web.Models.Shared;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Pos.Settings
{
    public class PosApiSettings : BaseAPISettings, IPosApiSettings
    {
        public PosApiSettings(BackendApiSettingsModel settings, string controller) : base(settings, controller)
        {
        }

        public string CreateEndpoint => $"{_PortlPath}/CreateAsync";

        public string VerifySlugUniqueEndpoint => $"{_PortlPath}/VerifySlugUniqueAsync";

        public string VerifySlugUniqueByNameEndpoint => $"{_PortlPath}/VerifySlugUniqueByNameAsync";

        public string GetPOSsForCurrentUserEndpoint => $"{_PortlPath}/GetPOSsForCurrentUserAsync";

        public string GetByIdAndCurrentUserExceptSoftDeletedEndpoint => $"{_PortlPath}/GetByIdAndCurrentUserExceptSoftDeletedAsync";

        public string EditEndpoint => $"{_PortlPath}/EditAsync";

        public string SoftDeleteByCurrentUserEndpoint => $"{_PortlPath}/SoftDeleteByCurrentUserAsync";
    }
}
