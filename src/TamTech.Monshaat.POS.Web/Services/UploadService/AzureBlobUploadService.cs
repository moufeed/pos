using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.Upload.Models;
using TamTech.Monshaat.POS.Web.Services.Upload.Settings;

namespace TamTech.Monshaat.POS.Web.Services.Upload
{
    public class AzureBlobUploadService : IUploadService
    {
        #region Props 
        private readonly IRequestProvider _requestProvider;
        private readonly IUploadBackendSettings _backendSettings;
        #endregion


        #region Ctors
        public AzureBlobUploadService(IRequestProvider requestProvider  , IUploadBackendSettings backendSettings)
        {
            _requestProvider = requestProvider;
            _backendSettings = backendSettings;
        }
        #endregion


        #region Services  
        public async Task<IRequestProviderResult<UploadModelResult>> UploadsFilesAsync(UploadModel mediafiles)
        {

            

            var boundary = "-------uploadfile---" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss");

            var content = new MultipartFormDataContent(boundary);


            int index = 0;
            foreach (var file in mediafiles.UploadFile)
            {

                var length = (int)file.Stream.Length;

                byte[] bytes = new byte[length];

                await file.Stream.ReadAsync(bytes, 0, length);

                ByteArrayContent byteContent = new ByteArrayContent(bytes);

                byteContent.Headers.Add("Content-Type", "application/octet-stream");

                content.Add(byteContent, $"UploadedFiles[{index}].fileBinary", file.FileName);

                content.Add(new StringContent(file.type), $"UploadedFiles[{index}].Type");

                content.Add(new StringContent(file.FileNamePrefix), $"UploadedFiles[{index}].FileNamePrefix");
                index++;
            }

            var response = await _requestProvider.PostMultipartContent<UploadModelResult>(_backendSettings.UploadFilesEndPoint, content);

            return response;

        }



       
        public async Task<IRequestProviderResult<DeleteFilesModelResult>> DeleteFilesAsync(DeleteFilesInputModel model)
        {
            try
            {
                return await _requestProvider.PostAsync<DeleteFilesModelResult, DeleteFilesInputModel>(_backendSettings.DeleteFilesEndPoint, model);
            }
            catch(Exception ex)
            {
                return new RequestProviderResult<DeleteFilesModelResult>();
            }
       }
        #endregion

    }
}
