using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.PosService.Directory.Models;
using TamTechSDK.Common.Services.PosService.PosService.Models;
using TamTechSDK.Common.Services.Shared.Models;

namespace TamTechSDK.Common.Services.PosService.PosService
{
    public interface IPOSService
    {

        #region -- Public  POSs --------------------------
        #endregion

        #region -- POSs Manager -------------------------
         

        Task<IRequestProviderResult<Guid>> CreateAsync(CreatePosModel model);

        Task<IRequestProviderResult<bool>> VerifySlugUniqueAsync(string slug, Guid? id = null);

        Task<IRequestProviderResult<GeneratedSlugModel>> VerifySlugUniqueByNameAsync(string name, Guid? id = null);

        Task<PagedResultModel<List<PosDto>>> GetPOSsForCurrentUserAsync(PosFilters model);


        Task<PosDto> GetByIdAndCurrentUserExceptSoftDeletedAsync(Guid id, string lang);

         

        Task<IRequestProviderResult<bool>> EditAsync(UpdatePosModel model);

        Task<IRequestProviderResult<bool>> SoftDeleteByCurrentUserAsync(Guid id);
        #endregion


    }
}
