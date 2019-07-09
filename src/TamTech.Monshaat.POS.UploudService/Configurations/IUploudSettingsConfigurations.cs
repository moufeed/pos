using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.UploadService.Settings;

namespace TamTech.Monshaat.POS.UploadService.Configurations
{
    public interface IUploadSettingsConfigurations
    {
        FileTypeSettings[] GetFileTypeSettings();

        string GetUploadPath();

        string GetDomainName();
          
        AzureBlobStorageSettings GetAzureBlobStorageSettings();

        ThumbnailSettings GetThumbnailSettings();
    }
}
