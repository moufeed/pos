using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Models.Dtos.Slugs;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Vendor.Settings;
using TamTech.Monshaat.POS.Web.Services.ContentService.Vendors;
using TamTech.Monshaat.POS.Web.Services.ContentService.Vendors.Models;

namespace TamTech.Monshaat.POS.Web.Services.APIsServices.Vendor
{
    public class VendoradminService : BaseAPIService, IVendorAdminServices
    {
        #region prop
        private readonly IRequestProvider _requestProvider;
        private readonly IVendorAdminApiSettings _apiSettings;
        #endregion

        #region ctor
        public VendoradminService(IRequestProvider requestProvider, IVendorAdminApiSettings apiSettings) : base(requestProvider)
        {
            _requestProvider = requestProvider;
            _apiSettings = apiSettings;
        }
        #endregion


        #region Get

        public async Task<IRequestProviderResult<PersonDto>> GetByIdExceptSoftDeletedAsync(Guid id, string lang)
        {
            return await _requestProvider.GetAsync<PersonDto, List<object>>(_apiSettings.GetByIdExceptSoftDeletedEndpoint, new List<object> { id,lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<PagedResultModel<List<PersonDto>>>> GetExceptSoftDeletedAsync(DTFilter model)
        {
            return await _requestProvider.GetAsync<PagedResultModel<List<PersonDto>>, DTFilter>(_apiSettings.GetExceptSoftDeletedEndpoint, model, PassParamsBy.Body);
        }

        public async Task<IRequestProviderResult<List<VendorStatusHistoryDto>>> GetStatusHistoriesListAsync(Guid VId, string lang)
        {
            return await _requestProvider.GetAsync<List<VendorStatusHistoryDto>, List<object>>(_apiSettings.GetStatusHistoriesListEndpoint, new List<object> { VId, lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<List<ProcessActionModel>>> GetVendorActions(string lang)
        {
            return await _requestProvider.GetAsync<List<ProcessActionModel>, List<object>>(_apiSettings.GetVendorActionsEndpoint, new List<object> {lang }, PassParamsBy.Route);
        }

        #endregion



        public async Task<IRequestProviderResult<bool>> ActivateAsync(ActiveModel model)
        {
            return await _requestProvider.PostAsync<bool, ActiveModel>(_apiSettings.ActivateEndpoint, model);
        }


        public async Task<IRequestProviderResult<PersonDto>> SetActionAsync(SetActionModel model)
        {
            return await _requestProvider.PostAsync<PersonDto, SetActionModel>(_apiSettings.SetActionEndpoint, model);
        }

        public async Task<IRequestProviderResult<bool>> SoftDeleteAsync(Guid id)
        {
            return await _requestProvider.PostAsync<bool, DeleteModel<Guid>>(_apiSettings.SoftDeleteEndpoint, new DeleteModel<Guid>(id));
        }
    }
}
