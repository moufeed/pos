using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.DirectBackendServices.UploadService.Mapper;
using TamTech.Monshaat.POS.Web.SDK.Services.Upload.Models;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.UploadService
{
    public class DirectFileStorageService :  TamTech.Monshaat.POS.Web.SDK.Services.Upload.IUploadService
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

             var v = mediafiles.MapUploadModel();
            var resultUpload = await _fileStorageService.UploadAsync(v);
            var data = resultUpload.Data?.MapUploadModelResult();    
            return MapRequestProviderResult(resultUpload, data);    
        }




        public async Task<IRequestProviderResult<DeleteFilesModelResult>> DeleteFilesAsync(DeleteFilesInputModel model)
        {   
            var resultDeleteFiles = await _fileStorageService.DeleteAsync(model.MapDeleteFilesInputModel());  
            var data = resultDeleteFiles.Data?.MapDeleteFilesModelResult();
            return MapRequestProviderResult(resultDeleteFiles, data);
             
        }
        #endregion



        public IRequestProviderResult<TOutputResult> MapRequestProviderResult<TOutputResult, TInputResult>(
           TamTech.Monshaat.POS.UploadService.Models.IResultModel<TInputResult> inputResult, TOutputResult data)
        {
            IRequestProviderResult<TOutputResult> _resultModel = new RequestProviderResult<TOutputResult>();
            _resultModel.Messages = inputResult.Messages;    
            _resultModel.Success = inputResult.Success;
            _resultModel.StatusCode = (System.Net.HttpStatusCode)((int)inputResult.StatusCode);
            _resultModel.Data = data;
            return _resultModel;
        }


    //    public IRequestProviderResult<TResult> MapRequestProviderResult<TResult>(
    //TamTech.Monshaat.POS.UploadService.Models.IResultModel<TResult> inputResult
    //)
    //    {

    //        IRequestProviderResult<TResult> _resultModel = new RequestProviderResult<TResult>()
    //        {
    //            Success = inputResult.Success,
    //            Header = inputResult.HeaderParams,
    //            Data = inputResult.Data,
    //            Messages = inputResult.Success ? null : new Dictionary<string, List<string>>(),
    //            StatusCode = MapToHttpStatusCode(inputResult.StatusCode)
    //        };

    //        if (!inputResult.Success)
    //        {
    //            foreach (KeyValuePair<string, List<string>> error in inputResult.Messages)
    //            {
    //                List<string> errorMessages = new List<string>();

    //                if (error.Value.Count > 0)
    //                {
    //                    foreach (var value in error.Value)
    //                    {
    //                        errorMessages.Add(value);
    //                    }
    //                    _resultModel.Messages.Add(error.Key, errorMessages);
    //                }
    //            }
    //        }

    //        return _resultModel;
    //    }
    }
}
