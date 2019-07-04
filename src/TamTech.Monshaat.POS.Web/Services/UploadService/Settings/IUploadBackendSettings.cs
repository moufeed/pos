using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.Upload.Settings
{
    public interface IUploadBackendSettings
    {

        string UploadEndpointBase { get; }
        string UploadFilesEndPoint { get; }
        string DeleteFilesEndPoint { get; }

    }
}
