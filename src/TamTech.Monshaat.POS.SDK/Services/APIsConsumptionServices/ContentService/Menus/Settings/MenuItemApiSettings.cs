using TamTech.Monshaat.POS.Web.SDK.Models.Shared;

namespace TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Menus.Settings
{
    public class MenuItemApiSettings : BaseAPISettings, IMenuItemApiSettings
    {


        public MenuItemApiSettings(BackendApiSettings settings, string controller) : base(settings, controller)
        {
        }

        #region {Menu Items}  Create / Edit / Delete / Publish

       public string CreateMenuItemAsyncEndpoint => $"{_AdminPath}/CreateAsync";

        public string EditMenuItemAsyncEndpoint => $"{_AdminPath}/EditAsync";

        public string  PublishMenuItemAsyncEndpoint => $"{_AdminPath}/PublishAsync";

        public string DeleteMenuItemAsyncEndpoint => $"{_AdminPath}/HardDeleteAsync";


        #endregion  


    }
}
