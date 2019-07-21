using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Biography.settings
{
    public interface IBiographyApiSettings
    {
        string GetByGroupIdEndpoint { get; }

        string EditEndpoint { get; }

        string GetAllEndpoint { get; }

    }
}
