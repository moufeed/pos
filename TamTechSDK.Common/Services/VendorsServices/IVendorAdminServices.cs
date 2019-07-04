using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Filter;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.Shared.Models;
using TamTechSDK.Common.Services.VendorsServices.Models;

namespace TamTechSDK.Common.Services.VendorsServices
{
    public interface IVendorAdminServices
    {
        #region Get

        Task<List<ProcessActionModel>> GetVendorActions(string lang);

        Task<PagedResultModel<List<PersonDto>>> GetExceptSoftDeletedAsync(DTFilter model);

        Task<PersonDto> GetByIdExceptSoftDeletedAsync(Guid id, string lang);
        #endregion

        #region

        Task<IRequestProviderResult<PersonDto>> SetActionAsync(SetAction model);

        Task<IRequestProviderResult<bool>> SoftDeleteAsync(Guid id);

        Task<IRequestProviderResult<bool>> ActivateAsync(ActiveModel model);

        Task<List<VendorStatusHistoryDto>> GetStatusHistoriesListAsync(Guid VId, string lang);
        #endregion
    }
}
