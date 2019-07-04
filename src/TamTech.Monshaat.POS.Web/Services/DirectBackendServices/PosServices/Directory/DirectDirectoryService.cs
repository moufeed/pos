using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.ContentService.Services.POSs;
using TamTech.Monshaat.POS.Web.DirectBackendServices.PosServices.Directory.Mapper;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Services.PosService.Directory;
using TamTech.Monshaat.POS.Web.Services.PosService.Directory.Models;
using TamTech.Monshaat.POS.Web.Services.PosService.PosService.Models;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.PosServices.Directory
{
    public class DirectDirectoryService : BaseDirectService, IDirectoryServices
    {
        private readonly IPOSSearchService _searchService;

        public DirectDirectoryService(IPOSSearchService POSSearchService)
        {
            _searchService = POSSearchService;
        }
        public async Task<PagedResultModel<List<PosDto>>> FindAsync(PosFilters model)
        {
            var request = await _searchService.FindAsync(model.MapToBackPosFilter());

            return new PagedResultModel<List<PosDto>>
            {
                Data = request.Data?.Select(s => s.MapToForntPosDto()).ToList(),
                Pagination = request.Pagination?.MapToFrontPagination(),
                SectionsSlugs = request.SectionsSlugs?.Select(m => m.MapToFrontSlug()).ToList()
            };

        }

        public async Task<int> GetCountOfPublishedAsync(string lang)
        {
            var request = await _searchService.GetCountOfPublishedAsync(lang);
            return request;
        }

        public async Task<PosDto> GetPublishedBySlugAsync(string slug)
        {
            var request = await _searchService.GetPublishedBySlugAsync(slug);

            return request?.MapToForntPosDto();
        }
    }
}
