using System;
using System.Collections.Generic;
using System.Text;
using System.IO; 
using System.Threading.Tasks;
using TamTech.Monshaat.POS.UploadService.Models;
using TamTech.Monshaat.POS.UploadService.Configurations;
using TamTech.Monshaat.POS.UploadService.Settings;
using Microsoft.AspNetCore.Http;

namespace TamTech.Monshaat.POS.UploadService.Helpers
{
   public  class FileUtilities
    {
        //#region props  
        //private readonly IUploadSettingsConfigurations _appSettings; 
        //#endregion

        //#region Ctors 
        //public FileUtilities(IUploadSettingsConfigurations appSettings)
        //{
        //    _appSettings = appSettings; 
        //}
        //#endregion

        public async Task<UploadModel> GenerateModelAsync(string prefix, string type, List<IFormFile > files, int imageOption)
        {
            UploadModel uploudModel = new UploadModel
            {
                UploadFiles = new List<UploadFileModel>(),
            };
          //  FileTypeSettings settings =  _appSettings.GetFileTypeSettings()[0];
            foreach (var file in files)
            {
                MemoryStream stream = new MemoryStream();
                await file.CopyToAsync(stream);
                stream.Position = 0;
                var model = new UploadFileModel
                {
                    Type = type,
                    FileNamePrefix = prefix,
                    Stream = stream,
                    FileName = file.FileName,
                    ImageOption = imageOption,
                };
                uploudModel.UploadFiles.Add(model);
            }
            return uploudModel;
        }
    }
}
