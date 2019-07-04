using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Services.ContentService.Models;

namespace TamTechSDK.Common.Services.ContentService.Posts.Models
{
    public class PostDto : ContentItem
    {
        public string Content { get; set; }

        public Guid? SectionId { get; set; }

        public string SectionSlug { get; set; }

        public int ViewsCount { get; set; }

        public DateTime? PostDate { get; set; }
        

}
}
