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
using TamTech.Monshaat.POS.Web.Services.APIsServices.Types.Settings;
using TamTech.Monshaat.POS.Web.Services.ContentService.Types;
using TamTech.Monshaat.POS.Web.Services.ContentService.Types.Models;

namespace TamTech.Monshaat.POS.Web.Services.APIsServices.Types
{
    public   class TypeService : BaseAPIService, ITypeService , IPosTypeService , IContactTypeService
    {

        #region Props 
        private readonly IRequestProvider _requestProvider;

        private readonly ITypeApiSettings _apiSettings;
        #endregion


        #region Ctors
        public TypeService(IRequestProvider requestProvider, ITypeApiSettings apiSettings)
            :base(requestProvider)
        {
            _requestProvider = requestProvider;
            _apiSettings = apiSettings;
        }
        #endregion


        #region Published

        public async Task<IRequestProviderResult<TypeDto>> GetPublishedBySlugAsync(string slug)
        {
            return await _requestProvider.GetAsync<TypeDto, List<string>>(_apiSettings.GetPublishedBySlugEndpoint, new List<string> { slug });
             
        }

        public async Task<IRequestProviderResult<List<TypeDto>>> GetPublishedListAsync(bool sortManually = true)
        {
            return await _requestProvider.GetAsync<List<TypeDto>, List<object>>(_apiSettings.GetPublishedListEndpoint, new List<object> { sortManually });
            
        }

        public async Task<IRequestProviderResult<List<TypeDto>>> GetPublishedListAsync(int takeItems, bool sortManually = true)
        {
            return await _requestProvider.GetAsync<List<TypeDto>, List<object>>(_apiSettings.GetPublishedLimitedListEndpoint, new List<object> { takeItems, sortManually });
            
        }

             #endregion



        public async Task<IRequestProviderResult<int>> CreateAsync(CreateTypeModel model)
        {
            throw new NotImplementedException();
        }

        public  async Task<IRequestProviderResult<bool>> EditAsync(UpdateTypeModel model)
        {
            throw new NotImplementedException();
        }

        public  async Task<List<TypeDto>> GetAllExceptSoftDeletedAsync(string lang)
        {
            throw new NotImplementedException();
        }

        public  async Task<List<SelectListItemModel>> GetAllSelectListAsync(string lang)
        {
            throw new NotImplementedException();
        }

        public  async Task<TypeDto> GetByIdExceptSoftDeletedAsync(int id, string lang)
        {
            throw new NotImplementedException();
        }

        public  async Task<PagedResultModel<List<TypeDto>>> GetExceptSoftDeletedAsync(DTFilter model)
        {
            throw new NotImplementedException();
        }


        public  async Task<List<SelectListItemModel>> GetSelectListAsync(string lang, bool isOfficial = true)
        {
            throw new NotImplementedException();
        }

        public  async Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO model)
        {
            throw new NotImplementedException();
        }

        public  async Task<IRequestProviderResult<bool>> SoftDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
