using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.Models.Dtos.Slugs; 

namespace TamTech.Monshaat.POS.Web.Models.Dtos.Pagination
{
    public class PagedResultModel<TCollection>
    {
        public TCollection Data { get; set; }

        public PaginationMetadataModel Pagination { get; set; }

        public List<SlugModel> SectionsSlugs { get; set; }
    }
}
