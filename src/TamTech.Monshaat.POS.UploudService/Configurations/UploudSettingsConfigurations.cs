using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using TamTech.Monshaat.POS.UploadService.Constants;
using TamTech.Monshaat.POS.UploadService.Settings;

namespace TamTech.Monshaat.POS.UploadService.Configurations
{
    public class UploadSettingsConfigurations : IUploadSettingsConfigurations
    {

        #region Props 
        private readonly IConfiguration _configuration;
        private readonly string _filesTypesSettings;
        private readonly string _webApplicationSettings;
        private readonly string _azureBlobStorageSettings;
        private readonly string _uploadPath;
        private readonly string _domainName;
        private readonly string _separateContainers;
        private readonly string _thumbnailSettings;
        #endregion

        #region Ctors 
        public UploadSettingsConfigurations(IConfiguration configuration,
                                                string FilesTypesSettings = AppSettingsConstants.FilesTypesSettings,
                                                string WebApplicationSettings = AppSettingsConstants.WebApplicationSettings,
                                                string AzureBlobStorageSettings = AppSettingsConstants.AzureBlobStorageSettings,
                                                string uploadPath = AppSettingsConstants.UploadPath,
                                                string domainName = AppSettingsConstants.DomainName,
                                                string separateContainers = AppSettingsConstants.SeparateContainers,
                                                string thumbnailSettings = AppSettingsConstants.ThumbnailSettings
                                                )
        {

            _configuration = configuration;
            _filesTypesSettings = FilesTypesSettings;
            _webApplicationSettings = WebApplicationSettings;
            _azureBlobStorageSettings = AzureBlobStorageSettings;
            _uploadPath = uploadPath;
            _domainName = domainName;
            _separateContainers = separateContainers;
            _thumbnailSettings = thumbnailSettings;
        }
        #endregion

        public FileTypeSettings[] GetFileTypeSettings()
        {
            FileTypeSettings[] settings = _configuration.GetSection(_filesTypesSettings).Get<FileTypeSettings[]>();
            return settings;
        }



        public string GetUploadPath()
        {
            string uploadPath = _configuration.GetSection(_webApplicationSettings).GetValue<string>(_uploadPath);
            return uploadPath;
        }



        public string GetDomainName()
        {
            string domainName = _configuration.GetSection(_webApplicationSettings).GetValue<string>(_domainName);
            return domainName;
        }
         

        public AzureBlobStorageSettings GetAzureBlobStorageSettings()
        {
            AzureBlobStorageSettings settings = _configuration.GetSection(_azureBlobStorageSettings).Get<AzureBlobStorageSettings>();
            return settings;
        }


        public ThumbnailSettings GetThumbnailSettings()
        {
            ThumbnailSettings settings = _configuration.GetSection(_thumbnailSettings).Get<ThumbnailSettings>();
            return settings;
        }


    }
}
