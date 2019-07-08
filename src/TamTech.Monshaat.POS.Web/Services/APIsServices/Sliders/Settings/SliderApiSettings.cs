using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Services.APIsServices.Sliders.Settings
{
    public class SliderApiSettings : BaseAPISettings, ISliderApiSettings
    {


        public SliderApiSettings(string controller) : base(controller)
        {
        }


        public string GetPublishedBySettingIdEndpoint => $"{_PortlPath}/GetPublishedBySettingIdAsync";


        #region manager

        public string GetAllEndpoint => $"{_AdminPath}/GetAllAsync";

        public string GetByIdEndpoint => $"{_AdminPath}/GetByIdAsync";

        public string CreateEndpoint => $"{_AdminPath}/CreateASync";

        public string UpdateEndpoint => $"{_AdminPath}/UpdateAsync";

        public string DeleteByIdEndpoint => $"{_AdminPath}/DeleteByIdAsync";

        public string publishByIdEndpoint => $"{_AdminPath}/publishByIdAsync";

        public string GetSliderItemByIdEndpoint => $"{_AdminPath}/GetSliderItemByIdAsync";

        public string CreateSliderItemEndpoint => $"{_AdminPath}/CreateSliderItemASync";

        public string UpdateSliderItemEndpoint => $"{_AdminPath}/UpdateSliderItemAsync";

        public string publishSliderItemByIdEndpoint => $"{_AdminPath}/publishSliderItemByIdAsync";

        public string DeleteSliderItemByIdEndpoint => $"{_AdminPath}/DeleteSliderItemByIdAsync";

        #endregion
    }
}
