using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.Upload.Models
{
    public class DeleteFilesModelResult
    {
        public List<DeleteFileResult> Results { get; set; }
    }

    public class DeleteFileResult
    {
        public string Type { get; set; }

        public string FilePath { get; set; }

        public DeleteResult Result { get; set; }
    }

    public enum DeleteResult
    {
        NotDeleted = 0,
        Deleted = 1,
        NotExist = 2
    }
}
