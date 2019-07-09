
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.Upload.Models
{
    public class UploadFileModel
    { 
        public object Id { get; set; }

        [Required]
        public FileTypesEnum Type { get; set; }

        [Required]
        public UploadFileInfo FileInfo  { get; set; }


        public string ContentType { get; set; }
    }

   

}
