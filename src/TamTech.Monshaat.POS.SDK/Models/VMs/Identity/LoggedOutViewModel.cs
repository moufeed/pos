using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.SDK.Models.VMs.Identity
{
    public class LoggedOutViewModel
    {
        public string PostLogoutRedirectUri
        {
            get;
            set;
        }

        public string ClientName
        {
            get;
            set;
        }

        public string SignOutIframeUrl
        {
            get;
            set;
        }

        public bool AutomaticRedirectAfterSignOut
        {
            get;
            set;
        }

        public string LogoutId
        {
            get;
            set;
        }

        public bool TriggerExternalSignout => ExternalAuthenticationScheme != null;

        public string ExternalAuthenticationScheme
        {
            get;
            set;
        }
    }
}
