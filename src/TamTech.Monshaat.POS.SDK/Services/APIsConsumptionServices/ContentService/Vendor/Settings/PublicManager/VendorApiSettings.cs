 using TamTech.Monshaat.POS.Web.Models.Shared;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Vendor.Settings
{
    public class VendorApiSettings : BaseAPISettings, IVendorApiSettings
    {
        public VendorApiSettings(BackendApiSettingsModel settings, string controller) : base(settings, controller)
        {
        }

        public string GetPersonForCurrentUserEndpoint => $"{_PortlPath}/GetPersonForCurrentUserAsync";

        public string CheckTheCurrentUserIsRegisteredAsVendorEndpoint => $"{_PortlPath}/CheckTheCurrentUserIsRegisteredAsVendorAsync";

        public string CreateEndpoint => $"{_PortlPath}/CreateAsync";

        public string EditEndpoint => $"{_PortlPath}/EditAsync";

        public string VerifyVendorSlugIsUnique => $"{_PortlPath}/VerifyVendorSlugIsUnique";

        public string VerifyVendorSlugUniqueByNameEndpoint => $"{_PortlPath}/VerifyVendorSlugUniqueByNameAsync";

        public string VerifyCRUniqueEndpoint => $"{_PortlPath}/VerifyCRUniqueAsync";
    }
}
