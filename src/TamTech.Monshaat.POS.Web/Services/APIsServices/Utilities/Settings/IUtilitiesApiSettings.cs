using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Services.APIsServices.Utilities.Settings
{
    public interface IUtilitiesApiSettings
    {
        string GetPOSNumericalStatisticsByStatusEndpoint { get; }

        string GetPOSNumericalStatisticsBySectorEndpoint { get; }

        string GetPOSNumericalStatisticsByTypeEndpoint { get; }

        string GetVendorNumericalStatisticsByStatusEndpoint { get; }

        string GetContactUsNumericalStatisticsByStatusEndpoint { get; }

        string GetContactUsNumericalStatisticsByTypeEndpoint { get; }
    }
}
