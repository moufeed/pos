using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Utilities.Settings
{
    public class CCUServiceSettings : BaseAPISettings , ICCUApiSettings
    {
        public CCUServiceSettings(string controller) : base(controller)
        {
        }

        public string GetNumericalStatisticsEndpoint => $"{_AdminPath}/GetNumericalStatisticsAsync";
        public string GetListsModulesForMenuItemsTypesEndpoint => $"{_AdminPath}/GetListsModulesForMenuItemsTypesAsync";
    }
}
