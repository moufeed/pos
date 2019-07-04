using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Models.Pagination;

namespace TamTechSDK.Common.Services.ContentService.Pages.Models
{
    public class PagesList
    {
        public List<PageDto> Data { get; set; }
        public PaginationMetadataModel Pagination { get; set; }
    }
}
