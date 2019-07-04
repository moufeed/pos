using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Categories.Settings
{
    public class CategoryServiceSettings : ContentsServiceSettings, ICategoryServiceSettings
    {
        public CategoryServiceSettings(string contentsServiceUrl) : base(contentsServiceUrl)
        {

        }

        private string endpointBase => $"{ContentsServiceEndpointBase}/api/v0.1/Categories";

        #region Public Brands 

        public string GetPublicDynamicListAsyncEndpoint => $"{endpointBase}/Dynamic/List";

        #endregion

        #region Brands Manager

        public string CreateAsyncEndpoint => $"{endpointBase}/Create";

        public string GetAsyncEndpoint => $"{endpointBase}/List";

        public string GetByIdAsyncEndpoint => $"{endpointBase}/api/v0.1/Brands/Get";

        #endregion
    }
}
