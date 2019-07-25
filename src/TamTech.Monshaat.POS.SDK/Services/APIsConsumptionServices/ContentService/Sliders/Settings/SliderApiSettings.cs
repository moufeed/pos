using TamTech.Monshaat.POS.Web.SDK.Models.Shared;

namespace TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Sliders.Settings
{
    public class SliderApiSettings : BaseAPISettings, ISliderApiSettings
    {


        public SliderApiSettings(BackendApiSettings settings, string controller) : base(settings, controller)
        {
        }

        #region public
        public string GetPublishedBySettingIdEndpoint => $"{_PortlPath}/GetPublicBySettingIdAsync";

        #endregion

        #region manager

        #region Get

        public string GetAllEndpoint => $"{_AdminPath}/GetAllExceptSoftDeletedAsync";

        public string GetByIdEndpoint => $"{_AdminPath}/GetByIdExceptSoftDeletedAsync";
        #endregion

        #region Create / Edit / Publish / Delete

        public string CreateEndpoint => $"{_AdminPath}/CreateAsync";

        public string UpdateEndpoint => $"{_AdminPath}/EditAsync";

        public string DeleteByIdEndpoint => $"{_AdminPath}/SoftDeleteAsync";

        public string publishByIdEndpoint => $"{_AdminPath}/PublishAsync";

    
        #endregion
        #endregion
    }
}
