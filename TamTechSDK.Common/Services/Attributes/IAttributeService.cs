using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Filter;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.SelectList;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.Attributes.Models;

namespace TamTechSDK.Common.Services.Attributes
{
    public  interface IAttributeService
    {

        #region Public  Attributes

        Task<AttributeDto> GetPublishedBySlugAsync(string slug);

        Task<List<AttributeDto>> GetPublishedListAsync(bool sortManually = true);

        Task<List<AttributeDto>> GetPublishedListAsync(int takeItems, bool sortManually = true);

        #endregion

        #region Attributes Manager

        #region Get

        Task<List<SelectListItemModel>> GetAllSelectListAsync(string lang);

        Task<AttributeDto> GetByIdAsync(int id, string lang);

        Task<List<AttributeDto>> GetAllAsync(string lang);

        Task<PagedResultModel<List<AttributeDto>>> GetAsync(DTFilter model);

        #endregion

        #region  Publish / Create / Edit / Delete 



        Task<IRequestProviderResult<int>> CreateAsync(CreateAttributeModel model);

        Task<IRequestProviderResult<bool>> EditAsync(UpdateAttributeModel model);

        Task<IRequestProviderResult<bool>> SoftDeleteAsync(int id);

        Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO model);


        #endregion





        #endregion
    }
}
