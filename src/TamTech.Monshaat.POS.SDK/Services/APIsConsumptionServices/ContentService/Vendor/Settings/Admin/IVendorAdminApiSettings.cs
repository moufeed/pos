using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Vendor.Settings
{
  public interface IVendorAdminApiSettings
    {

        #region Get
        string GetVendorActionsEndpoint { get; }

        string GetExceptSoftDeletedEndpoint { get; }

        string GetByIdExceptSoftDeletedEndpoint { get; }
        #endregion

        #region

        string SetActionEndpoint { get; }

        string SoftDeleteEndpoint { get; }

        string ActivateEndpoint { get; }

        string GetStatusHistoriesListEndpoint { get; }
        #endregion
    }
}
