using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.UploadService.Enums;

namespace TamTech.Monshaat.POS.UploadService.Models
{

    public class UploadModel
    {
        public List<UploadFileModel> UploadFiles { get; set; }

    }
    //[FluentValidation.Attributes.Validator(typeof(UploadModelValidator))]
    public class UploadFileModel
    {
        [Required]
        public Stream Stream { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        public string FileNamePrefix { get; set; }
        public string FileName { get; set; }
        public string GetExtension()
        {

            return Path.GetExtension(FileName);
        }

        public int ImageOption { get; set; } = (int)UploadImageOptionEnum.none;
        
    }

    //public class UploadFormFile : IFormFile
    //{

    //}
}
