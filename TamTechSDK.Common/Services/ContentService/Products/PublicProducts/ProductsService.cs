using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Helpers;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Providers.Requests;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Products.Models;
using TamTechSDK.Common.Services.ContentService.Products.Settings;

namespace TamTechSDK.Common.Services.ContentService.Products
{
   public class ProductsService : IProductsService
    {

        #region Props 
        private readonly IRequestProvider _requestProvider;
        private readonly IProductServiceSettings _backendSettings;
        #endregion


        #region Ctors
        public ProductsService(IRequestProvider requestProvider,
                               IProductServiceSettings backendSettings
                               )
        {
            _requestProvider = requestProvider;
            _backendSettings = backendSettings;
        }

        
        #endregion


        #region Services


        #region {Product} Get   

        public async Task<dynamic> GetPublicDynamicListByIdsAsync(IEnumerable<Guid> ids)
        {
            return await _requestProvider.GetAsync<ProductForm, List<Guid>>(_backendSettings.GetPublicDynamicListByIdsAsyncEndpoint, ids.ToList());
        } 

       public async Task<IRequestProviderResult<List<Product>>> GetPublicDynamicListBySKUsAsync(IEnumerable<string> skus)
        {
            return await _requestProvider.GetAsync<List<Product>, List<string>>(_backendSettings.GetPublicDynamicListBySKUsAsyncEndpoint, skus.ToList());
        }  


        public async Task<IRequestProviderResult<Product>> GetPublicDynamicByIdAsync(Guid id)
        {
            return await _requestProvider.GetAsync<Product, List<Guid>>(_backendSettings.GetPublicDynamicByIdAsyncEndpoint, new List<Guid> { id });
        }

       
        public async Task<IRequestProviderResult<ProductForm>> GetByIdAsync(Guid id)
        {
            return await _requestProvider.GetAsync<ProductForm, List<Guid>>(_backendSettings.GetByIdAsyncEndpoint, new List<Guid> { id });
        }
         

        public async Task<IRequestProviderResult<List<Product>>> GetPublicDynamicListByFiltrationAsync(PublicProductFiltrationModel model)
        {
            return await _requestProvider.GetAsync<List<Product>, PublicProductFiltrationModel, PaginationMetadataModel>(
                                        _backendSettings.GetFiltrationAsyncEndpoint, model, Constants.PagenateHeaderName);
        }


        public async Task<IRequestProviderResult<List<Product>>> GetPaginationWithGenericFiltrationAsync(PaginateWithFilterModel model)
        {
            return await _requestProvider.GetAsync<List<Product>, PaginateWithFilterModel, PaginationMetadataModel>(
                                        _backendSettings.GetPaginationWithGenericFiltrationAsyncEndpoint, model, Constants.PagenateHeaderName);
        }
        #endregion

        #endregion
    }
}
