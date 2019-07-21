using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.POSs.Directory.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.POSs.Models;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Slugs;

namespace TamTech.Monshaat.POS.Web.SDK.Services.POSs
{
    public interface IPOSService
    {

        #region -- Public  POSs --------------------------
        #endregion

        #region -- POSs Manager -------------------------
         

        Task<IRequestProviderResult<Guid>> CreateAsync(CreatePosModel model);

        Task<IRequestProviderResult<bool>> VerifySlugUniqueAsync(string slug, Guid? id = null);

        Task<IRequestProviderResult<GeneratedSlugModel>> VerifySlugUniqueByNameAsync(string name, Guid? id = null);

        Task<IRequestProviderResult<PagedResultModel<List<PosDto>>>> GetPOSsForCurrentUserAsync(PosFilters model);


        Task<IRequestProviderResult<PosDto>> GetByIdAndCurrentUserExceptSoftDeletedAsync(Guid id, string lang);

         

        Task<IRequestProviderResult<bool>> EditAsync(UpdatePosModel model);

        Task<IRequestProviderResult<bool>> SoftDeleteByCurrentUserAsync(Guid id);
        #endregion


    }
}
