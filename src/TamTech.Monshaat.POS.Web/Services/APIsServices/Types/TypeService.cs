using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Models.Dtos.SelectList;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Types.Settings;
using TamTech.Monshaat.POS.Web.Services.ContentService.Types;
using TamTech.Monshaat.POS.Web.Services.ContentService.Types.Models;

namespace TamTech.Monshaat.POS.Web.Services.APIsServices.Types
{
    public   class TypeService : BaseAPIService, ITypeService , IPosTypeService , IContactTypeService
    {

        #region Props 
        private readonly IRequestProvider _requestProvider;

        private readonly ITypeApiSettings _apiSettings;
        #endregion


        #region Ctors
        public TypeService(IRequestProvider requestProvider, ITypeApiSettings apiSettings)
            :base(requestProvider)
        {
            _requestProvider = requestProvider;
            _apiSettings = apiSettings;
        }
        #endregion


        #region Published

        public async Task<IRequestProviderResult<TypeDto>> GetPublishedBySlugAsync(string slug)
        {
            return await _requestProvider.GetAsync<TypeDto, List<object>>(_apiSettings.GetPublishedBySlugEndpoint, new List<object> { slug });
        }

        public async Task<IRequestProviderResult<List<TypeDto>>> GetPublishedListAsync(bool sortManually = true)
        {
            return await _requestProvider.GetAsync<List<TypeDto>, List<object>>(_apiSettings.GetPublishedListEndpoint, new List<object> { sortManually });
            
        }

        public async Task<IRequestProviderResult<List<TypeDto>>> GetPublishedListAsync(int takeItems, bool sortManually = true)
        {
            return await _requestProvider.GetAsync<List<TypeDto>, List<object>>(_apiSettings.GetPublishedLimitedListEndpoint, new List<object> { takeItems, sortManually });
            
        }

        #endregion

        #region Admin / Get

        public async Task<IRequestProviderResult<List<TypeDto>>> GetAllExceptSoftDeletedAsync(string lang)
        {
            return await _requestProvider.GetAsync<List<TypeDto>, List<object>>(_apiSettings.GetAllExceptSoftDeletedEndpoint, new List<object> { lang });
        }

        public async Task<IRequestProviderResult<List<SelectListItemModel>>>  GetAllSelectListAsync(string lang)
        {
            return await _requestProvider.GetAsync<List<SelectListItemModel>, List<object>>(_apiSettings.GetAllSelectListEndpoint, new List<object> { lang });
         }

        public async Task<IRequestProviderResult<TypeDto>> GetByIdExceptSoftDeletedAsync(int id, string lang)
        {
            return await _requestProvider.GetAsync<TypeDto, List<object>>(_apiSettings.GetByIdExceptSoftDeletedEndpoint, new List<object> { id, lang });
        }

        public async Task<IRequestProviderResult<PagedResultModel<List<TypeDto>>>>  GetExceptSoftDeletedAsync(DTFilter model)
        {
            return await _requestProvider.GetAsync<PagedResultModel<List<TypeDto>>, DTFilter>(_apiSettings.GetExceptSoftDeletedEndpoint, model);
        }


        public async Task<IRequestProviderResult<List<SelectListItemModel>>>  GetSelectListAsync(string lang, bool isOfficial = true)
        {
            return await _requestProvider.GetAsync<List<SelectListItemModel>, List<object>>(_apiSettings.GetSelectListEndpoint, new List<object> { lang, isOfficial });
        }

        #endregion


        #region Admin -  Create / Edit / Publish / Delete


        public async Task<IRequestProviderResult<int>> CreateAsync(CreateTypeModel model)
        {
            return await _requestProvider.PostAsync<int, CreateTypeModel>(_apiSettings.CreateEndpoint, model);
        }

        public  async Task<IRequestProviderResult<bool>> EditAsync(UpdateTypeModel model)
        {
            return await _requestProvider.PostAsync<bool, UpdateTypeModel>(_apiSettings.EditEndpoint, model);
        } 

        public  async Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO model)
        {
            return await _requestProvider.PostAsync<bool, PublishDTO>(_apiSettings.PublishEndpoint, model);
        }

        public  async Task<IRequestProviderResult<bool>> SoftDeleteAsync(int id)
        {
            return await _requestProvider.PostAsync<bool, DeleteModel<int>>(_apiSettings.SoftDeleteEndpoint, new DeleteModel<int>(id));
        }

        #endregion



    }
}
