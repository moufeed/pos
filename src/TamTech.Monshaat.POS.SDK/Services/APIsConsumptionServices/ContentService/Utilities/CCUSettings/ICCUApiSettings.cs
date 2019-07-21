using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Utilities.Settings
{
    public interface ICCUApiSettings
    {
        string GetNumericalStatisticsEndpoint { get; }
        string GetListsModulesForMenuItemsTypesEndpoint { get; }

      
    }
}
