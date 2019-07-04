using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.Upload.Settings
{
   public class UploadBackendSettings : IUploadBackendSettings
    {
        private string _uploadServiceUrl;


        public UploadBackendSettings(string uploadServiceUrl)
        {
            _uploadServiceUrl = uploadServiceUrl;
        }

        public string UploadEndpointBase => _uploadServiceUrl;//  "http://localhost:62881/api/v0.1"; "http://localhost:53629/api/v0.1"; //

        public string UploadFilesEndPoint => $"{UploadEndpointBase}/upload";


        public string DeleteFilesEndPoint => $"{UploadEndpointBase}/manage/deletefiles";

    }
}
