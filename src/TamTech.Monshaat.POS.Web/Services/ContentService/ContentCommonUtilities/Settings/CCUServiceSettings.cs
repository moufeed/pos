using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.ContentService
{
    public class CCUServiceSettings : ICCUServiceSettings
    {
        private string _contentsServiceUrl;


        public CCUServiceSettings(string contentsServiceUrl)
        {
            _contentsServiceUrl = contentsServiceUrl;
        }


        public string ContentsServiceEndpointBase => _contentsServiceUrl;

        public string ClientId => "clientapp";

        public string ClientSecret => "h8yI4DydzI5ZsKCMGTs9hfTdI1vRS3qfTo9Go92q3aM=";

     
    }
}
