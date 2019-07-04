using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.SelectList;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Request.Models;

namespace TamTechSDK.Common.Services.ContentService.Request
{
    public interface IRequestService
    {
        #region public methods

        Task<IRequestProviderResult<List<SelectListItemModel>>> GetPublicItemsListAsync();

        #endregion

        Task<IRequestProviderResult<Guid>> CreateAsync(CreateRequestModel model);

        Task<IRequestProviderResult<bool>> UpdateRequestStatusAsync(UpdateRequestStatusModel model);


        Task<IRequestProviderResult<List<SelectListItemModel>>> GetItemsListExceptSoftDeletedAsync(string lang);

        Task<IRequestProviderResult<RequestDto>> GetByIdAsync(Guid id, string lang);
         
        Task<IRequestProviderResult<PagedResultModel<List<RequestDto>>>> GetAllExceptSoftDeletedAsync(PaginationModel pagination, Dictionary<string, object> searchParams, SortingModel sorting, string lang);
         
        Task<List<RequestHistoryDto>> GetRequestHistoriesListByRequestIdAsync(Guid requestId, string lang);

    }
}
