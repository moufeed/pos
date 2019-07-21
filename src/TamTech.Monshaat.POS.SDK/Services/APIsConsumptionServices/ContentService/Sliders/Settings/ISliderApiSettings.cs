using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Sliders.Settings
{
    public interface ISliderApiSettings
    {

      

        #region Public Slider


        string GetPublishedBySettingIdEndpoint { get; }

        #endregion

        #region  Get       
        string GetAllEndpoint { get; }

        string GetByIdEndpoint { get; }     
        #endregion


        #region  GetAll / Get / Create / Edit / Delete / Publish

        string CreateEndpoint { get; }

        string UpdateEndpoint { get; }

        string DeleteByIdEndpoint { get; }

        string publishByIdEndpoint { get; }



        #endregion

       

        
    }
}

 