using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Services.ContentService.Models;

namespace TamTechSDK.Common.Services.ContentService.Galleries.Models
{
   public class GalleryItemDto : ContentItem
    {

        public int GalleryItemType { get; set; }

        public string VideoUrl { get; set; }

    }
}
