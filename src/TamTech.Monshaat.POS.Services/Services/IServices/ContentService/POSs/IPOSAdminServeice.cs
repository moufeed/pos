using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination; 
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.POSs.Models; 

namespace TamTech.Monshaat.POS.Web.Services.POSs
{
    public interface IPOSAdminServeice
    {
        Task<IRequestProviderResult<PagedResultModel<List<PosBaseDto>>>> GetExceptSoftDeletedAsync(DTFilter model);

        Task<IRequestProviderResult<PosDto>> GetByIdExceptSoftDeletedAsync(Guid id, string lang);


        Task<IRequestProviderResult<bool>> SoftDeleteAsync(Guid id);

        Task<IRequestProviderResult<List<ProcessActionModel>>> GetPOSActionsAsync(string lang);

        Task<IRequestProviderResult<PosBaseDto>> SetActionAsync(UpdatePOSStatus model);

        Task<IRequestProviderResult<bool>> PublishAsync(PublishModel model);

        Task<IRequestProviderResult<List<POSStatusHistoryDto>>> GetStatusHistoriesListAsync(Guid posId, string lang);
    }
}
