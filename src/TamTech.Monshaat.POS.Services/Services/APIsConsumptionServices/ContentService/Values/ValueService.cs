using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Values.Settings;
using TamTech.Monshaat.POS.Web.Services.ContentService.Values;
using TamTech.Monshaat.POS.Web.Services.ContentService.Values.Models;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Values
{
    public   class ValueService : BaseAPIService, IValueService , IPosValuesService
    {

        #region Props         
        private readonly IValueApiSettings _apiSettings;
        #endregion


        #region Ctors
        public ValueService(IRequestProvider requestProvider, IValueApiSettings apiSettings)
            :base(requestProvider)
        {         
            _apiSettings = apiSettings;
        }
        #endregion


        #region Published

        public async Task<IRequestProviderResult<ValueDto>> GetPublishedBySlugAsync(string slug)
        {
            return await ReqProvider.GetAsync<ValueDto, List<object>>(_apiSettings.GetPublishedBySlugEndpoint, new List<object> { slug }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<List<ValueDto>>> GetPublishedListAsync(bool sortManually = true)
        {
            return await ReqProvider.GetAsync<List<ValueDto>, List<object>>(_apiSettings.GetPublishedListEndpoint, new List<object> { sortManually }, PassParamsBy.Route);
            
        }

        public async Task<IRequestProviderResult<List<ValueDto>>> GetPublishedListAsync(int takeItems, bool sortManually = true)
        {
            return await ReqProvider.GetAsync<List<ValueDto>, List<object>>(_apiSettings.GetPublishedLimitedListEndpoint, new List<object> { takeItems, sortManually }, PassParamsBy.Route);
            
        }

        #endregion

        #region Admin / Get

        public async Task<IRequestProviderResult<List<ValueDto>>> GetAllExceptSoftDeletedAsync(string lang)
        {
            return await ReqProvider.GetAsync<List<ValueDto>, List<object>>(_apiSettings.GetAllExceptSoftDeletedEndpoint, new List<object> { lang }, PassParamsBy.Route);
        }
 
        public async Task<IRequestProviderResult<ValueDto>> GetByIdExceptSoftDeletedAsync(int id, string lang)
        {
            return await ReqProvider.GetAsync<ValueDto, List<object>>(_apiSettings.GetByIdExceptSoftDeletedEndpoint, new List<object> { id, lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<PagedResultModel<List<ValueDto>>>>  GetExceptSoftDeletedAsync(DTFilter model)
        {
            return await ReqProvider.GetAsync<PagedResultModel<List<ValueDto>>, DTFilter>(_apiSettings.GetExceptSoftDeletedEndpoint , model, PassParamsBy.Body);
        } 
 
        #endregion


        #region Admin -  Create / Edit / Publish / Delete


        public async Task<IRequestProviderResult<int>> CreateAsync(CreateValueModel model)
        {
            return await ReqProvider.PostAsync<int, CreateValueModel>(_apiSettings.CreateEndpoint, model);
        }

        public  async Task<IRequestProviderResult<bool>> EditAsync(UpdateValueModel model)
        {
            return await ReqProvider.PostAsync<bool, UpdateValueModel>(_apiSettings.EditEndpoint, model);
        } 

        public  async Task<IRequestProviderResult<bool>> PublishAsync(PublishLookupModel model)
        {
            return await ReqProvider.PostAsync<bool, PublishLookupModel>(_apiSettings.PublishEndpoint, model);
        }

        public  async Task<IRequestProviderResult<bool>> SoftDeleteAsync(int id)
        {
            return await ReqProvider.PostAsync<bool, DeleteModel<int>>(_apiSettings.SoftDeleteEndpoint, new DeleteModel<int>(id));
        }

        #endregion



    }
}