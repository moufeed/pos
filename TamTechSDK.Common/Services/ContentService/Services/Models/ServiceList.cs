using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Models.Languages;
using TamTechSDK.Common.Models.Pagination;

namespace TamTechSDK.Common.Services.ContentService.Services.Models
{
    public class ServiceList
    {
        public List<ServiceDto> Data { get; set; }
        public PaginationMetadataModel Pagination { get; set; }
        public List<SlugModel> SectionsSlugs { get; set; }
    }
}
