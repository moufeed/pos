using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Galleries.Models;

namespace TamTechSDK.Common.Services.ContentService.Galleries
{
    public interface IGalleriesService
    {

        #region public
        Task<IRequestProviderResult<List<GalleryLiteDto>>> GetPublicListAsync(string lang);

        Task<IRequestProviderResult<GalleryDto>> GetPublicBySlugAsync(string slug, string lang);

       // Task<List<GalleryLiteDto>> GetPublicListAsync(int takeItems);

        Task<List<GalleryLiteDto>> GetPublicListAsync(int takeItems, string section = null, bool sortManually = false);

        //  Task<PagedResultModel<List<GalleryLiteDto>>> GetPublicListAsync(PaginationModel pagination, bool sortingByOrder = false);
        Task<PagedResultModel<List<GalleryLiteDto>>> GetPublicListAsync(PaginationModel pagination, string section = null, SortingModel sorting = null);

        #endregion

        #region gallery menager

        Task<IRequestProviderResult<GalleryList>> GetAllAsync(PaginationModel pagination, Dictionary<string, object> searchParams, SortingModel sorting, string lang);
        #region Gallery

        Task<IRequestProviderResult<Guid>> CreateAsync(CreateGalleryDto Gallery);

        Task<IRequestProviderResult<bool>> EditAsync(UpdateGalleryDto Gallery);

        Task<IRequestProviderResult<GalleryDto>> GetByIdAsync(Guid id , string lang);
    
        Task<IRequestProviderResult<bool>>  PublishAsync(PublishDTO data);

        Task<IRequestProviderResult<bool>> DeleteAsync(Guid id);

        #endregion
        #region Gallery item

        Task<IRequestProviderResult<Guid>> CreateGalleryItemAsync(CreateGalleryItemDto Gallery);

        Task<IRequestProviderResult<bool>> EditGalleryItemAsync(UpdateGalleryItemDto Gallery);

        Task<IRequestProviderResult<GalleryItemDto>> GetGalleryItemByIdAsync(GalleryItemKeysDto model, string lang );

        Task<IRequestProviderResult<bool>> PublishGalleryItemByIdAsync(GalleryItemKeysDto dto);

        Task<IRequestProviderResult<bool>> DeleteGalleryItemByIdAsync(GalleryItemKeysDto dto);

        Task<IRequestProviderResult<bool>> PublishGalleryItemsAsync(PublishDTO dto);

        Task<IRequestProviderResult<Dictionary<Guid, string>>> CreateListGalleryItemsAsync(CreateListGalleryItemsDto data);

        #endregion

        #endregion

    }
}
