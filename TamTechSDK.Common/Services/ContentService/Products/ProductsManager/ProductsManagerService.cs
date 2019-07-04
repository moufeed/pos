using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Helpers;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Providers.Requests;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Products.Models;
using TamTechSDK.Common.Services.ContentService.Products.Settings;

namespace TamTechSDK.Common.Services.ContentService.Products
{
    public class ProductsManagerService : IProductsManagerService
    {

        #region Props 
        private readonly IRequestProvider _requestProvider;
        private readonly IProductManagerServiceSettings _backendSettings;
        #endregion


        #region Ctors
        public ProductsManagerService(IRequestProvider requestProvider,
                               IProductManagerServiceSettings backendSettings
                               )
        {
            _requestProvider = requestProvider;
            _backendSettings = backendSettings;
        }
        #endregion


        #region Services

        #region {Product} Get / Create / Edit / Delete

        //TODO: Language parameter isn't used yet
        public async Task<IRequestProviderResult<List<Product>>> GetAllAsync(string lang)
        {
            return await _requestProvider.GetAsync<List<Product>>(_backendSettings.GetAllAsyncEndpoint);
        } 

        public async Task<IRequestProviderResult<List<Product>>> GetAsync(PagingParameterModel model)
        {
            return await _requestProvider.GetAsync<List<Product>, PagingParameterModel, PaginationMetadataModel>(
                                        _backendSettings.GetAsyncEndpoint, model, Constants.PagenateHeaderName);
        }

        public Task<IRequestProviderResult<List<Product>>> GetAllAsync(PaginationModel pagination, Dictionary<string, object> searchParams, SortingModel sorting, string lang)
        {
            throw new NotImplementedException();
        }

        //TODO: Language parameter isn't used yet
        public async Task<IRequestProviderResult<ProductForm>> GetByIdAsync(Guid id, string lang)
        {
            return await _requestProvider.GetAsync<ProductForm, List<Guid>>(_backendSettings.GetByIdAsyncEndpoint, new List<Guid> { id });
        }

        public async Task<IRequestProviderResult<Guid>> CreateAsync(ProductForm model)
        {
            return await _requestProvider.PostAsync<Guid, ProductForm>(_backendSettings.CreateAsyncEndpoint, model);

        } 

        public async Task<IRequestProviderResult<bool>> EditAsync(ProductForm model)
        {
            return await _requestProvider.PostAsync<bool, ProductForm>(_backendSettings.EditAsyncEndpoint, model);

        } 

        public async Task<IRequestProviderResult<bool>> PublishAsync(PublishDto model)
        {


            return await _requestProvider.PostAsync<bool, string>(_backendSettings.PublishAsyncEndpoint, "", new List<string> { model.Id.ToString() });

        }

        public async Task<IRequestProviderResult<bool>> DeleteAsync(Guid id)
        {
            return await _requestProvider.PostAsync<bool, string>(_backendSettings.DeleteAsyncEndpoint,"",  new List<string> { id.ToString() });

        }

        #endregion



        #region {Product Combination} Get / Create / Edit / Delete 

        //TODO: Language parameter isn't used yet
        public async Task<IRequestProviderResult<List<ProductCombination>>> GetProductCombinationsAsync(Guid productId, string lang)
        {
            return await _requestProvider.GetAsync<List<ProductCombination>, List<Guid>>(_backendSettings.GetProductCombinationsAsyncEndpoint, new List<Guid> { productId });
        }


        public async Task<IRequestProviderResult<CombinationResultModel>> CreateProductCombinationAsync(ProductCombinationForm model)
        {
            return await _requestProvider.PostAsync<CombinationResultModel, ProductCombinationForm>(_backendSettings.CreateProductCombinationAsyncEndpoint, model);

        }

        public async Task<IRequestProviderResult<bool>> PublishProductCombinationAsync(ProductCombinationKeys model)
        {
            return await _requestProvider.PostAsync<bool, ProductCombinationKeys>( _backendSettings.PublishProductCombinationAsyncEndpoint, model);
        }

        public async Task<IRequestProviderResult<bool>> DeleteProductCombinationAsync(ProductCombinationKeys model)
        {
            return await _requestProvider.PostAsync<bool, ProductCombinationKeys>(_backendSettings.DeleteProductCombinationAsyncEndpoint, model);
        }

        #endregion



        #region {Product Attribute} Get / Create / Edit / Delete.

        //TODO: Language parameter isn't used yet
        public async Task<IRequestProviderResult<List<ProductAttribute>>> GetProductAttributesAsync(Guid productId, string lang)
        {
            return await _requestProvider.GetAsync<List<ProductAttribute>, List<Guid>>(_backendSettings.GetProductAttributesAsyncEndpoint, new List<Guid> { productId });
        }

        public async Task<IRequestProviderResult<bool>> CreateProductAttributeAsync(ProductAttributeForm model)
        {
            return await _requestProvider.PostAsync<bool, ProductAttributeForm>(_backendSettings.CreateProductAttributeAsyncEndpoint, model);

        }

        public async Task<IRequestProviderResult<bool>> EditProductAttributeAsync(ProductAttributeEditing model)
        {
            model.ReturnProductCombinations = false;
            return await _requestProvider.PostAsync<bool, ProductAttributeEditing>(_backendSettings.EditProductAttributeAsyncEndpoint, model);

        } 

        public async Task<IRequestProviderResult<List<ProductCombination>>> EditProductAttributeAndGetCompinationsAsync(ProductAttributeEditing model)
        {
            model.ReturnProductCombinations = true;
            return await _requestProvider.PostAsync<List<ProductCombination>, ProductAttributeEditing>(_backendSettings.EditProductAttributeAsyncEndpoint, model); 
        } 

        public async Task<IRequestProviderResult<bool>> DeleteProductAttributeAsync(ProductAttributeKeys model)
        {
            return await _requestProvider.PostAsync<bool, ProductAttributeKeys>(_backendSettings.DeleteProductAttributeAsyncEndpoint, model);
        }
        #endregion



        #region {Product Attribute Value} Get / Create / Edit / Delete
        public async Task<IRequestProviderResult<bool>> CreateProductAttributeValueAsync(ProductAttributeValueForm model)
        {
            return await _requestProvider.PostAsync<bool, ProductAttributeValueForm>(_backendSettings.CreateProductAttributeValueAsyncEndpoint, model); 
        }

        public async Task<IRequestProviderResult<bool>> EditProductAttributeValueAsync(ProductAttributeValueEditing model)
        {
            model.ReturnProductCombinations = false;
            return await _requestProvider.PostAsync<bool, ProductAttributeValueEditing>(_backendSettings.EditProductAttributeValueAsyncEndpoint, model); 
        }

        public async Task<IRequestProviderResult<List<ProductCombination>>> EditProductAttributeValueAndGetCompinationsAsync(ProductAttributeValueEditing model)
        {
            model.ReturnProductCombinations = true;
            return await _requestProvider.PostAsync<List<ProductCombination>, ProductAttributeValueEditing>(_backendSettings.EditProductAttributeValueAsyncEndpoint, model);
        } 

        public async Task<IRequestProviderResult<bool>> DeleteProductAttributeValueAsync(ProductAttributeValueKeys model)
        { 
            return await _requestProvider.PostAsync<bool, ProductAttributeValueKeys>(_backendSettings.DeleteProductAttributeValueAsyncEndpoint, model);
        }



        #endregion



        #region {Product Images}  Delete 
        public async Task<IRequestProviderResult<bool>> DeleteProductImagesValueAsync(ProductImagesModel model)
        {
            return await _requestProvider.PostAsync<bool, ProductImagesModel>(_backendSettings.DeleteProductImagesAsyncEndpoint, model);
        }

        
        #endregion






        #endregion
    }
}
