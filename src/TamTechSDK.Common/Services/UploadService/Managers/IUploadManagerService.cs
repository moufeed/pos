using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.Upload.FileTypes;
using TamTechSDK.Common.Services.Upload.Models;
using TamTechSDK.Common.Services.Upload.Settings;

namespace TamTechSDK.Common.Services.Upload
{
    public interface IUploadManagerService 
    {
        Task<UploadModelResult> UploadListFilesAsync(List<UploadFileModel> files);

        Task<UploadedFileURL> UploadFileAsync(UploadFileInfo file, FileTypesEnum type, object id =  null);

        Task<IRequestProviderResult<DeleteFilesModelResult>> DeleteFilesAsync(Dictionary<string, FileTypesEnum> urlImgs);

        Task<IRequestProviderResult<DeleteFilesModelResult>> DeleteFilesAsync(DeleteFilesInputModel model);
    }
}
