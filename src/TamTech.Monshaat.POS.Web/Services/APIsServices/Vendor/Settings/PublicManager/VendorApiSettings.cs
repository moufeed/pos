using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Services.APIsServices.Vendor.Settings
{
    public class VendorApiSettings : BaseAPISettings, IVendorApiSettings
    {
        public VendorApiSettings(string controller) : base(controller)
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
