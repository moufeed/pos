using TamTech.Monshaat.POS.Web.SDK.Models.Shared;

namespace TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Pages.Settings
{
    public class PagesApiSettings : BaseAPISettings, IPagesApiSettings
    {
        public PagesApiSettings(BackendApiSettingsModel settings, string controller) : base(settings, controller)
        {
        }



        #region public
        public string GetAllPublishedSlugsEndpoint => $"{_PortlPath}/GetAllPublishedSlugsAsync";
        public string GetPublicBySlugEndpoint => $"{_PortlPath}/GetPublicBySlugAsync";

        public string GetPublicPageSummaryByIdEndpoint => $"{_PortlPath}/GetPublicByIdAsync";

        public string GetPublishedHtmlPageByIdEndpoint => $"{_PortlPath}/GetPublishedHtmlByIdAsync";

        public string GetPublishedSectionsPageByIdEndpoint => $"{_PortlPath}/GetPublishedSectionsByIdAsync";

        public string GetPublishedBySettingIdEndpoint => $"{_PortlPath}/GetPublishedBySettingIdAsync";

        public string GetPublishedHtmlBySettingIdEndpoint => $"{_PortlPath}/GetPublishedHtmlBySettingIdAsync";

        public string GetPublishedSectionsBySettingIdEndpoint => $"{_PortlPath}/GetPublishedSectionsBySettingIdAsync";

        #endregion


        #region Admin 
        public string GetAllEndpoint => $"{_AdminPath}/GetAllExceptSoftDeletedAsync";

        public string GetHtmlPageByIdEndpoint => $"{_AdminPath}/GetHtmlPageByIdAsync";

        public string GetSectionsPageByIdEndpoint => $"{_AdminPath}/GetSectionsPageByIdAsync";

        #endregion



        public string CreateHtmlPageEndpoint => $"{_AdminPath}/CreateAsync";

        public string CreateSectionsPageEndpoint => $"{_AdminPath}/CreateAsync";

        public string EditHtmlPageEndpoint => $"{_AdminPath}/EditAsync";

        public string EditSectionsPageEndpoint => $"{_AdminPath}/EditAsync";

        public string DeleteHtmlPageEndpoint => $"{_AdminPath}/SoftDeleteHtmlPageAsync";

        public string DeleteSectionsPageEndpoint => $"{_AdminPath}/SoftDeleteSectionsPageAsync";

        public string PublishHtmlPageEndpoint => $"{_AdminPath}/PublishHtmlPageAsync";

        public string PublishSectionsPageEndpoint => $"{_AdminPath}/PublishSectionsPageAsync";
    }
}
