using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Directory.Settings;
using TamTech.Monshaat.POS.Web.Services.POSs.Directory;
using TamTech.Monshaat.POS.Web.Services.POSs.Directory.Models;
using TamTech.Monshaat.POS.Web.Services.POSs.Models;

namespace TamTech.Monshaat.POS.Web.Services.APIsServices.Directory
{
    public class DirectoryService : BaseAPIService, IDirectoryServices
    {

        #region prop
        private readonly IRequestProvider _requestProvider;
        private readonly IDirectoryApiSettings  _apiSettings;
        #endregion

        #region ctor
        public DirectoryService(IRequestProvider requestProvider, IDirectoryApiSettings apiSettings) : base(requestProvider)
        {
            _requestProvider = requestProvider;
            _apiSettings = apiSettings;
        }
        #endregion

        public async Task<IRequestProviderResult<PagedResultModel<List<PosDto>>>> FindAsync(PosFilters model)
        {
            return await _requestProvider.GetAsync<PagedResultModel<List<PosDto>>, PosFilters>(_apiSettings.FindEndPoint, model, PassParamsBy.Body);
        }

        public async Task<IRequestProviderResult<int>> GetCountOfPublishedAsync(string lang)
        {
            return await _requestProvider.GetAsync<int, List<object>>(_apiSettings.GetCountOfPublishedEndPoint, new List<object> {  lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<PosDto>> GetPublishedBySlugAsync(string slug)
        {
            return await _requestProvider.GetAsync<PosDto, List<object>>(_apiSettings.GetPublishedBySlugEndPoint, new List<object> { slug }, PassParamsBy.Route);
        }
    }
}
