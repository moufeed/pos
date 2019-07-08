using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.CasAuctions.TamTech.Monshaat.POS.UploadService.Models
{
    public class DeleteFilesModelResult
    {
        public List<DeleteFileResult>   Results { get; set; }
    }

    public class DeleteFileResult
    {
        public string Type { get; set; }

        public string FileName { get; set; }

        public DeleteResultEnum Result { get; set; }
    }

    public enum DeleteResultEnum
    {
        NotDeleted = 0,
        Deleted = 1,
        NotExist = 2
    }
}
