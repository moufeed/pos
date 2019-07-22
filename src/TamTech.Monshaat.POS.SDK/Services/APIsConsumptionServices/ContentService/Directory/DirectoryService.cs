using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Slugs;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Directory.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.POSs.Directory;
using TamTech.Monshaat.POS.Web.SDK.Services.POSs.Directory.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.POSs.Models;

namespace TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Directory
{
    public class DirectoryService : BaseAPIService, IDirectoryServices
    {

        #region prop                    
        private readonly IDirectoryApiSettings  _apiSettings;
        #endregion

        #region ctor
        public DirectoryService(IRequestProvider requestProvider, IDirectoryApiSettings apiSettings) : base(requestProvider)
        {             
            _apiSettings = apiSettings;
        }
        #endregion

        public async Task<IRequestProviderResult<PagedResultModel<List<PosDto>>>> FindAsync(PosFilters model)
        {
            return await ReqProvider.GetAsync<PagedResultModel<List<PosDto>>, PosFilters>(_apiSettings.FindEndPoint, model, PassParamsBy.Body);
        }

        public async Task<IRequestProviderResult<List<SlugModel>>> GetAllPublishedSlugsAsync()
        {
            return await ReqProvider.GetAsync<List<SlugModel>>(_apiSettings.GetAllPublishedSlugsEndPoint);
        }

        public async Task<IRequestProviderResult<int>> GetCountOfPublishedAsync(string lang)
        {
            return await ReqProvider.GetAsync<int, List<object>>(_apiSettings.GetCountOfPublishedEndPoint, new List<object> {  lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<PosDto>> GetPublishedBySlugAsync(string slug)
        {
            return await ReqProvider.GetAsync<PosDto, List<object>>(_apiSettings.GetPublishedBySlugEndPoint, new List<object> { slug }, PassParamsBy.Route);
        }
    }
}
