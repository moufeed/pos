using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Menus.Settings
{
    public interface IMenuApiSettings
    {
       
        #region {Public}    

         string GetPublicBySettingIdEndpoint { get; }
         string GetPublicByKeyAsyncEndpoint { get; }

        #endregion       

        #region {Manager}  

        #region {Get} 

         string GetAllAsyncEndpoint { get; }

         string GetByIdAsyncEndpoint { get; }
        #endregion


        #region   Create / Edit / Delete 

         string CreateAsyncEndpoint { get; }

         string EditAsyncEndpoint { get; }

        string SoftDeleteAsyncEndpoint { get; }

        #endregion     
       
        #endregion
    }

   
}
