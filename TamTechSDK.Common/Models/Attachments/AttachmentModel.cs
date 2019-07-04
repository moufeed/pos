using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Models.Attachments
{
    public class AttachmentModel
    {
        public string Name { get; set; }

        public string FullUrl { get; set; }

        public string Path { get; set; }

        public string Extension { get; set; }

        public string Thumbnail { get; set; }

        public string GenericField { get; set; }
    }
}
