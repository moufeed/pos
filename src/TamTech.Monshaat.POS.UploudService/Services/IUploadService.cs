using System.Collections.Generic;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.UploadService.Models;
using TamTech.Monshaat.POS.UploadService.Enums;

namespace TamTech.Monshaat.POS.UploadService.Services
{
    public interface IUploadService
    { 
        Task<IResultModel<UploadModelResult>> UploadAsync(UploadModel uploadModel); 

        Task<IResultModel<UploadModelResult>> UploadAsync(string prefix, string type, List<Microsoft.AspNetCore.Http.IFormFile> files, int ImageOption =  (int)UploadImageOptionEnum.none);

        Task<IResultModel<DeleteFilesModelResult>> DeleteAsync(DeleteFilesInputModel deletedFiles); 
    }
}
