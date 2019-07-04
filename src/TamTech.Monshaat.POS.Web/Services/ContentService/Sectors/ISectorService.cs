using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Models.Dtos.SelectList;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sectors.Models;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Sectors
{
    public interface ISectorServices
    {
        #region Public  Sectors // ----------------------------------------------------- 

        Task<SectorDto> GetPublishedBySlugAsync(string slug);

        Task<List<SectorDto>> GetPublishedListAsync(bool sortManually = true);

        Task<List<SectorDto>> GetPublishedListAsync(int takeItems, bool sortManually = true);

        #endregion  // ------------------------------------------------------------


        #region Admin Services // ------------------------------------------------------------

        Task<List<SelectListItemModel>> GetSelectListAsync(string lang, bool isOfficial =true);

        Task<List<SelectListItemModel>> GetAllSelectListAsync(string lang);

        Task<SectorDto> GetByIdExceptSoftDeletedAsync(int id, string lang);

        Task<List<SectorDto>> GetAllExceptSoftDeletedAsync(string lang);

        Task<PagedResultModel<List<SectorDto>>> GetExceptSoftDeletedAsync(DTFilter model);

        Task<IRequestProviderResult<int>> CreateAsync(CreateSectorModel model);

        Task<IRequestProviderResult<bool>> EditAsync(UpdateSectorModel model);

        Task<IRequestProviderResult<bool>> SoftDeleteAsync(int id);

        Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO model);

        #endregion  // ------------------------------------------------------------



    }
}
