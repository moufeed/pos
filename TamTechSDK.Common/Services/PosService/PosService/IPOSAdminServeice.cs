using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Filter;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.SelectList;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.PosService.PosService.Models;
using TamTechSDK.Common.Services.Shared.Models;

namespace TamTechSDK.Common.Services.PosService.PosService
{
    public interface IPOSAdminServeice
    {
        Task<PagedResultModel<List<PosBaseDto>>> GetExceptSoftDeletedAsync(DTFilter model);

        Task<PosDto> GetByIdExceptSoftDeletedAsync(Guid id, string lang);


        Task<IRequestProviderResult<bool>> SoftDeleteAsync(Guid id);

        Task<List<ProcessActionModel>> GetPOSActionsAsync(string lang);

        Task<IRequestProviderResult<PosBaseDto>> SetActionAsync(UpdatePOSStatus model);

        Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO model);

        Task<List<POSStatusHistoryDto>> GetStatusHistoriesListAsync(Guid posId, string lang);
    }
}
