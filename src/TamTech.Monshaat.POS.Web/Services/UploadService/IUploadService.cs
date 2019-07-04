using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.Upload.Models;

namespace TamTechSDK.Common.Services.Upload
{
    public interface IUploadService
    {
        Task<IRequestProviderResult<UploadModelResult>> UploadsFilesAsync(UploadModel Files );

        Task<IRequestProviderResult<DeleteFilesModelResult>> DeleteFilesAsync(DeleteFilesInputModel model);

    }
}
