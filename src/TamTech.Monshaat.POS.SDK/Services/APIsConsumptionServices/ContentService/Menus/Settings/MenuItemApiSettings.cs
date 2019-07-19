using TamTech.Monshaat.POS.Web.Models.Shared;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Menus.Settings
{
    public class MenuItemApiSettings : BaseAPISettings, IMenuItemApiSettings
    {


        public MenuItemApiSettings(BackendApiSettingsModel settings, string controller) : base(settings, controller)
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
