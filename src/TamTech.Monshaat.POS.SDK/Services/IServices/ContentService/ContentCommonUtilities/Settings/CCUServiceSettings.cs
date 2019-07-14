using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Utilities.Settings;

namespace TamTech.Monshaat.POS.Web.Services.ContentService
{
    public class CCUServiceSettings : ICCUApiSettings
    {
        private string _contentsServiceUrl;


        public CCUServiceSettings(string contentsServiceUrl)
        {
            _contentsServiceUrl = contentsServiceUrl;
        }


        public string ContentsServiceEndpointBase => _contentsServiceUrl;

        public string ClientId => "clientapp";

        public string ClientSecret => "h8yI4DydzI5ZsKCMGTs9hfTdI1vRS3qfTo9Go92q3aM=";

        public string GetNumericalStatisticsAsync => throw new NotImplementedException();
    }
}
