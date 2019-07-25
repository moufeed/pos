using TamTech.Monshaat.POS.Web.SDK.Models.Shared;

namespace TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Directory.Settings
{
    public class DirectoryApiSettings : BaseAPISettings, IDirectoryApiSettings
    {
        public DirectoryApiSettings(BackendApiSettings settings, string controller) : base(settings, controller)
        {
        }

        public string GetPublishedBySlugEndPoint => $"{_PortlPath}/GetPublishedBySlugAsync";

        public string FindEndPoint =>  $"{_PortlPath}/FindAsync";

        public string GetCountOfPublishedEndPoint =>  $"{_PortlPath}/GetCountOfPublishedAsync";

        public string GetAllPublishedSlugsEndPoint => $"{_PortlPath}/GetAllPublishedSlugsAsync";
    }
}
