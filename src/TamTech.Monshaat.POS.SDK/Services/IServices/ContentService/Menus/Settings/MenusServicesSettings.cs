using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Menus.Settings
{
    public class MenusServicesSettings : CCUServiceSettings, IMenusServicesSettings
    {
        public MenusServicesSettings(string contentsServiceUrl) : base(contentsServiceUrl)
        {

        }






        #region {Public Menus}   

        public string publicEndpointBase => $"{ContentsServiceEndpointBase}/api/v0.1/Menus"; 

        public string GetPublicDynamicByKeyAsyncEndpoint => $"{publicEndpointBase}/Dynamic/Get";

        #endregion




        #region {Menus Manager} 

        public string ManegmentEndpointBase => $"{ContentsServiceEndpointBase}/api/v0.1/MenusManager";

        #region {Get} 

        public string GetAllAsyncEndpoint => $"{ManegmentEndpointBase}/All";

        public string GetByIdAsyncEndpoint => $"{ManegmentEndpointBase}/Get";

        #endregion


        #region  {Menu}  Create / Edit / Delete / Publish

        public string CreateAsyncEndpoint => $"{ManegmentEndpointBase}/Create";

        public string EditAsyncEndpoint => $"{ManegmentEndpointBase}/Edit";

        public string DeleteAsyncEndpoint => $"{ManegmentEndpointBase}/Delete";

        #endregion


        #region {Menu Items}  Create / Edit / Delete / Publish

        public string CreateMenuItemAsyncEndpoint => $"{ManegmentEndpointBase}/items/Create";

        public string EditMenuItemAsyncEndpoint => $"{ManegmentEndpointBase}/items/Edit";

        public string DeleteMenuItemAsyncEndpoint => $"{ManegmentEndpointBase}/items/Delete";

        public string PublishMenuItemAsyncEndpoint => $"{ManegmentEndpointBase}/items/Publish";


        public string GetPublicDynamicMenuItemsTypesListsByTypesAsyncEndpoint => $"{ManegmentEndpointBase}/items/types/Dynamic/List";
        #endregion


        #endregion
    }
}
