using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Models.Dtos.Slugs;
using TamTech.Monshaat.POS.Web.Models.Shared;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Pos.Settings;
using TamTech.Monshaat.POS.Web.Services.POSs;
using TamTech.Monshaat.POS.Web.Services.POSs.Directory.Models;
using TamTech.Monshaat.POS.Web.Services.POSs.Models;

namespace TamTech.Monshaat.POS.Web.Services.APIsServices.Pos
{
    public class PosService : BaseAPIService , IPOSService
    {
        #region prop
        private readonly IRequestProvider _requestProvider;
        private readonly IPosApiSettings _apiSettings;
        #endregion

        #region ctor
        public PosService(IRequestProvider requestProvider, IPosApiSettings apiSettings) : base(requestProvider)
        {
            _requestProvider = requestProvider;
            _apiSettings = apiSettings;
        }
        #endregion

        public async Task<IRequestProviderResult<Guid>> CreateAsync(CreatePosModel model)
        {
            return await _requestProvider.PostAsync<Guid, CreatePosModel>(_apiSettings.CreateEndpoint, model);
        }

        public async Task<IRequestProviderResult<bool>> EditAsync(UpdatePosModel model)
        {
            return await _requestProvider.PostAsync<bool, UpdatePosModel>(_apiSettings.EditEndpoint, model);
        }

        public async Task<IRequestProviderResult<PosDto>> GetByIdAndCurrentUserExceptSoftDeletedAsync(Guid id, string lang)
        {
            return await _requestProvider.GetAsync<PosDto, List<object>>(_apiSettings.GetByIdAndCurrentUserExceptSoftDeletedEndpoint, new List<object> { id , lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<PagedResultModel<List<PosDto>>>> GetPOSsForCurrentUserAsync(PosFilters model)
        {
            return await _requestProvider.GetAsync<PagedResultModel<List<PosDto>>, PosFilters>(_apiSettings.GetPOSsForCurrentUserEndpoint, model , PassParamsBy.Body);
        }

        public async Task<IRequestProviderResult<bool>> SoftDeleteByCurrentUserAsync(Guid id)
        {
            return await _requestProvider.PostAsync<bool, DeleteModel<Guid>>(_apiSettings.SoftDeleteByCurrentUserEndpoint, new DeleteModel<Guid>(id));
        }

        public async Task<IRequestProviderResult<bool>> VerifySlugUniqueAsync(string slug, Guid? id = null)
        {
            return await _requestProvider.GetAsync<bool, List<object>>(_apiSettings.VerifySlugUniqueEndpoint, new List<object> { slug, id }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<GeneratedSlugModel>> VerifySlugUniqueByNameAsync(string name, Guid? id = null)
        {
            return await _requestProvider.GetAsync<GeneratedSlugModel, VerifyNameModel<Guid?>>(_apiSettings.VerifySlugUniqueByNameEndpoint, new VerifyNameModel<Guid?>(){ Name= name, Id = id }, PassParamsBy.Body);
        }
    }
}
