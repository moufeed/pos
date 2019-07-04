using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Contact;
using TamTechSDK.Common.Services.ContentService.Contact.Models;
using TamTech.ContentService.Services.ContactsUs;
using TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Contact.Mapper;
using TamTechSDK.Common.Models.Filter;
using TamTechSDK.Common.Models.Pagination;
using TamTech.Monshaat.POS.Web.DirectBackendServices.PosServices;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Contact
{
    public class DirectContactService : BaseDirectService, IContactService
    {
        private readonly IContactUsService _ContactServices;
        public DirectContactService(IContactUsService contactUsService)
        {
            _ContactServices = contactUsService;
        }
        public async Task<IRequestProviderResult<Guid>> CreateAsync(CreateModel model)
        {
            var result = await _ContactServices.CreateAsync(model.mapToBackCreateContact());

            return MapRequestProviderResult(result);
        }

        public async Task<ContactDto> GetByIdExceptSoftDeletedAsync(Guid id, string lang)
        {
            var request = await _ContactServices.GetByIdExceptSoftDeletedAsync(id, lang);

            return request != null ? request.MapToFrontContactDto() : null;

        }

        public async Task<ContactDto> GetByIdAndSetStatusAsync(Guid id, string lang)
        {
            var request = await _ContactServices.GetByIdAndSetStatusAsync(id, lang);

            return request != null ? request.MapToFrontContactDto() : null;

        }

        public async Task<PagedResultModel<List<ContactDto>>> GetExceptSoftDeletedAsync(DTFilter model)
        {
            var request = await _ContactServices.GetExceptSoftDeletedAsync(model.MapToBackDTFilter());

            return new PagedResultModel<List<ContactDto>>
            {
                Data = request.Data != null ? request.Data.Select(s => s.MapToFrontContactDto()).ToList() : new List<ContactDto>(),
                Pagination = request.Pagination != null ? request.Pagination.MapToFrontPagination() : new PaginationMetadataModel(),
                SectionsSlugs = request.SectionsSlugs?.Select(m => m.MapToFrontSlug()).ToList()
            };
        }

        public async Task<IRequestProviderResult<bool>> ReplayAsync(ReplayContactUsModel model)
        {
            var request = await _ContactServices.ReplayAsync(model.MapToBackReplayModel());

            return MapRequestProviderResult(request);
        }

        public async Task<IRequestProviderResult<bool>> RemoveReplayAsync(Guid id)
        {
            var request = await _ContactServices.RemoveReplayAsync(id);

            return MapRequestProviderResult(request);

        }
    }
}
