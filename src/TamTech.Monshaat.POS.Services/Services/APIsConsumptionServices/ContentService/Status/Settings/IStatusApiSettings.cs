using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Status.Settings
{
   public interface IStatusApiSettings
    {

        #region Services Manager

        #region Get

        string GetAllSelectListEndpoint { get; }


        string GetAllEndpoint { get; }
        #endregion


        #region   Create / Edit / Delete


        #endregion



        #endregion

    }
}
