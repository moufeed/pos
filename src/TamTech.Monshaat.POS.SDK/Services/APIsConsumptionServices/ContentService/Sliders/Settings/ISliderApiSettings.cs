using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Sliders.Settings
{
    public interface ISliderApiSettings
    {

        #region Sliders

        #region Public Slider


        string GetPublishedBySettingIdEndpoint { get; }

        #endregion

        #region  GetAll / Get / Create / Edit / Delete / Publish

        string GetAllEndpoint { get; }

        string GetByIdEndpoint { get; }

        string CreateEndpoint { get; }

        string UpdateEndpoint { get; }

        string DeleteByIdEndpoint { get; }

        string publishByIdEndpoint { get; }



        #endregion

        #endregion



        #region Slider Items 

        #region  Get / Create / Edit / Delete / Publish


        string GetSliderItemByIdEndpoint { get; }

        string CreateSliderItemEndpoint { get; }

        string UpdateSliderItemEndpoint { get; }

        string publishSliderItemByIdEndpoint { get; }

        string DeleteSliderItemByIdEndpoint { get; }

        #endregion

        #endregion
    }
}

 