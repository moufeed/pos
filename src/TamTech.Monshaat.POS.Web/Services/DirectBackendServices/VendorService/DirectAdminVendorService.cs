using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.ContentService.Services.Persons;
using TamTech.Monshaat.POS.Web.DirectBackendServices.VendorService.Mapper;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Services.ContentService.Vendors;
using TamTech.Monshaat.POS.Web.Services.ContentService.Vendors.Models;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.VendorService
{
    public class DirectAdminVendorService : BaseDirectService, IVendorAdminServices
    {
        private readonly IVendorResponsibleService _vendorSerives;

        public DirectAdminVendorService(IVendorResponsibleService vendorSerives)
        {
            _vendorSerives = vendorSerives;
        }
        public async Task<IRequestProviderResult<bool>> ActivateAsync(ActiveModel model)
        {
            var request = await _vendorSerives.ActivateAsync(model.MaptoBackActiveModel());
            return MapRequestProviderResult(request);
        }

        public async Task<IRequestProviderResult<PersonDto>> GetByIdExceptSoftDeletedAsync(Guid id, string lang)
        {
            var request = await _vendorSerives.GetByIdExceptSoftDeletedAsync(id, lang);
            return ReturnRequestProviderResult(request?.MapToFrontPersonDto());
        }

        public async Task<IRequestProviderResult<PagedResultModel<List<PersonDto>>>> GetExceptSoftDeletedAsync(DTFilter model)
        {
            var request = await _vendorSerives.GetExceptSoftDeletedAsync(model.MapToBackDTFilter());

            return ReturnRequestProviderResult(new PagedResultModel<List<PersonDto>>
            {
                Data = request.Data != null ? request.Data.Select(s => s.MapToFrontPersonDto()).ToList() : new List<PersonDto>(),
                Pagination = request.Pagination != null ? request.Pagination.MapToFrontPagination() : new PaginationMetadataModel(),
                SectionsSlugs = request.SectionsSlugs?.Select(m => m.MapToFrontSlug()).ToList()
            });
        }

        public async Task<IRequestProviderResult<List<VendorStatusHistoryDto>>> GetStatusHistoriesListAsync(Guid VId, string lang)
        {
            var result = await _vendorSerives.GetStatusHistoriesListAsync(VId, lang);

            return ReturnRequestProviderResult(result?.Select(el => el.MapToVendorStatusHistoryDto()).ToList());
        }

        public async Task<IRequestProviderResult<List<ProcessActionModel>>> GetVendorActions(string lang)
        {
            var request = await _vendorSerives.GetVendorActionsAsync(lang);
            return ReturnRequestProviderResult(request?.Select(m => m.MapToFrontProcessActionModel()).ToList());
        }

        public async Task<IRequestProviderResult<PersonDto>> SetActionAsync(SetActionModel model)
        {
            var request = await _vendorSerives.SetActionAsync(model.MapToBackSetAction());

            var personItem = request.Data?.MapToFrontPersonDto();

            return ReturnResult(personItem, request.Success, MapToHttpStatusCode(request.StatusCode), request.Messages);
        }

        public async Task<IRequestProviderResult<bool>> SoftDeleteAsync(Guid id)
        {
            var request = await _vendorSerives.SoftDeleteAsync(id);
            return MapRequestProviderResult(request);
        }

         
    }
}
