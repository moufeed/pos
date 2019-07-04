using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.Upload.Models
{
    public class UploadModelResult
    {
        public List<UploadedFileURL> URLs { get; set; } = new List<UploadedFileURL>();

        public string UploadPatchId { get; set; }
    }

    public class UploadedFileURL
    {
        public bool Success { get; set; }

        public string URL { get; set; }

        public string Type { get; set; }

        public string TypeEnum { get; set; }

        public DateTime UploadedDate { get; set; }
    }
}
