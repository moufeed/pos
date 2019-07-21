using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Pos.Settings
{
    public interface IPosAdminApiSettings
    {
        string GetExceptSoftDeletedEndpoint { get; }

        string GetByIdExceptSoftDeletedEndpoint { get; }
         
        string SoftDeleteEndpoint { get; }

        string GetPOSActionsEndpoint { get; }

        string SetActionEndpoint { get; }

        string PublishEndpoint { get; }

        string GetStatusHistoriesListEndpoint { get; }
    }
}
