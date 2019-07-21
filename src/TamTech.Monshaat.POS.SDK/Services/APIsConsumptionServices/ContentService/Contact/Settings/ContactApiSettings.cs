using TamTech.Monshaat.POS.Web.SDK.Models.Shared;

namespace TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Contact.Settings
{
    public class ContactUsApiSettings : BaseAPISettings, IContactUsApiSettings
    {
        public ContactUsApiSettings(BackendApiSettingsModel settings, string controller) : base(settings, controller)
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

 