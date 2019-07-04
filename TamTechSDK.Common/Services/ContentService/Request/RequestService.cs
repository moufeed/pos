using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.SelectList;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Request.Models;
using TamTechSDK.Common.Services.ContentService.Sections.Models;

namespace TamTechSDK.Common.Services.ContentService.Request
{
    public class RequestService : IRequestService
    {
        public Task<IRequestProviderResult<Guid>> CreateAsync(CreateRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<PagedResultModel<List<RequestDto>>>> GetAllExceptSoftDeletedAsync(PaginationModel pagination, Dictionary<string, object> searchParams, SortingModel sorting, string lang)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<RequestDto>> GetByIdAsync(Guid id, string lang)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<List<SelectListItemModel>>> GetItemsListExceptSoftDeletedAsync(string lang)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<List<SelectListItemModel>>> GetPublicItemsListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<RequestHistoryDto>> GetRequestHistoriesListByRequestIdAsync(Guid requestId, string lang)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> UpdateRequestStatusAsync(UpdateRequestStatusModel model)
        {
            throw new NotImplementedException();
        }
    }
}
