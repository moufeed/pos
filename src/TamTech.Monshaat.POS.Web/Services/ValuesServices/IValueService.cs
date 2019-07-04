using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Filter;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.SelectList;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ValuesServices.Models;

namespace TamTechSDK.Common.Services.ValuesServices
{
    public interface IValueService
    {
        #region Public  Values

        Task<ValueDto> GetPublishedBySlugAsync(string slug);

        Task<List<ValueDto>> GetPublishedListAsync(bool sortManually = true);

        Task<List<ValueDto>> GetPublishedListAsync(int takeItems, bool sortManually = true);

        #endregion

        #region Values Manager

        #region Get 

        Task<ValueDto> GetByIdExceptSoftDeletedAsync(int id, string lang);

        Task<List<ValueDto>> GetAllExceptSoftDeletedAsync(string lang);

        Task<PagedResultModel<List<ValueDto>>> GetExceptSoftDeletedAsync(DTFilter model);

        #endregion

        #region  Publish / Create / Edit / Delete 



        Task<IRequestProviderResult<int>> CreateAsync(CreateValueModel model);

        Task<IRequestProviderResult<bool>> EditAsync(UpdateValueModel model);

        Task<IRequestProviderResult<bool>> SoftDeleteAsync(int id);

        Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO model);


        #endregion





        #endregion
    }
}
