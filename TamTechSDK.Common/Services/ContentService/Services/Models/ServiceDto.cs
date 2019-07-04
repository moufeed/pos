using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Services.ContentService.Models;

namespace TamTechSDK.Common.Services.ContentService.Services.Models
{
    public class ServiceDto : ContentItem
    {
        public string Content { get; set; }

        public string Icon { get; set; }

        public bool IconVisibility { get; set; }

        public string OthersSlug { get; set; }

    }
}
