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
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Attributes.Settings;
using TamTech.Monshaat.POS.Web.Services.ContentService.Attributes;
using TamTech.Monshaat.POS.Web.Services.ContentService.Attributes.Models;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Attributes
{
    public   class AttributeService : BaseAPIService, IAttributeService , IPOSAttributeService 
    {

        #region Props 
        private readonly IRequestProvider _requestProvider;

        private readonly IAttributeApiSettings _apiSettings;
        #endregion


        #region Ctors
        public AttributeService(IRequestProvider requestProvider, IAttributeApiSettings apiSettings)
            :base(requestProvider)
        {
            _requestProvider = requestProvider;
            _apiSettings = apiSettings;
        }
        #endregion


        #region Published

        public async Task<IRequestProviderResult<AttributeDto>> GetPublishedBySlugAsync(string slug)
        {
            return await _requestProvider.GetAsync<AttributeDto, List<object>>(_apiSettings.GetPublishedBySlugEndpoint, new List<object> { slug }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<List<AttributeDto>>> GetPublishedListAsync(bool sortManually = true)
        {
            return await _requestProvider.GetAsync<List<AttributeDto>, List<object>>(_apiSettings.GetPublishedListEndpoint, new List<object> { sortManually }, PassParamsBy.Route);
            
        }

        public async Task<IRequestProviderResult<List<AttributeDto>>> GetPublishedListAsync(int takeItems, bool sortManually = true)
        {
            return await _requestProvider.GetAsync<List<AttributeDto>, List<object>>(_apiSettings.GetPublishedLimitedListEndpoint, new List<object> { takeItems, sortManually }, PassParamsBy.Route);
            
        }

        #endregion

        #region Admin / Get

      


        public async Task<IRequestProviderResult<List<AttributeDto>>> GetAllAsync(string lang)
        {
            return await _requestProvider.GetAsync<List<AttributeDto>, List<object>>(_apiSettings.GetAllExceptSoftDeletedEndpoint, new List<object> { lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<List<SelectListItemModel>>> GetAllSelectListAsync(string lang)
        {
            return await _requestProvider.GetAsync<List<SelectListItemModel>, List<object>>(_apiSettings.GetAllSelectListEndpoint, new List<object> { lang }, PassParamsBy.Route);
         }

        public async Task<IRequestProviderResult<AttributeDto>> GetByIdAsync(int id, string lang)
        {
            return await _requestProvider.GetAsync<AttributeDto, List<object>>(_apiSettings.GetByIdExceptSoftDeletedEndpoint, new List<object> { id, lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<PagedResultModel<List<AttributeDto>>>> GetAsync(DTFilter model)
        {
            return await _requestProvider.GetAsync<PagedResultModel<List<AttributeDto>>, DTFilter>(_apiSettings.GetExceptSoftDeletedEndpoint , model, PassParamsBy.Body);
        }
 
        #endregion


        #region Admin -  Create / Edit / Publish / Delete


        public async Task<IRequestProviderResult<int>> CreateAsync(CreateAttributeModel model)
        {
            return await _requestProvider.PostAsync<int, CreateAttributeModel>(_apiSettings.CreateEndpoint, model);
        }

        public  async Task<IRequestProviderResult<bool>> EditAsync(UpdateAttributeModel model)
        {
            return await _requestProvider.PostAsync<bool, UpdateAttributeModel>(_apiSettings.EditEndpoint, model);
        } 

        public  async Task<IRequestProviderResult<bool>> PublishAsync(PublishLookupModel model)
        {
            return await _requestProvider.PostAsync<bool, PublishLookupModel>(_apiSettings.PublishEndpoint, model);
        }

        public  async Task<IRequestProviderResult<bool>> SoftDeleteAsync(int id)
        {
            return await _requestProvider.PostAsync<bool, DeleteModel<int>>(_apiSettings.SoftDeleteEndpoint, new DeleteModel<int>(id));
        }

        #endregion



    }
}