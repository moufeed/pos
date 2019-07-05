using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.APIsServices.Types.Settings
{
    public class TypeApiSettings : ITypeApiSettings
    {
        public TypeApiSettings()
        {

        }

        const string  apiRoot = "http://localhost:53409/api";
        const string controller = "CUTypes";
        const string admin = "Admin";
        string _portlPath = $"{apiRoot}/{controller}";
        string _adminPath = $"{apiRoot}/{admin}/{controller}";




        public string GetPublishedBySlugEndpoint => $"{_portlPath}/GetPublishedBySlugEndpointAsync";

        public string GetPublishedListEndpoint => $"{_portlPath}/GetPublishedListAsync";

        public string GetPublishedLimitedListEndpoint => $"{_portlPath}/GetPublishedLimitedListAsync";

        public string GetSelectListEndpoint => $"{_adminPath}/GetSelectListAsync";

        public string GetAllSelectListEndpoint => $"{_adminPath}/GetAllSelectListAsync";

        public string GetByIdExceptSoftDeletedEndpoint => $"{_adminPath}/GetByIdExceptSoftDeletedAsync";

        public string GetAllExceptSoftDeletedEndpoint => $"{_adminPath}/GetAllExceptSoftDeletedAsync";

        public string GetExceptSoftDeletedEndpoint => $"{_adminPath}/GetExceptSoftDeletedAsync";

        public string CreateEndpoint => $"{_adminPath}/CreateAsync";

        public string EditEndpoint => $"{_adminPath}/EditAsync";

        public string SoftDeleteEndpoint => $"{_adminPath}/SoftDeleteAsync";

        public string PublishEndpoint => $"{_adminPath}/PublishAsync";











    }
}
