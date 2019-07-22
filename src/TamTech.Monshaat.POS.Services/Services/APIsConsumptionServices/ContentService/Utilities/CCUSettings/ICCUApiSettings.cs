using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Utilities.Settings
{
    public interface ICCUApiSettings
    {
        string GetNumericalStatisticsEndpoint { get; }
        string GetListsModulesForMenuItemsTypesEndpoint { get; }

      
    }
}
