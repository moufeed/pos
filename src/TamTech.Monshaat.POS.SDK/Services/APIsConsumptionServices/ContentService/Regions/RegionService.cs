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
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Regions.Settings;
using TamTech.Monshaat.POS.Web.Services.ContentService.Regions;
using TamTech.Monshaat.POS.Web.Services.ContentService.Regions.Models;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Regions
{
    public   class RegionService : BaseAPIService, IRegionService ,  IContactRegionService
    {

        #region Props    
        private readonly IRegionApiSettings _apiSettings;
        #endregion


        #region Ctors
        public RegionService(IRequestProvider requestProvider, IRegionApiSettings apiSettings)
            :base(requestProvider)
        {        
            _apiSettings = apiSettings;
        }
        #endregion


        #region Published

        public async Task<IRequestProviderResult<RegionDto>> GetPublishedBySlugAsync(string slug)
        {
            return await ReqProvider.GetAsync<RegionDto, List<object>>(_apiSettings.GetPublishedBySlugEndpoint, new List<object> { slug }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<List<RegionDto>>> GetPublishedListAsync(bool sortManually = true)
        {
            return await ReqProvider.GetAsync<List<RegionDto>, List<object>>(_apiSettings.GetPublishedListEndpoint, new List<object> { sortManually }, PassParamsBy.Route);
            
        }

        public async Task<IRequestProviderResult<List<RegionDto>>> GetPublishedListAsync(int takeItems, bool sortManually = true)
        {
            return await ReqProvider.GetAsync<List<RegionDto>, List<object>>(_apiSettings.GetPublishedLimitedListEndpoint, new List<object> { takeItems, sortManually }, PassParamsBy.Route);
            
        } 

        public async Task<IRequestProviderResult<List<SelectListItemModel>>> GetPublishedSelectListAsync(string lang, bool sortManually = true)
        {
            return await ReqProvider.GetAsync<List<SelectListItemModel>, List<object>>(_apiSettings.GetPublishedSelectListEndpoint, new List<object> { lang, sortManually }, PassParamsBy.Route);
        }

        #endregion

        #region Admin / Get

        public async Task<IRequestProviderResult<List<RegionDto>>> GetAllExceptSoftDeletedAsync(string lang)
        {
            return await ReqProvider.GetAsync<List<RegionDto>, List<object>>(_apiSettings.GetAllExceptSoftDeletedEndpoint, new List<object> { lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<List<SelectListItemModel>>>  GetAllSelectListAsync(string lang)
        {
            return await ReqProvider.GetAsync<List<SelectListItemModel>, List<object>>(_apiSettings.GetAllSelectListEndpoint, new List<object> { lang }, PassParamsBy.Route);
         }

        public async Task<IRequestProviderResult<RegionDto>> GetByIdExceptSoftDeletedAsync(int id, string lang)
        {
            return await ReqProvider.GetAsync<RegionDto, List<object>>(_apiSettings.GetByIdExceptSoftDeletedEndpoint, new List<object> { id, lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<PagedResultModel<List<RegionDto>>>>  GetExceptSoftDeletedAsync(DTFilter model)
        {
            return await ReqProvider.GetAsync<PagedResultModel<List<RegionDto>>, DTFilter>(_apiSettings.GetExceptSoftDeletedEndpoint , model, PassParamsBy.Body);
        }


      

        #endregion


        #region Admin -  Create / Edit / Publish / Delete


        public async Task<IRequestProviderResult<int>> CreateAsync(CreateRegionModel model)
        {
            return await ReqProvider.PostAsync<int, CreateRegionModel>(_apiSettings.CreateEndpoint, model);
        }

        public  async Task<IRequestProviderResult<bool>> EditAsync(UpdateRegionModel model)
        {
            return await ReqProvider.PostAsync<bool, UpdateRegionModel>(_apiSettings.EditEndpoint, model);
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