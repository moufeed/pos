using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.UploadService.Constants
{
    public class AppSettingsConstants
    {  
  
        public const string FilesTypesSettings = "DirectBackendSDKsSettings:DirectBackendSDK_UploadService_Config:FilesTypesSettings";

        public const string WebApplicationSettings = "DirectBackendSDKsSettings:DirectBackendSDK_UploadService_Config:WebApplicationSettings"; 
       
        public const string UploadPath = "UploadPath"; 

        public const string DomainName = "DomainName"; 
      
        public const string ThumbnailSettings = "DirectBackendSDKsSettings:DirectBackendSDK_UploadService_Config:ThumbnailSettings";


        #region
        /* *******/
        public const string UseMockServicesFlag = "DirectBackendSDKsSettings:DirectBackendSDK_UploadService_Config:UseMockServicesFlag";

        /* *******/
        public const string IdentityServiceSettings = "UploadService_Config:IdentityServiceSettings";

        /* *******/
        public const string AzureBlobStorageSettings = "DirectBackendSDKsSettings:DirectBackendSDK_UploadService_Config:AzureBlobStorageSettings";

        /* *******/
        public const string ServiceBusSettings = "DirectBackendSDKsSettings:DirectBackendSDK_UploadService_Config:ServiceBusSettings";

        /* *******/
        public const string ApplicationInsightsSettings = "DirectBackendSDKsSettings:DirectBackendSDK_UploadService_Config:ApplicationInsightsSettings";

        /* *******/
        public const string SeparateContainers = "DirectBackendSDKsSettings:DirectBackendSDK_UploadService_Config:SeparateContainers";

        #endregion

    }
}
