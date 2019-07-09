using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http; 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TamTechBackendSDK.Common.Services.ApplicationInsightsTelemetry;
using TamTech.Monshaat.POS.UploadService.Helpers;
using TamTech.Monshaat.POS.UploadService.Models;
using TamTech.Monshaat.POS.UploadService.Configurations;
using TamTech.Monshaat.POS.UploadService.Settings;
using TamTech.Monshaat.POS.UploadService.Validators;
using FluentValidation;

namespace TamTech.Monshaat.POS.UploadService.Services
{
    public class UploadToLocal : BaseService, IUploadService
    {
        #region props
        private readonly IUploadSettingsConfigurations _appSettings;
        private ITelemetryClientService _telemetryClientService; 
        private string innerUploadFolderPath;//without domain 
        private string hostName; //domain name without http://  
        private string environmentPath;
        private string UploadServiceAppSettingSectionName;
        private string UploadSettingsSectionName;
        #endregion 


        #region Ctor 
        public UploadToLocal
            (IUploadSettingsConfigurations appSettings, ITelemetryClientService telemetry, IHostingEnvironment hostingEnvironment)
        {
            _appSettings = appSettings;
            _telemetryClientService = telemetry; 
            environmentPath = hostingEnvironment.WebRootPath; 
        } 

        #endregion
        public async Task<IResultModel<DeleteFilesModelResult>> DeleteAsync(DeleteFilesInputModel deleteFilesInput)
        {
            var result = new DeleteFilesModelResult
            {
                Results = deleteFilesInput.DeleteFiles.Select(d => new DeleteFileResult
                {
                    Type = d.Type,
                    FileName = d.FileName,
                    Result = DeleteResultEnum.NotDeleted
                }).ToList()
            };
            foreach (var file in result.Results)
            {
                var standardizedPath = file.FileName;
                if (standardizedPath.StartsWith("https://"))
                    standardizedPath = standardizedPath.Substring(8);
                else if (standardizedPath.StartsWith("http://"))
                    standardizedPath = standardizedPath.Substring(7);
                if (!standardizedPath.StartsWith("www."))
                    standardizedPath = "www." + standardizedPath;
                //ie: www.blabla.com/blabla/blabla/blabla/blabla

                var localPath = new Uri("http://" + standardizedPath).LocalPath;
                //ie: /blabla/blabla/blabla

                //check path
                if (!standardizedPath.StartsWith(hostName) || !localPath.StartsWith(innerUploadFolderPath.Replace("\\", "/"))/*does it start with upload folder?*/)
                {
                    file.Result = DeleteResultEnum.NotExist;
                    continue;
                }
                string filePath = environmentPath + localPath;
                if (!File.Exists(filePath))
                {
                    file.Result = DeleteResultEnum.NotExist;
                    continue;
                }
                try
                {
                    File.Delete(filePath);
                    file.Result = DeleteResultEnum.Deleted;
                }
                catch (Exception exc)
                {
                    _telemetryClientService.TrackException(exc, new Dictionary<string, string>
                        {
                            {"FilePath",filePath },
                            {"Type",file.Type }
                        });
                    file.Result = DeleteResultEnum.NotDeleted;
                }
            }
            return ReturnProcessResult (true , result);
        }



        public async Task<IResultModel<UploadModelResult>> UploadAsync(UploadModel uploadModel)
        {

            var stypeSettings = _appSettings.GetFileTypeSettings();
           
            var  validation = new UploadModelValidator(stypeSettings).Validate(uploadModel );
            if (!validation.IsValid  )
            {
                return ReturnFailure<UploadModelResult>(validation);
            }
            innerUploadFolderPath = "\\" + _appSettings.GetUploadPath();
            hostName = _appSettings.GetDomainName();
            //ie: hostName = www.blabla.com

            var uploadResult = new UploadModelResult
            {
                UploadTransactionId = Guid.NewGuid().ToString(),
                URLs = new List<UploadedFileResult>()
            };

            foreach (var uploadedFile in uploadModel.UploadFiles)
            {
                if (uploadedFile.Stream.Length > 0)
                {
                    FileTypeSettings[] settings = _appSettings.GetFileTypeSettings();
                    var uploadedFileSettings = settings.FirstOrDefault(x => x.Type == uploadedFile.Type);

                    if (uploadedFileSettings == null)
                    {
                        break;
                    }

                    string folderPath = environmentPath + innerUploadFolderPath + "\\" + uploadedFile.Type + "\\";
                    string localPath = innerUploadFolderPath + "\\" + uploadedFile.Type + "\\";

                    bool exists = System.IO.Directory.Exists(folderPath);

                    if (!exists)
                        System.IO.Directory.CreateDirectory(folderPath);


                    var fileName = new FileHelper().GenerateFileName(uploadedFileSettings.FileNamePrefix, uploadedFile.FileNamePrefix, uploadResult.UploadTransactionId, uploadedFile.GetExtension());

                    var filePath = folderPath + fileName;

                    using (var stream = uploadedFile.Stream)
                    {
                        //saving

                        var temp = filePath;
                        using (var fileStream = new FileStream(temp, FileMode.Create))
                            await stream.CopyToAsync(fileStream);
                    }


                    uploadResult.URLs.Add(new UploadedFileResult
                    {
                        URL = (hostName + localPath + fileName).Replace("\\", "/"),
                        Type = uploadedFile.Type,
                        UploadedDate = DateTime.UtcNow
                    });
                }
            }
            //dispose?
       //     return uploadResult;
            return ReturnProcessResult(true, uploadResult);
        }

       

        public Task<IResultModel<UploadModelResult>> UploadAsync(string prefix, string type, List<IFormFile> files, int ImageOption = 1)
        {
            throw new NotImplementedException();
        }
    }
}
