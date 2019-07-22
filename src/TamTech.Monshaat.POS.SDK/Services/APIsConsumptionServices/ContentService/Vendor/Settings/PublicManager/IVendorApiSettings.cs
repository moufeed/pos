using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Vendor.Settings
{
    public interface IVendorApiSettings 
    {
        #region Vendors Manager

        #region Get

        string GetPersonForCurrentUserEndpoint { get; }

        string CheckTheCurrentUserIsRegisteredAsVendorEndpoint { get; }



        #endregion

        #region  Create / Edit  

        string CreateEndpoint { get; }

        string EditEndpoint { get; }

        string VerifyVendorSlugIsUnique { get; }

        string VerifyVendorSlugUniqueByNameEndpoint { get; }

        string VerifyCRUniqueEndpoint { get; }
        #endregion
        #endregion
    }
}
