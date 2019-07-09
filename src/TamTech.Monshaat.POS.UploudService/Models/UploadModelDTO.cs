using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTech.Monshaat.POS.UploadService.Models
{
    public class UploadDTO
    {
        public List<UploadFileDTO> UploadFiles { get; set; }

        public UploadModel ToUploadModel()
        {
            var UploadModel = new UploadModel()
            {
                UploadFiles = new List<UploadFileModel>()
            };
            foreach (var i in UploadFiles)
            {
                UploadFileModel UploadFileModel = new UploadFileModel();
                UploadFileModel.Type = i.Type ?? i.Type;
                UploadFileModel.FileNamePrefix = i.FileNamePrefix ?? i.FileNamePrefix;
                UploadFileModel.Stream = i.FileBinary.OpenReadStream();
                UploadFileModel.FileName = i.FileBinary.FileName ?? i.FileBinary.FileName;
                UploadModel.UploadFiles.Add(UploadFileModel);
            }
            return UploadModel;
        }
    }
    //[FluentValidation.Attributes.Validator(typeof(UploadModelValidator))]
    public class UploadFileDTO
    {
        [Required]
        public IFormFile FileBinary { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        public string FileNamePrefix { get; set; }
    }
}
