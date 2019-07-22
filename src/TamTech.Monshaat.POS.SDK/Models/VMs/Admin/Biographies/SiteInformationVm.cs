using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.SDK.Models.VMs.Admin.Biographies
{
    public class SiteInformationVm
    {
        public string SiteTitle { get; set; }
        public string Logo { get; set; }

        public IFormFile NewLogo { get; set; }

        public Dictionary<string, string> Images { get; set; }

        public Dictionary<string, IFormFile> NewImages { get; set; }

        public List<string> Phones { get; set; }

        public List<string> Moblies { get; set; }

        public List<string> Faxs { get; set; }

        public List<string> Emails { get; set; }

        public Dictionary<string, string> SocailMedia { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public string Brief { get; set; }

        public string About { get; set; }

        public string Vision { get; set; }

        public string Mission { get; set; }

        public string Summury { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeywords { get; set; }

        public string Address { get; set; }

    }
}
