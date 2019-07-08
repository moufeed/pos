using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.UploadService.Models
{
    public class UploadServiceInfoModel
    {
        public List<string> Types { get; set; }

        public List<string> AbsoluteUris { get; set; }

        public string Uri { get; set; } 

    }
}
