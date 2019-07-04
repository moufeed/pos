using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Models.Dtos.SelectList;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.POSs;
using TamTech.Monshaat.POS.Web.Services.POSs.Models;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.PosServices.Pos
{
    public class DirectAdminPosServices : BaseDirectService, IPOSAdminServeice
    {
        private readonly TamTech.ContentService.Services.POSs.IPOSService _posservices;

        public DirectAdminPosServices(TamTech.ContentService.Services.POSs.IPOSService posservices)
        {
            _posservices = posservices;
        }
        public async Task<PosDto> GetByIdExceptSoftDeletedAsync(Guid id, string lang)
        {
            var result = await _posservices.GetByIdExceptSoftDeletedAsync(id, lang);

            return result != null ? result.MapToForntPosDto() : new PosDto();

        }

        public async Task<PagedResultModel<List<PosBaseDto>>> GetExceptSoftDeletedAsync(DTFilter model)
        {
            var request = await _posservices.GetExceptSoftDeletedAsync(model.MapToBackDTFilter());

            return new PagedResultModel<List<PosBaseDto>>
            {
                Data = request.Data != null ? request.Data.Select(s => s.MapToForntPosBaseDto()).ToList() : new List<PosBaseDto>(),
                Pagination = request.Pagination != null ? request.Pagination.MapToFrontPagination() : new PaginationMetadataModel(),
                SectionsSlugs = request.SectionsSlugs?.Select(m => m.MapToFrontSlug()).ToList()
            };
        }

        public async Task<List<ProcessActionModel>> GetPOSActionsAsync(string lang)
        {
            var request = await _posservices.GetPOSActionsAsync(lang);
            return request?.Select(m => m.MapToFrontProcessActionModel()).ToList();
        }

        public async Task<List<POSStatusHistoryDto>> GetStatusHistoriesListAsync(Guid posId, string lang)
        {
            var request = await _posservices.GetStatusHistoriesListAsync(posId, lang);

            return request?.Select(el => el.MapToPOSStatusHistoryDto()).ToList();
        }

        public async Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO model)
        {
            var request = await _posservices.PublishAsync(model.MapToBackendPuplish());
            return MapRequestProviderResult(request);
        }

        public async Task<IRequestProviderResult<PosBaseDto>> SetActionAsync(UpdatePOSStatus model)
        {
            var request = await _posservices.SetActionAsync(model.MapToBackUpdatePOSStatus());

            var SelectItem = request.Data?.MapToForntPosBaseDto();

            return ReturnResult(SelectItem, request.Success, MapToHttpStatusCode(request.StatusCode), request.Messages);

        }

        public async Task<IRequestProviderResult<bool>> SoftDeleteAsync(Guid id)
        {
            var result = await _posservices.SoftDeleteAsync(id);
            return MapRequestProviderResult(result);
        }
    }
}
