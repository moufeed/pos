using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Brands.Settings
{
    public class BrandServiceSettings : ContentsServiceSettings, IBrandServiceSettings
    {
        public BrandServiceSettings(string contentsServiceUrl) : base(contentsServiceUrl)
        {
            
        }


        private string endpointBase => $"{ContentsServiceEndpointBase}/api/v0.1/Brands";

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
