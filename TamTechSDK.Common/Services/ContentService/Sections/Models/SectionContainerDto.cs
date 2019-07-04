using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Models.Languages;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Services.ContentService.Posts.Models;

namespace TamTechSDK.Common.Services.ContentService.Sections.Models
{
   public  class SectionContainerDto
    {
        public SectionDto SectionInfo { get; set; }  

        public List<SectionDto> Sections { get; set; }  

        public List<PostDto> Posts { get; set; } 

        public PaginationMetadataModel Pagination { get; set; } 

        public List<SlugModel> SectionsSlugs { get; set; } 
    }
}
