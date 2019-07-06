using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.ContentService.Services.POSs;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.DirectBackendServices.PosServices.Directory.Mapper;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Services.POSs.Directory;
using TamTech.Monshaat.POS.Web.Services.POSs.Directory.Models;
using TamTech.Monshaat.POS.Web.Services.POSs.Models;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.PosServices.Directory
{
    public class DirectDirectoryService : BaseDirectService, IDirectoryServices
    {
        private readonly IPOSSearchService _searchService;

        public DirectDirectoryService(IPOSSearchService POSSearchService)
        {
            _searchService = POSSearchService;
        }
        public async Task<IRequestProviderResult<PagedResultModel<List<PosDto>>>> FindAsync(PosFilters model)
        {
            var request = await _searchService.FindAsync(model.MapToBackPosFilter());

            return ReturnRequestProviderResult(new PagedResultModel <List<PosDto>>
            {
                Data = request.Data?.Select(s => s.MapToForntPosDto()).ToList(),
                Pagination = request.Pagination?.MapToFrontPagination(),
                SectionsSlugs = request.SectionsSlugs?.Select(m => m.MapToFrontSlug()).ToList()
            });

        }

        public async Task<IRequestProviderResult<int>> GetCountOfPublishedAsync(string lang)
        {
            var request = await _searchService.GetCountOfPublishedAsync(lang);
            return ReturnRequestProviderResult(request);
        }

        public async Task<IRequestProviderResult<PosDto>> GetPublishedBySlugAsync(string slug)
        {
            var request = await _searchService.GetPublishedBySlugAsync(slug);

            return ReturnRequestProviderResult(request?.MapToForntPosDto());
        }
    }
}
