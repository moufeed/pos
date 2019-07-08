using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.UploadService.Models
{
    public class UploadedFileResult
    {
        public string URL { get; set; }

        public string Name { get; set; }

        public string ThumbnailName { get; set; }

        public string ThumbnailPrefix { get; set; }

        public string Type { get; set; }

        public DateTime UploadedDate { get; set; }
    }
}
