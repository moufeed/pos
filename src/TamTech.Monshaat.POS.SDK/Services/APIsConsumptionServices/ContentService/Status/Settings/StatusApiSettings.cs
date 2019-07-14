using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Status.Settings
{
    public class StatusApiSettings : BaseAPISettings, IStatusApiSettings , IVendorStatusApiSettings , IPosStatusApiSettings , IContactUsStatusApiSettings
    {
        public StatusApiSettings(string controller) : base(controller)
        {
        }

        public string GetAllSelectListEndpoint => $"{_AdminPath}/GetAllSelectListAsync";

        public string GetAllEndpoint => $"{_AdminPath}/GetAllAsync";
    }
}
