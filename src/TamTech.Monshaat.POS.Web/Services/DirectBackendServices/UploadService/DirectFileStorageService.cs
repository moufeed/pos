using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.DirectBackendServices.UploadService.Mapper;
using TamTech.Monshaat.POS.Web.Services.Upload.Models;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.UploadService
{
    public class DirectFileStorageService : TamTech.Monshaat.POS.Web.Services.Upload.IUploadService
    {
        #region Props  
        private readonly TamTech.Monshaat.POS.UploadService.Services.IUploadService _fileStorageService;
        #endregion


        #region Ctors
        public DirectFileStorageService(TamTech.Monshaat.POS.UploadService.Services.IUploadService fileStorageService)
        {
            _fileStorageService = fileStorageService;
        }
        #endregion


        #region Services  
        public async Task<IRequestProviderResult<UploadModelResult>> UploadsFilesAsync(UploadModel mediafiles)
        {
            IRequestProviderResult<UploadModelResult> _result = new RequestProviderResult<UploadModelResult>();
            var v = mediafiles.MapUploadModel();
            var resultUpload = await _fileStorageService.UploadAsync(v);
            _result.Data = resultUpload.MapUploadModelResult();
            _result.Success = true;

            return _result;
        }




        public async Task<IRequestProviderResult<DeleteFilesModelResult>> DeleteFilesAsync(DeleteFilesInputModel model)
        {
            IRequestProviderResult<DeleteFilesModelResult> _result = new RequestProviderResult<DeleteFilesModelResult>();


            var resultDeleteFiles = await _fileStorageService.DeleteAsync(model.MapDeleteFilesInputModel());
            _result.Data = resultDeleteFiles.MapDeleteFilesModelResult();
            _result.Success = true;
            return _result;
        }
        #endregion
    }
}
