using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Pages.Settings
{
    public class PageServiceSettings : CCUServiceSettings, IPageServiceSettings
    {
        public PageServiceSettings(string contentsServiceUrl) : base(contentsServiceUrl)
        {

        }


        #region {Public Pages}   

        private string publicEndpointBase => $"{ContentsServiceEndpointBase}/api/v0.1/pages";

        public string GetPublicDynamicBySlugAsyncEndpoint => $"{publicEndpointBase}/Dynamic/Get";

        public string GetPublicDynamicByIdAsyncEndpoint => $"{publicEndpointBase}/Dynamic/Get/Id";

        #endregion


        #region {Pages Manager} 

        private string ManegmentEndpointBase => $"{ContentsServiceEndpointBase}/api/v0.1/PagesManager";
        #region {Get} 

        public string GetAsyncEndpoint => $"{ManegmentEndpointBase}/List"; 

        public string GetHtmlPageBySlugAsyncEndpoint => $"{ManegmentEndpointBase}/html/";

        public string GetSectionsPageBySlugAsyncEndpoint => $"{ManegmentEndpointBase}/sections/";

        public string GetHtmlPageByIdAsyncEndpoint => $"{ManegmentEndpointBase}/html/get/";

        public string GetSectionsPageByIdAsyncEndpoint => $"{ManegmentEndpointBase}/sections/get";

        #endregion


        #region { Create / Edit / Delete / Publish } 

        public string CreateHtmlPageAsyncEndpoint => $"{ManegmentEndpointBase}/html/create";

        public string CreateSectionsPageAsyncEndpoint => $"{ManegmentEndpointBase}/sections/create";

        public string UpdateHtmlPageAsyncEndpoint => $"{ManegmentEndpointBase}/html/update";

        public string UpdateSectionsPageAsyncEndpoint => $"{ManegmentEndpointBase}/sections/update";

        public string DeleteHtmlPageAsyncEndpoint => $"{ManegmentEndpointBase}/html/delete";

        public string DeleteSectionsPageAsyncEndpoint => $"{ManegmentEndpointBase}/sections/delete";

        public string PublishHtmlPageAsyncEndpoint => $"{ManegmentEndpointBase}/html/publish";

        public string PublishSectionsPageAsyncEndpoint => $"{ManegmentEndpointBase}/sections/publish";

        #endregion

        #endregion


    }
}
