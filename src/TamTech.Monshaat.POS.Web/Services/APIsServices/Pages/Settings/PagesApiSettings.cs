using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Services.APIsServices.Pages.Settings
{
    public class PagesApiSettings : BaseAPISettings, IPagesApiSettings
    {
        public PagesApiSettings(string controller) : base(controller)
        {
        }


        #region get 
            #region public
            public string GetPublicBySlugEndpoint => $"{_PortlPath}/Async";

            public string GetPublicPageSummaryByIdEndpoint => $"{_PortlPath}/Async";

            public string GetPublishedHtmlPageByIdEndpoint => $"{_PortlPath}/Async";

            public string GetPublishedSectionsPageByIdEndpoint => $"{_PortlPath}/Async";

            public string GetPublishedBySettingIdEndpoint => $"{_PortlPath}/Async";

            public string GetPublishedHtmlBySettingIdEndpoint => $"{_PortlPath}/Async";

            public string GetPublishedSectionsBySettingIdEndpoint => $"{_PortlPath}/Async";

            #endregion


        public string GetAllEndpoint => $"{_AdminPath}/Async";

        public string GetHtmlPageByIdEndpoint => $"{_AdminPath}/Async";

        public string GetSectionsPageByIdEndpoint => $"{_AdminPath}/Async";

        #endregion



        public string CreateHtmlPageEndpoint =>  $"{_AdminPath}/Async";

        public string CreateSectionsPageEndpoint =>  $"{_AdminPath}/Async";

        public string EditHtmlPageEndpoint =>  $"{_AdminPath}/Async";

        public string EditSectionsPageEndpoint =>  $"{_AdminPath}/Async";

        public string DeleteHtmlPageEndpoint =>  $"{_AdminPath}/Async";

        public string DeleteSectionsPageEndpoint =>  $"{_AdminPath}/Async";

        public string PublishHtmlPageEndpoint =>  $"{_AdminPath}/Async";

        public string PublishSectionsPageEndpoint =>  $"{_AdminPath}/Async";
    }
}
