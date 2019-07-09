using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.Upload.FileTypes;
using TamTech.Monshaat.POS.Web.Services.Upload.Models; 

namespace TamTech.Monshaat.POS.Web.Services.Upload
{
    public class UploadManagerService : IUploadManagerService
    {
        #region Props 
        private readonly List<FileTypesSettingsModel> _fileTypesSettings;
        private readonly IUploadService _uploadService;
        #endregion


        #region Ctors
        public UploadManagerService(List<FileTypesSettingsModel> fileTypesSettings, IUploadService uploadService)
        {
            _uploadService = uploadService;


            if (fileTypesSettings?.Count > 0)
            {
                // dynamic types of files from <<appSettings.json>>
                _fileTypesSettings = fileTypesSettings;
            }
            else
            {
                // static types of files 
                _fileTypesSettings = new List<FileTypesSettingsModel>
                {
                    new FileTypesSettingsModel { File = FileTypesEnum.General.ToString(), Type = "general" }, 
                    new FileTypesSettingsModel { File = FileTypesEnum.PageMainImage.ToString(), Type = "general" }, 
                    new FileTypesSettingsModel { File = FileTypesEnum.SliderItemMainImage.ToString(), Type = "general" },
                    new FileTypesSettingsModel { File = FileTypesEnum.SliderMainImage.ToString(), Type = "general" },
                    new FileTypesSettingsModel { File = FileTypesEnum.ContactUsFile.ToString(), Type = "contact-us" },
                    new FileTypesSettingsModel { File = FileTypesEnum.VendorFile.ToString(), Type = "vendor" },
                    new FileTypesSettingsModel { File = FileTypesEnum.POSImage.ToString(), Type = "pos" },
                    new FileTypesSettingsModel { File = FileTypesEnum.SectorIcon.ToString(), Type = "content" },
                    new FileTypesSettingsModel { File = FileTypesEnum.SectorMainImage.ToString(), Type = "content" },
                };
            }
        }
        #endregion
           public async Task<UploadModelResult> UploadListFilesAsync(List<UploadFileModel> files )
        {
            UploadModel uploadModel = new UploadModel { UploadFile = new List<UploadFileInfo>()};
            foreach (var uploadFile in files)
            {
                uploadFile.FileInfo.type = GetType(uploadFile.Type.ToString());
                uploadFile.FileInfo.FileNamePrefix = $"{uploadFile.Type}_{uploadFile.Id ?? ""}_";
                
                uploadModel.UploadFile.Add(uploadFile.FileInfo); 
                
            }

            IRequestProviderResult<UploadModelResult> uploadResult = await _uploadService.UploadsFilesAsync(uploadModel);

            if (uploadResult.Success)
            {
                for(int i=0; i< uploadResult.Data.URLs.Count; i++ )
                {
                    uploadResult.Data.URLs[i].TypeEnum = GetFileName(uploadResult.Data.URLs[i].Type);
                }
                return uploadResult.Data;
            }

            return null;

        }



        public async Task<UploadedFileURL> UploadFileAsync(UploadFileInfo file, FileTypesEnum type, object id)
        {
            file.type = GetType(type.ToString());
            file.FileNamePrefix = $"{type}_{id ?? ""}_";
            UploadModel UploadModel = new UploadModel
            {
                UploadFile = new List<UploadFileInfo> { file }
            };

            IRequestProviderResult<UploadModelResult> uploadResult = await _uploadService.UploadsFilesAsync(UploadModel);

            if (uploadResult.Success)
            {
                foreach (UploadedFileURL fileResult in uploadResult.Data.URLs)
                {
                  //  fileResult.Success = true;
                    return fileResult;
                }
            } 
            return null; 
        }



        public async Task<IRequestProviderResult<DeleteFilesModelResult>> DeleteFilesAsync(Dictionary<string, FileTypesEnum> urlImgs)
        {
            if (urlImgs?.Count > 0) return new RequestProviderResult<DeleteFilesModelResult>();
            DeleteFilesInputModel model = new DeleteFilesInputModel { DeletedFiles = new List<DeleteFileInputModel>() };
            foreach (var url in urlImgs)
            {
                model.DeletedFiles.Add(new DeleteFileInputModel
                {
                    FilePath = url.Key,
                    Type = GetType(url.Value.ToString()),
                });
            }

            return await _uploadService.DeleteFilesAsync(model);
        }
        public async Task<IRequestProviderResult<DeleteFilesModelResult>> DeleteFilesAsync(DeleteFilesInputModel model)
        {
            if (model?.DeletedFiles?.Count > 0) return new RequestProviderResult<DeleteFilesModelResult>();
            for (int i = 0; i < model.DeletedFiles.Count; i++)
            {
                model.DeletedFiles[i].Type = GetType(model.DeletedFiles[i].Type);
            }
            return await _uploadService.DeleteFilesAsync(model);
        }

        public string GetType(string fileName)
        {
            FileTypesSettingsModel model = _fileTypesSettings.FirstOrDefault(setting => setting.File.Equals(fileName, System.StringComparison.OrdinalIgnoreCase));
            if (model != null && model != default(FileTypesSettingsModel))
            {
                return model.Type;
            }
            else
            {
                FileTypesSettingsModel generalmodel = _fileTypesSettings.FirstOrDefault(setting => setting.File.Equals(FileTypesEnum.General.ToString(), System.StringComparison.OrdinalIgnoreCase));
                if (generalmodel != null && generalmodel != default(FileTypesSettingsModel))
                {
                    return model.Type;
                }
                else
                {
                    return "avatars";
                }
            }

        }

        public string GetFileName(string type)
        {
            string result = FileTypesEnum.General.ToString();
            FileTypesSettingsModel model = _fileTypesSettings.FirstOrDefault(setting => setting.Type.Equals(type, System.StringComparison.OrdinalIgnoreCase));
            if (model != null && model != default(FileTypesSettingsModel))
            {
                result = model.File;
            }
            return result;
        }

    }
    
    public enum FileTypesEnum
    {
        General, 
        PageMainImage, 
        SliderMainImage,
        SliderItemMainImage,  
        SectorIcon,
        SectorMainImage,
    ContactUsFile,
    VendorFile,
    POSImage,

    }
}
