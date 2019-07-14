using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.UploadService.Mapper
{
    public static class UploadMapper
    {
        public static TamTech.Monshaat.POS.UploadService.Models.UploadFileModel MapUploadFileModel(this TamTech.Monshaat.POS.Web.Services.Upload.Models.UploadFileInfo common)
        {
            return new TamTech.Monshaat.POS.UploadService.Models.UploadFileModel
            {

                FileNamePrefix = common.FileNamePrefix,
                Type = common.type,
                Stream = common.Stream,
                FileName = common.FileName,
                ContentType = common.ContentType
            };
        }


        public static TamTech.Monshaat.POS.UploadService.Models.UploadModel MapUploadModel(this TamTech.Monshaat.POS.Web.Services.Upload.Models.UploadModel common)
        {
            var ret = new TamTech.Monshaat.POS.UploadService.Models.UploadModel
            {
                UploadFiles = common.UploadFile.Select(f => f.MapUploadFileModel()).ToList()
            };
            return ret;
        }




        public static TamTech.Monshaat.POS.UploadService.Models.UploadedFileResult MapUploadedFileURL(this TamTech.Monshaat.POS.Web.Services.Upload.Models.UploadedFileURL common)
        {
            return new TamTech.Monshaat.POS.UploadService.Models.UploadedFileResult
            {
                UploadedDate = common.UploadedDate,
                URL = common.URL
            };
        }



        public static TamTech.Monshaat.POS.UploadService.Models.UploadModelResult MapUploadModelResult(this TamTech.Monshaat.POS.Web.Services.Upload.Models.UploadModelResult common)
        {
            return new TamTech.Monshaat.POS.UploadService.Models.UploadModelResult
            {
                UploadTransactionId = common.UploadPatchId,
                URLs = common.URLs.Select(u => u.MapUploadedFileURL()).ToList()
            };
        }



        public static TamTech.Monshaat.POS.Web.Services.Upload.Models.UploadedFileURL MapUploadedFileURL(this TamTech.Monshaat.POS.UploadService.Models.UploadedFileResult nuget)
        {
            return new TamTech.Monshaat.POS.Web.Services.Upload.Models.UploadedFileURL
            {
                Type = nuget.Type,
                UploadedDate = nuget.UploadedDate,
                URL = nuget.URL,
                Success = nuget.URL.Length > 0
            };
        }



        public static TamTech.Monshaat.POS.Web.Services.Upload.Models.UploadModelResult MapUploadModelResult(this TamTech.Monshaat.POS.UploadService.Models.UploadModelResult nuget)
        {
            return new TamTech.Monshaat.POS.Web.Services.Upload.Models.UploadModelResult
            {
                UploadPatchId = nuget.UploadTransactionId,
                URLs = nuget.URLs.Select(u => u.MapUploadedFileURL()).ToList()
            };
        }



    }
}
