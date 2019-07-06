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
using TamTech.Monshaat.POS.Web.Services.APIsServices.Sectors.Settings;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sectors;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sectors.Models;

namespace TamTech.Monshaat.POS.Web.Services.APIsServices.Sectors
{
    public   class SectorService : BaseAPIService, ISectorServices, IPOSSectorServices 
    {

        #region Props 
        private readonly IRequestProvider _requestProvider;

        private readonly ISectorApiSettings _apiSettings;
        #endregion


        #region Ctors
        public SectorService(IRequestProvider requestProvider, ISectorApiSettings apiSettings)
            :base(requestProvider)
        {
            _requestProvider = requestProvider;
            _apiSettings = apiSettings;
        }
        #endregion


        #region Published

        public async Task<IRequestProviderResult<SectorDto>> GetPublishedBySlugAsync(string slug)
        {
            return await _requestProvider.GetAsync<SectorDto, List<object>>(_apiSettings.GetPublishedBySlugEndpoint, new List<object> { slug }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<List<SectorDto>>> GetPublishedListAsync(bool sortManually = true)
        {
            return await _requestProvider.GetAsync<List<SectorDto>, List<object>>(_apiSettings.GetPublishedListEndpoint, new List<object> { sortManually }, PassParamsBy.Route);
            
        }

        public async Task<IRequestProviderResult<List<SectorDto>>> GetPublishedListAsync(int takeItems, bool sortManually = true)
        {
            return await _requestProvider.GetAsync<List<SectorDto>, List<object>>(_apiSettings.GetPublishedLimitedListEndpoint, new List<object> { takeItems, sortManually }, PassParamsBy.Route);
            
        }

        #endregion

        #region Admin / Get

        public async Task<IRequestProviderResult<List<SectorDto>>> GetAllExceptSoftDeletedAsync(string lang)
        {
            return await _requestProvider.GetAsync<List<SectorDto>, List<object>>(_apiSettings.GetAllExceptSoftDeletedEndpoint, new List<object> { lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<List<SelectListItemModel>>>  GetAllSelectListAsync(string lang)
        {
            return await _requestProvider.GetAsync<List<SelectListItemModel>, List<object>>(_apiSettings.GetAllSelectListEndpoint, new List<object> { lang }, PassParamsBy.Route);
         }

        public async Task<IRequestProviderResult<SectorDto>> GetByIdExceptSoftDeletedAsync(int id, string lang)
        {
            return await _requestProvider.GetAsync<SectorDto, List<object>>(_apiSettings.GetByIdExceptSoftDeletedEndpoint, new List<object> { id, lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<PagedResultModel<List<SectorDto>>>>  GetExceptSoftDeletedAsync(DTFilter model)
        {
            return await _requestProvider.GetAsync<PagedResultModel<List<SectorDto>>, DTFilter>(_apiSettings.GetExceptSoftDeletedEndpoint , model, PassParamsBy.Body);
        }


        public async Task<IRequestProviderResult<List<SelectListItemModel>>>  GetSelectListAsync(string lang, bool isOfficial = true)
        {
            return await _requestProvider.GetAsync<List<SelectListItemModel>, List<object>>(_apiSettings.GetSelectListEndpoint, new List<object> { lang, isOfficial }, PassParamsBy.Route);
        }

        #endregion


        #region Admin -  Create / Edit / Publish / Delete


        public async Task<IRequestProviderResult<int>> CreateAsync(CreateSectorModel model)
        {
            return await _requestProvider.PostAsync<int, CreateSectorModel>(_apiSettings.CreateEndpoint, model);
        }

        public  async Task<IRequestProviderResult<bool>> EditAsync(UpdateSectorModel model)
        {
            return await _requestProvider.PostAsync<bool, UpdateSectorModel>(_apiSettings.EditEndpoint, model);
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