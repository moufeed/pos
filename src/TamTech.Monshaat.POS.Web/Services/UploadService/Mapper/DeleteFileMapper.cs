using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.UploadService.Mapper
{
    public static class DeleteFileMapper
    {

        public static TamTech.Monshaat.POS.UploadService.Models.DeleteFileInputModel MapDeleteFileInputModel(this TamTech.Monshaat.POS.Web.SDK.Services.Upload.Models.DeleteFileInputModel common)
        {
            return new TamTech.Monshaat.POS.UploadService.Models.DeleteFileInputModel
            {
                FileName = common.FilePath,
                Type = common.Type
            };
        }

        public static TamTech.Monshaat.POS.UploadService.Models.DeleteFilesInputModel MapDeleteFilesInputModel(this TamTech.Monshaat.POS.Web.SDK.Services.Upload.Models.DeleteFilesInputModel common)
        {
            return new TamTech.Monshaat.POS.UploadService.Models.DeleteFilesInputModel
            {
                DeleteFiles = common.DeletedFiles.Select(f => f.MapDeleteFileInputModel()).ToList()
            };
        }



        public static TamTech.Monshaat.POS.Web.SDK.Services.Upload.Models.DeleteFileResult MapDeleteFileResult(this TamTech.Monshaat.POS.UploadService.Models.DeleteFileResult nuget)
        {
            return new TamTech.Monshaat.POS.Web.SDK.Services.Upload.Models.DeleteFileResult
            {
                FilePath = nuget.FileName,
                Result = switchEnum((int)nuget.Result),
                Type = nuget.Type
            };
        }

        public static TamTech.Monshaat.POS.Web.SDK.Services.Upload.Models.DeleteFilesModelResult MapDeleteFilesModelResult(this TamTech.Monshaat.POS.UploadService.Models.DeleteFilesModelResult nuget)
        {
            return new TamTech.Monshaat.POS.Web.SDK.Services.Upload.Models.DeleteFilesModelResult
            {

                Results = nuget.Results.Select(d => d.MapDeleteFileResult()).ToList()
            };
        }





        public static TamTech.Monshaat.POS.Web.SDK.Services.Upload.Models.DeleteResult switchEnum(int p1)
        {
            switch (p1)
            {
                case 1:
                    return TamTech.Monshaat.POS.Web.SDK.Services.Upload.Models.DeleteResult.Deleted;

                case 2:
                    return TamTech.Monshaat.POS.Web.SDK.Services.Upload.Models.DeleteResult.NotExist;

                case 0:
                    return TamTech.Monshaat.POS.Web.SDK.Services.Upload.Models.DeleteResult.NotDeleted;
                default:
                    return TamTech.Monshaat.POS.Web.SDK.Services.Upload.Models.DeleteResult.NotDeleted;
            }

        }


    }
}
