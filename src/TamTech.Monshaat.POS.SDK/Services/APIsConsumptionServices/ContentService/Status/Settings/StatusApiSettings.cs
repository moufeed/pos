using TamTech.Monshaat.POS.Web.SDK.Models.Shared;

namespace TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Status.Settings
{
    public class StatusApiSettings : BaseAPISettings, IStatusApiSettings , IVendorStatusApiSettings , IPosStatusApiSettings , IContactUsStatusApiSettings
    {
        public StatusApiSettings(BackendApiSettings settings, string controller) : base(settings, controller)
        {
        }

        public string GetAllSelectListEndpoint => $"{_AdminPath}/GetAllSelectListAsync";

        public string GetAllEndpoint => $"{_AdminPath}/GetAllAsync";
    }
}
