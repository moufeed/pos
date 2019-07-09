using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Models.Dtos.SelectList;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Status.Settings;
using TamTech.Monshaat.POS.Web.Services.ContentService.Status;
using TamTech.Monshaat.POS.Web.Services.ContentService.Status.Models;

namespace TamTech.Monshaat.POS.Web.Services.APIsServices.Status
{
    public class StatusService : BaseAPIService, IStatusService , IContactUsStatusService, IPosStatusService, IVendorStatusService
    {
        #region Props 
        private readonly IRequestProvider _requestProvider;

        private readonly IStatusApiSettings _apiSettings;

        public StatusService(IRequestProvider requestProvider , IStatusApiSettings apiSettings) : base(requestProvider)
        {
            _requestProvider = requestProvider;
            _apiSettings = apiSettings;
        }

        public async Task<IRequestProviderResult<List<StatusDto>>> GetAllAsync(string lang)
        {
            return await _requestProvider.GetAsync<List<StatusDto>, List<object>>(_apiSettings.GetAllEndpoint, new List<object> { lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<List<SelectListItemModel>>> GetAllSelectListAsync(string lang)
        {
            return await _requestProvider.GetAsync<List<SelectListItemModel>, List<object>>(_apiSettings.GetAllEndpoint, new List<object> { lang }, PassParamsBy.Route);
        }
        #endregion

    }
}
