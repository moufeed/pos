using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Biography.settings;
using TamTech.Monshaat.POS.Web.Services.ContentService.Biographies;
using TamTech.Monshaat.POS.Web.Services.ContentService.Biographies.Models;

namespace TamTech.Monshaat.POS.Web.Services.APIsServices.Biography
{
    public class BiographyService : BaseAPIService, IBiographyService
    {
        #region prop
        private readonly IRequestProvider _requestProvider;
        private readonly IBiographyApiSettings _apiSettings;
        #endregion

        #region ctor
        public BiographyService(IRequestProvider requestProvider, IBiographyApiSettings apiSettings) : base(requestProvider)
        {
            _requestProvider = requestProvider;
            _apiSettings = apiSettings;
        }

        public async Task<IRequestProviderResult<bool>> EditAsync(UpdateBiographyModel model)
        {
            return await _requestProvider.PostAsync<bool, UpdateBiographyModel>(_apiSettings.EditEndpoint, model);
        }

        public async Task<IRequestProviderResult<List<BiographyDto>>> GetAllAsync()
        {
            return await _requestProvider.GetAsync<List<BiographyDto>> (_apiSettings.GetAllEndpoint);
        }

        public async Task<IRequestProviderResult<List<BiographyDto>>> GetByGroupIdAsync(int groupId, string lang)
        {
            return await _requestProvider.GetAsync<List<BiographyDto>, List<object>> (_apiSettings.GetByGroupIdEndpoint, new List<object> { groupId , lang }, PassParamsBy.Route);
        }
        #endregion
    }
}
