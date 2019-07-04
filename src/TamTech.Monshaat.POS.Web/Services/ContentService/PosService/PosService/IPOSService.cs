using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.PosService.Directory.Models;
using TamTech.Monshaat.POS.Web.Services.PosService.PosService.Models;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Slugs;

namespace TamTech.Monshaat.POS.Web.Services.PosService.PosService
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
