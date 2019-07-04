using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.ContentService
{
    public class ContentsServiceSettings : IContentsServiceSettings
    {
        private string _contentsServiceUrl;


        public ContentsServiceSettings(string contentsServiceUrl)
        {
            _contentsServiceUrl = contentsServiceUrl;
        }


        public string ContentsServiceEndpointBase => _contentsServiceUrl;

        public string ClientId => "whatcookapp";

        public string ClientSecret => "h8yI4DydzI5ZsKCMGTs9hfTdI1vRS3qfTo9Go92q3aM=";

     
    }
}
