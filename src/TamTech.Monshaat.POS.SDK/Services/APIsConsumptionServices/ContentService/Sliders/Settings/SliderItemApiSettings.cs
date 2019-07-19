using TamTech.Monshaat.POS.Web.Models.Shared;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Sliders.Settings
{
    public class SliderItemApiSettings : BaseAPISettings, ISliderItemApiSettings
    {


        public SliderItemApiSettings(BackendApiSettingsModel settings, string controller) : base(settings, controller)
        {
        }


        #region manager

        #region Get
        public string GetSliderItemByIdEndpoint => $"{_AdminPath}/GetSliderItemByIdAsync";
        #endregion


        #region Create / Edit / Publish / Delete      
        public string CreateSliderItemEndpoint => $"{_AdminPath}/CreateAsync";

        public string UpdateSliderItemEndpoint => $"{_AdminPath}/EditAsync";

        public string publishSliderItemByIdEndpoint => $"{_AdminPath}/PublishAsync";

        public string DeleteSliderItemByIdEndpoint => $"{_AdminPath}/HardDeleteAsync";
        #endregion
        #endregion
    }
}
