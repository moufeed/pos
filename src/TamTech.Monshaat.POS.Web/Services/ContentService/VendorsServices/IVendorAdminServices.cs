using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Services.VendorsServices.Models;

namespace TamTech.Monshaat.POS.Web.Services.VendorsServices
{
    public interface IVendorAdminServices
    {
        #region Get

        Task<List<ProcessActionModel>> GetVendorActions(string lang);

        Task<PagedResultModel<List<PersonDto>>> GetExceptSoftDeletedAsync(DTFilter model);

        Task<PersonDto> GetByIdExceptSoftDeletedAsync(Guid id, string lang);
        #endregion

        #region

        Task<IRequestProviderResult<PersonDto>> SetActionAsync(SetActionModel model);

        Task<IRequestProviderResult<bool>> SoftDeleteAsync(Guid id);

        Task<IRequestProviderResult<bool>> ActivateAsync(ActiveModel model);

        Task<List<VendorStatusHistoryDto>> GetStatusHistoriesListAsync(Guid VId, string lang);
        #endregion
    }
}
