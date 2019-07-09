using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Services.APIsServices.Utilities.Settings
{
    public class UtilitiesApiSettings : BaseAPISettings, IUtilitiesApiSettings
    {
        public UtilitiesApiSettings(string controller) : base(controller)
        {
        }

        public string GetPOSNumericalStatisticsByStatusEndpoint => $"{_AdminPath}/GetPOSNumericalStatisticsByStatusAsync";

        public string GetPOSNumericalStatisticsBySectorEndpoint => $"{_AdminPath}/GetPOSNumericalStatisticsBySectorAsync";

        public string GetPOSNumericalStatisticsByTypeEndpoint => $"{_AdminPath}/GetPOSNumericalStatisticsByTypeAsync";

        public string GetVendorNumericalStatisticsByStatusEndpoint => $"{_AdminPath}/GetVendorNumericalStatisticsByStatusAsync";

        public string GetContactUsNumericalStatisticsByStatusEndpoint => $"{_AdminPath}/GetContactUsNumericalStatisticsByStatusAsync";

        public string GetContactUsNumericalStatisticsByTypeEndpoint => $"{_AdminPath}/GetContactUsNumericalStatisticsByTypeAsync";
    }
}
