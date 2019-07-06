using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Models.Dtos.SelectList;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Values.Models;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Values
{
    public interface IValueService
    {
        #region Public  Values

        Task<IRequestProviderResult<ValueDto>> GetPublishedBySlugAsync(string slug);

        Task<IRequestProviderResult<List<ValueDto>>> GetPublishedListAsync(bool sortManually = true);

        Task<IRequestProviderResult<List<ValueDto>>> GetPublishedListAsync(int takeItems, bool sortManually = true);

        #endregion

        #region Values Manager

        #region Get 

        Task<IRequestProviderResult<ValueDto>> GetByIdExceptSoftDeletedAsync(int id, string lang);

        Task<IRequestProviderResult<List<ValueDto>>> GetAllExceptSoftDeletedAsync(string lang);

        Task<IRequestProviderResult<PagedResultModel<List<ValueDto>>>> GetExceptSoftDeletedAsync(DTFilter model);

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
