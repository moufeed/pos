using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Pos.Settings;
using TamTech.Monshaat.POS.Web.Services.POSs;
using TamTech.Monshaat.POS.Web.Services.POSs.Models;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Pos
{
    public class PosAdminService : BaseAPIService, IPOSAdminServeice
    {
        #region prop        
        private readonly IPosAdminApiSettings  _apiSettings;
        #endregion

        #region ctor
        public PosAdminService(IRequestProvider requestProvider, IPosAdminApiSettings apiSettings) : base(requestProvider)
        {                 
            _apiSettings = apiSettings;
        }
        #endregion



        #region // -- Get ---
        public async Task<IRequestProviderResult<PosDto>> GetByIdExceptSoftDeletedAsync(Guid id, string lang)
        {
            return await ReqProvider.GetAsync<PosDto, List<object>>(_apiSettings.GetByIdExceptSoftDeletedEndpoint, new List<object> { id, lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<PagedResultModel<List<PosBaseDto>>>> GetExceptSoftDeletedAsync(DTFilter model)
        {
            return await ReqProvider.GetAsync<PagedResultModel<List<PosBaseDto>>, DTFilter>(_apiSettings.GetExceptSoftDeletedEndpoint, model, PassParamsBy.Body);
        }

        public async Task<IRequestProviderResult<List<ProcessActionModel>>> GetPOSActionsAsync(string lang)
        {
            return await ReqProvider.GetAsync<List<ProcessActionModel>, List<object>>(_apiSettings.GetPOSActionsEndpoint, new List<object> { lang }, PassParamsBy.Route);
        }
         
        public async Task<IRequestProviderResult<List<POSStatusHistoryDto>>> GetStatusHistoriesListAsync(Guid posId, string lang)
        {
            return await ReqProvider.GetAsync<List<POSStatusHistoryDto>, List<object>>(_apiSettings.GetStatusHistoriesListEndpoint, new List<object> { posId, lang }, PassParamsBy.Route);
        }
        #endregion


        public async Task<IRequestProviderResult<bool>> PublishAsync(PublishModel model)
        {
            return await ReqProvider.PostAsync<bool, PublishModel>(_apiSettings.PublishEndpoint, model);
        }

        public async Task<IRequestProviderResult<PosBaseDto>> SetActionAsync(UpdatePOSStatus model)
        {
            return await ReqProvider.PostAsync<PosBaseDto, UpdatePOSStatus>(_apiSettings.SetActionEndpoint, model);
        }

        public async Task<IRequestProviderResult<bool>> SoftDeleteAsync(Guid id)
        {
            return await ReqProvider.PostAsync<bool, DeleteModel<Guid>>(_apiSettings.SoftDeleteEndpoint, new DeleteModel<Guid>(id));
        }
    }
}
