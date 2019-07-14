using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Attributes.Settings
{
    public class AttributeApiSettings : BaseAPISettings, IAttributeApiSettings, IPOSAttributeApiSettings
    {

        public AttributeApiSettings(string controller) : base(controller)
        {
        }

        public string GetPublishedBySlugEndpoint => $"{_PortlPath}/GetPublishedBySlugEndpointAsync";

        public string GetPublishedListEndpoint => $"{_PortlPath}/GetPublishedListAsync";

        public string GetPublishedLimitedListEndpoint => $"{_PortlPath}/GetPublishedLimitedListAsync";

        public string GetSelectListEndpoint => $"{_AdminPath}/GetSelectListAsync";

        public string GetAllSelectListEndpoint => $"{_AdminPath}/GetAllSelectListAsync";

        public string GetByIdExceptSoftDeletedEndpoint => $"{_AdminPath}/GetByIdExceptSoftDeletedAsync";

        public string GetAllExceptSoftDeletedEndpoint => $"{_AdminPath}/GetAllExceptSoftDeletedAsync";

        public string GetExceptSoftDeletedEndpoint => $"{_AdminPath}/GetExceptSoftDeletedAsync";

        public string CreateEndpoint => $"{_AdminPath}/CreateAsync";

        public string EditEndpoint => $"{_AdminPath}/EditAsync";

        public string SoftDeleteEndpoint => $"{_AdminPath}/SoftDeleteAsync";
 
        public string PublishEndpoint => $"{_AdminPath}/PublishAsync";











    }
}
