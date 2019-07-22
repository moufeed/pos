using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Sliders.Settings
{
    public interface ISliderItemApiSettings
    {

        #region  Get 
        string GetSliderItemByIdEndpoint { get; }

        #endregion


        #region Create / Edit / Delete / Publish     
        string CreateSliderItemEndpoint { get; }

        string UpdateSliderItemEndpoint { get; }

        string publishSliderItemByIdEndpoint { get; }

        string DeleteSliderItemByIdEndpoint { get; }

     

        #endregion
    }
}

 