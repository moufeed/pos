using System.Collections.Generic;
using System.Linq;
using TamTechSDK.Common.Services.ContentService.Products.Models;
using TamTechSDK.Common.Services.Upload.Models;

namespace TamTechSDK.Web.Extensions.AutoMapper
{
    public static class ProductImageMapper
    {
        public static DeleteFilesInputModel MapToDeleteFilesInputModel(this ProductImagesModel model, string fileType)
        {
            return new DeleteFilesInputModel
            {
                DeletedFiles = model.images != null ? model.images.Select(img => img.MapToDeleteFileInputModel(fileType)).ToList() : new List<DeleteFileInputModel>()
            };
        }

        public static DeleteFileInputModel MapToDeleteFileInputModel(this string filePath, string fileType)
        {
            return new DeleteFileInputModel
            {
                FilePath = filePath,
                Type = fileType
            };
        }


    }
}
