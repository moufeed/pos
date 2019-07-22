using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.SDK.Models.VMs.Shared.Biography
{
    public class BiographyVM
    {

        public string LogoUrl { get; set; }

        public string SiteName { get; set; }

        public string Brief { get; set; }

        public KeyValuePair<string, string> Position { get; set; }   // Longitude , Latitude

        public string Address { get; set; }

        public List<string> Keywords { get; set; }

        public List<string> PhoneNumbers { get; set; }

        public List<string> MobileNumbers { get; set; }

        public Dictionary<string, string> Emails { get; set; }

        public Dictionary<string, string> SocialMedia { get; set; }

    }
}
