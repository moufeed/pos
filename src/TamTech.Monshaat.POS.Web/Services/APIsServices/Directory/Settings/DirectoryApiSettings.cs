using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Services.APIsServices.Directory.Settings
{
    public class DirectoryApiSettings : BaseAPISettings, IDirectoryApiSettings
    {
        public DirectoryApiSettings(string controller) : base(controller)
        {
        }

        public string GetPublishedBySlugEndPoint => $"{_PortlPath}/GetPublishedBySlugAsync";

        public string FindEndPoint =>  $"{_PortlPath}/FindAsync";

        public string GetCountOfPublishedEndPoint =>  $"{_PortlPath}/GetCountOfPublishedAsync";
    }
}
