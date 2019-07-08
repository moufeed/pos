using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.UploadService.Models
{
    public class DeleteFilesInputModel
    {
        [Required]
        public List<DeleteFileInputModel> DeleteFiles { get; set; }
    }

    public class DeleteFileInputModel
    {
        [Required]
        public string Type { get; set; }

        [Required]
        public string FileName { get; set; }

    }
}
