using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Filter;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.SelectList;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.Regions.Models;

namespace TamTechSDK.Common.Services.Regions
{
   public interface IRegionService
    {
        #region Public  Regions

        Task<RegionDto> GetPublishedBySlugAsync(string slug);

        Task<List<RegionDto>> GetPublishedListAsync(bool sortManually = true);

        Task<List<RegionDto>> GetPublishedListAsync(int takeItems, bool sortManually = true);

        Task<List<SelectListItemModel>> GetPublishedSelectListAsync(string lang, bool sortManually = true);

        #endregion

        #region Regions Manager

        #region Get

        Task<RegionDto> GetByIdExceptSoftDeletedAsync(int id, string lang);

        Task<List<RegionDto>> GetAllExceptSoftDeletedAsync(string lang);

        Task<PagedResultModel<List<RegionDto>>> GetExceptSoftDeletedAsync(DTFilter model);

        Task<List<SelectListItemModel>> GetAllSelectListAsync(string lang);

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
