using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.DirectBackendServices.PosServices.Pos.Mapper;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.PosService.Directory.Models;
using TamTech.Monshaat.POS.Web.Services.PosService.PosService;
using TamTech.Monshaat.POS.Web.Services.PosService.PosService.Models;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Slugs;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.PosServices.Pos
{
    public class DirectPosService : BaseDirectService, IPOSService
    {
        private readonly TamTech.ContentService.Services.POSs.IPOSManagerService _posservices;

        public DirectPosService(TamTech.ContentService.Services.POSs.IPOSManagerService posservices)
        {
            _posservices = posservices;
        }
        public async Task<IRequestProviderResult<Guid>> CreateAsync(CreatePosModel model)
        {
            var request = await _posservices.CreateAsync(model.MapToBackCreatePosModel());

            return MapRequestProviderResult(request);
        }

        public async Task<IRequestProviderResult<bool>> EditAsync(UpdatePosModel model)
        {
            var request = await _posservices.EditAsync(model.MapToBackUpdatePosModel());
            return MapRequestProviderResult(request);
        }

        public async Task<PosDto> GetByIdAndCurrentUserExceptSoftDeletedAsync(Guid id, string lang)
        {
            var request = await _posservices.GetByIdAndCurrentUserExceptSoftDeletedAsync(id, lang);
            return request?.MapToForntPosDto();
        }

        public async Task<PagedResultModel<List<PosDto>>> GetPOSsForCurrentUserAsync(PosFilters model)
        {
            var request = await _posservices.GetPOSsForCurrentUserAsync(model.MapToBackPosFilter());

            return new PagedResultModel<List<PosDto>>
            {
                Data = request.Data?.Select(s => s.MapToForntPosDto()).ToList(),
                Pagination = request.Pagination != null ? request.Pagination.MapToFrontPagination() : new PaginationMetadataModel(),
                SectionsSlugs = request.SectionsSlugs?.Select(m => m.MapToFrontSlug()).ToList()
            };
        }

        public async Task<IRequestProviderResult<bool>> SoftDeleteByCurrentUserAsync(Guid id)
        {
            var request = await _posservices.SoftDeleteByCurrentUserAsync(id);
            return MapRequestProviderResult(request);
        }

        public async Task<IRequestProviderResult<bool>> VerifySlugUniqueAsync(string slug, Guid? id = null)
        {
            var request = await _posservices.VerifySlugUniqueAsync(slug, id);
            return MapRequestProviderResult(request);
        }

        public async Task<IRequestProviderResult<GeneratedSlugModel>> VerifySlugUniqueByNameAsync(string name, Guid? id = null)
        {
            var request = await _posservices.VerifySlugUniqueByNameAsync(name, id);

            var slug = request.Data?.MapToFrontGeneratedSlugModel();
            return ReturnResult(slug, request.Success, MapToHttpStatusCode(request.StatusCode), request.Messages);
        }
    }
}
