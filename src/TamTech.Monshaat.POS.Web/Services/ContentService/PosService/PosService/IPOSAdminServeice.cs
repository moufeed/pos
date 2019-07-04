using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Models.Dtos.SelectList;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.PosService.PosService.Models;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;

namespace TamTech.Monshaat.POS.Web.Services.PosService.PosService
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
