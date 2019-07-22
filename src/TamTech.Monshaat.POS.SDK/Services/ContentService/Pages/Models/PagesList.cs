using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Pagination;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Pages.Models
{
    public class PagesList
    {
        public List<PageDto> Data { get; set; }
        public PaginationMetadataModel Pagination { get; set; }
    }
}
