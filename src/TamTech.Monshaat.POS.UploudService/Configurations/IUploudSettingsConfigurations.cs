
using TamTech.Monshaat.POS.UploadService.Settings;

namespace TamTech.Monshaat.POS.UploadService.Configurations
{
    public interface IUploadSettingsConfigurations
    {
        FileTypeSettings[] GetFileTypeSettings();

        string GetUploadPath();

        string GetDomainName();    

        ThumbnailSettings GetThumbnailSettings();
    }
}
