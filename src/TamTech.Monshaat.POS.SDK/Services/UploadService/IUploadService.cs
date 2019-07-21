using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.Upload.Models;

namespace TamTech.Monshaat.POS.Web.SDK.Services.Upload
{
    public interface IUploadService
    {
        Task<IRequestProviderResult<UploadModelResult>> UploadsFilesAsync(UploadModel Files );

        Task<IRequestProviderResult<DeleteFilesModelResult>> DeleteFilesAsync(DeleteFilesInputModel model);

    }
}
