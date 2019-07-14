using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Settings.Settings
{
    public interface ISettingsApiSettings
    {

        string GetByIdEndpoint { get; }
        string GetByKeyEndpoint { get; }
        string GetByGroupIdEndpoint { get; }
        string GetListBySharedKeyEndpoint { get; }
        string GetListBySharedKeysEndpoint { get; }
        string GetAllEndpoint { get; }
        string GetByGroupIdsEndpoint { get; }
        string GetListByKeysEndpoint { get; }
        string GetListByIdsEndpoint { get; }

    }
}
