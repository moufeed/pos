using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Contact.Settings
{
    public class ContactUsApiSettings : BaseAPISettings, IContactUsApiSettings
    {
        public ContactUsApiSettings(string controller) : base(controller)
        {
        }

        public string CreateEndpoint => $"{_PortlPath}/CreateAsync";

        public string ReplayEndpoint => $"{_AdminPath}/ReplayAsync";

        public string RemoveReplayEndpoint => $"{_AdminPath}/RemoveReplayAsync";

        public string GetExceptSoftDeletedEndpoint => $"{_AdminPath}/GetExceptSoftDeletedAsync";

        public string GetByIdExceptSoftDeletedEndpoint => $"{_AdminPath}/GetByIdExceptSoftDeletedAsync";

        public string GetByIdAndSetStatusEndpoint => $"{_AdminPath}/GetByIdAndSetStatusAsync";
    }
}

 