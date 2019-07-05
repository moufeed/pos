using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Models.Dtos.SelectList;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Types.Models;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Types
{
    public interface ITypeService
    {

        #region Public  Types

        Task<IRequestProviderResult<TypeDto>> GetPublishedBySlugAsync(string slug);

        Task<IRequestProviderResult<List<TypeDto>>> GetPublishedListAsync(bool sortManually = true);

        Task<IRequestProviderResult<List<TypeDto>>> GetPublishedListAsync(int takeItems, bool sortManually = true);

       

        #endregion

        #region Types Manager

        #region Get 

        Task<IRequestProviderResult<List<TypeDto>>> GetAllExceptSoftDeletedAsync(string lang); 

        Task<IRequestProviderResult<List<SelectListItemModel>>> GetAllSelectListAsync(string lang); 

        Task<IRequestProviderResult<TypeDto>> GetByIdExceptSoftDeletedAsync(int id, string lang); 

        Task<IRequestProviderResult<PagedResultModel<List<TypeDto>>>> GetExceptSoftDeletedAsync(DTFilter model); 

        Task<IRequestProviderResult<List<SelectListItemModel>>> GetSelectListAsync(string lang, bool isOfficial = true); 
        #endregion

        #region  Publish / Create / Edit / Delete 



        Task<IRequestProviderResult<int>> CreateAsync(CreateTypeModel model);

        Task<IRequestProviderResult<bool>> EditAsync(UpdateTypeModel model);

        Task<IRequestProviderResult<bool>> SoftDeleteAsync(int id);

        Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO model);


        #endregion


        #endregion

    }
}
