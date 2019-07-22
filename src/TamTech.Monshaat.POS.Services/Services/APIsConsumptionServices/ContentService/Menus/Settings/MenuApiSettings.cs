using TamTech.Monshaat.POS.Web.Models.Shared;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Menus.Settings
{
    public class MenuApiSettings : BaseAPISettings, IMenuApiSettings
    {


        public MenuApiSettings(BackendApiSettingsModel settings, string controller) : base(settings, controller)
        {
        }

        #region {Public}    

       public string GetPublicBySettingIdEndpoint => $"{_PortlPath}/GetPublicBySettingIdAsync";
        public string GetPublicByKeyAsyncEndpoint => $"{_PortlPath}/GetPublicByKeyAsync";

        #endregion

        #region {Manager}  

        #region {Get} 

        public string GetAllAsyncEndpoint => $"{_AdminPath}/GetAllExceptSoftDeletedAsync";

        public string GetByIdAsyncEndpoint => $"{_AdminPath}/GetByIdExceptSoftDeletedAsync";
        #endregion


        #region   Create / Edit / Delete 

        public string CreateAsyncEndpoint => $"{_AdminPath}/CreateAsync";

        public string EditAsyncEndpoint => $"{_AdminPath}/EditAsync";

        public string SoftDeleteAsyncEndpoint => $"{_AdminPath}/SoftDeleteAsync";

        #endregion

        #endregion



    }
}
