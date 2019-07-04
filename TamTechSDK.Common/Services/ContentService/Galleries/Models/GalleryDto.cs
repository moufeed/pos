using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Services.ContentService.Models;

namespace TamTechSDK.Common.Services.ContentService.Galleries.Models
{
    public class GalleryDto : ContentItem
    {
        public List<GalleryItemDto> Items = new List<GalleryItemDto>();
 
    }
}
