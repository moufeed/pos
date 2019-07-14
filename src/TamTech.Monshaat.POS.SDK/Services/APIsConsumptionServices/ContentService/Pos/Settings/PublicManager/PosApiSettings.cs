using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Pos.Settings
{
    public class PosApiSettings : BaseAPISettings, IPosApiSettings
    {
        public PosApiSettings(string controller) : base(controller)
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
