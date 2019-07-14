using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Biography.settings
{
    public class BiographyApiSettings : BaseAPISettings, IBiographyApiSettings
    {
        public BiographyApiSettings(string controller) : base(controller)
        {
        }

        public string GetByGroupIdEndpoint => $"{_AdminPath}/GetByGroupIdAsync";

        public string EditEndpoint => $"{_AdminPath}/EditAsync";

        public string GetAllEndpoint => $"{_PortlPath}/GetAllAsync";
    }
}
