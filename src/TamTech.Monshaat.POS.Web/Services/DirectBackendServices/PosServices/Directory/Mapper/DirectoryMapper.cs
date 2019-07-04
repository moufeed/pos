using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.PosServices.Directory.Mapper
{
    public static class DirectoryMapper
    {

        public static TamTech.ContentService.Services.POSs.Models.POSFilterModel MapToBackPosFilter(this TamTech.Monshaat.POS.Web.Services.POSs.Directory.Models.PosFilters item)
        {
            return new ContentService.Services.POSs.Models.POSFilterModel
            {
                Descending = item.Descending,
                Lang = item.Lang,
                PageNumber = item.PageNumber,
                PageSize = item.PageSize,
                SortBy = item.SortBy,
                Search = item.Search,
            };
        }
    }
}
