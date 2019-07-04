
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace TamTechSDK.Common.Services.Upload.Models
{
    public class UploadFileModel
    { 
        public object Id { get; set; }

        [Required]
        public FileTypesEnum Type { get; set; }

        [Required]
        public UploadFileInfo FileInfo  { get; set; } 
    }

   

}
