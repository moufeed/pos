using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Pos.Settings
{
    public interface IPosApiSettings
    {

        #region -- Public  POSs --------------------------
        #endregion

        #region -- POSs Manager -------------------------


        string CreateEndpoint { get; }

        string VerifySlugUniqueEndpoint { get; }

        string  VerifySlugUniqueByNameEndpoint { get; }

        string GetPOSsForCurrentUserEndpoint { get; }
         
        string  GetByIdAndCurrentUserExceptSoftDeletedEndpoint { get; }
         
        string EditEndpoint { get; }

        string SoftDeleteByCurrentUserEndpoint { get; }
        #endregion
    }
}
