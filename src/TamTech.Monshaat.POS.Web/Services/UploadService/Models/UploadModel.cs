
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.Upload.Models
{
    public class UploadModel
    {
        public List<UploadFileInfo> UploadFile { get; set; }
    }

    public class UploadFileInfo
    {
        [Required]
        public Stream Stream { get; set; }
        public string FileNamePrefix { get; set; }
        [Required]
        public string type { get; set; }
        public string FileName { get; set; }

    }

}
