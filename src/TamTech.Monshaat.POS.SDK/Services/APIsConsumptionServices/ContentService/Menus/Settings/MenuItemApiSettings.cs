using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Menus.Settings
{
    public class MenuItemApiSettings : BaseAPISettings, IMenuItemApiSettings
    {


        public MenuItemApiSettings(string controller) : base(controller)
        {
        }

        #region {Menu Items}  Create / Edit / Delete / Publish

       public string CreateMenuItemAsyncEndpoint => $"{_AdminPath}/CreateAsync";

        public string EditMenuItemAsyncEndpoint => $"{_AdminPath}/EditAsync";

        public string DeleteMenuItemAsyncEndpoint => $"{_AdminPath}/PublishAsync";

        public string PublishMenuItemAsyncEndpoint => $"{_AdminPath}/HardDeleteAsync";


        #endregion  


    }
}
