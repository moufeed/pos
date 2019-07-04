using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Models.Pagination;

namespace TamTechSDK.Common.Services.ContentService.Sections.Models
{
    public class SectionList
    {
        public List<SectionDto> Data { get; set; }
        public PaginationMetadataModel Pagination { get; set; }
    }
}
