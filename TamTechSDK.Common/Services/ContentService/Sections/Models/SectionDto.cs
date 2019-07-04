using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Services.ContentService.Models;
using TamTechSDK.Common.Services.ContentService.Posts.Models;

namespace TamTechSDK.Common.Services.ContentService.Sections.Models
{
    public class SectionDto : ContentItem
    {
        public Guid? ParentId { get; set; }

        public string ParentName { get; set;}

        public string SlugHierarchy { get; set; }

     //   public ICollection<PostDto> Posts { get; set;}
    }
}
