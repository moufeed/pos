using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Services.Settings
{
    public class ServicesServiceSettings : ContentsServiceSettings , IServicesServiceSettings
    {
        public ServicesServiceSettings(string contentsServiceUrl) : base(contentsServiceUrl)
        {

        }


        private string publicEndpointBase => $"{ContentsServiceEndpointBase}/api/v0.1/Services";
    }
}
