using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Services.APIsServices.Pos.Settings
{
    public class PosAdminApiSettings : BaseAPISettings, IPosAdminApiSettings
    {
        public PosAdminApiSettings(string controller) : base(controller)
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
