using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Models.Dtos.SelectList;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Regions.Models;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Regions
{
   public interface IRegionService
    {
        #region Public  Regions

        Task<IRequestProviderResult<RegionDto>> GetPublishedBySlugAsync(string slug);

        Task<IRequestProviderResult<List<RegionDto>>> GetPublishedListAsync(bool sortManually = true);

        Task<IRequestProviderResult<List<RegionDto>>> GetPublishedListAsync(int takeItems, bool sortManually = true);

        Task<IRequestProviderResult<List<SelectListItemModel>>> GetPublishedSelectListAsync(string lang, bool sortManually = true);

        #endregion

        #region Regions Manager

        #region Get

        Task<IRequestProviderResult<RegionDto>> GetByIdExceptSoftDeletedAsync(int id, string lang);

        Task<IRequestProviderResult<List<RegionDto>>> GetAllExceptSoftDeletedAsync(string lang);

        Task<IRequestProviderResult<PagedResultModel<List<RegionDto>>>> GetExceptSoftDeletedAsync(DTFilter model);

        Task<IRequestProviderResult<List<SelectListItemModel>>> GetAllSelectListAsync(string lang);

        #endregion

        #region  Publish / Create / Edit / Delete 



        Task<IRequestProviderResult<int>> CreateAsync(CreateRegionModel model);

        Task<IRequestProviderResult<bool>> EditAsync(UpdateRegionModel model);

        Task<IRequestProviderResult<bool>> SoftDeleteAsync(int id);

        Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO model);


        #endregion





        #endregion
    }
}
