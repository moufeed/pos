using System.Collections.Generic;

namespace TamTech.Monshaat.POS.UploadService.Models
{
    public class UploadModelResult
    {
        public List<UploadedFileResult> URLs { get; set; } = new List<UploadedFileResult>();

        public string UploadTransactionId { get; set; }
    }
}
