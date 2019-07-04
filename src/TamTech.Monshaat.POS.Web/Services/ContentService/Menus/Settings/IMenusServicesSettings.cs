using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Menus.Settings
{
    public interface IMenusServicesSettings
    {
       
        #region {Public Menus}    

         string GetPublicDynamicByKeyAsyncEndpoint { get; }

        #endregion




        #region {Menus Manager}  

        #region {Get} 

         string GetAllAsyncEndpoint { get; }

         string GetByIdAsyncEndpoint { get; }
        #endregion


        #region  {Menu}  Create / Edit / Delete / Publish

         string CreateAsyncEndpoint { get; }

         string EditAsyncEndpoint { get; }

        string DeleteAsyncEndpoint { get; }

        #endregion


        #region {Menu Items}  Create / Edit / Delete / Publish

         string CreateMenuItemAsyncEndpoint { get; }

         string EditMenuItemAsyncEndpoint { get; }

         string DeleteMenuItemAsyncEndpoint { get; }

         string PublishMenuItemAsyncEndpoint { get; }
        
         string GetPublicDynamicMenuItemsTypesListsByTypesAsyncEndpoint { get; }
        #endregion
        #endregion
    }
}
