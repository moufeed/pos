using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Models.Languages;
using TamTechSDK.Common.Services.ContentService.Request.Models;

namespace TamTechSDK.Common.Models.Pagination
{
    public class PagedResultModel<TCollection>
    {
        public TCollection Data { get; set; }

        public PaginationMetadataModel Pagination { get; set; }

        public List<SlugModel> SectionsSlugs { get; set; }
    }
}
