using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Products.Models;

namespace TamTechSDK.Common.Services.ContentService.Products
{
   public interface IProductsManagerService
    {
        Task<IRequestProviderResult<Guid>> CreateAsync(ProductForm model);

        Task<IRequestProviderResult<bool>> EditAsync(ProductForm model);

        Task<IRequestProviderResult<List<Product>>> GetAllAsync(string lang);

        Task<IRequestProviderResult<List<Product>>> GetAllAsync(PaginationModel pagination, Dictionary<string, object> searchParams, SortingModel sorting, string lang);

        Task<IRequestProviderResult<List<Product>>> GetAsync(PagingParameterModel model);

        Task<IRequestProviderResult<ProductForm>> GetByIdAsync(Guid id, string lang);

        Task<IRequestProviderResult<bool>> PublishAsync(PublishDto id); 

        Task<IRequestProviderResult<bool>> DeleteAsync(Guid id);



        Task<IRequestProviderResult<List<ProductCombination>>> GetProductCombinationsAsync(Guid productId, string lang);

        Task<IRequestProviderResult<CombinationResultModel>> CreateProductCombinationAsync(ProductCombinationForm model);

        Task<IRequestProviderResult<bool>> PublishProductCombinationAsync(ProductCombinationKeys model);

        Task<IRequestProviderResult<bool>> DeleteProductCombinationAsync(ProductCombinationKeys model);





        Task<IRequestProviderResult<List<ProductAttribute>>> GetProductAttributesAsync(Guid productId, string lang);

        Task<IRequestProviderResult<bool>> CreateProductAttributeAsync(ProductAttributeForm model);

        Task<IRequestProviderResult<bool>> EditProductAttributeAsync(ProductAttributeEditing model); 

        Task<IRequestProviderResult<List<ProductCombination>>> EditProductAttributeAndGetCompinationsAsync(ProductAttributeEditing model);

        Task<IRequestProviderResult<bool>> DeleteProductAttributeAsync(ProductAttributeKeys model);







         Task<IRequestProviderResult<bool>> CreateProductAttributeValueAsync(ProductAttributeValueForm model);

        Task<IRequestProviderResult<bool>> EditProductAttributeValueAsync(ProductAttributeValueEditing model);

        Task<IRequestProviderResult<List<ProductCombination>>> EditProductAttributeValueAndGetCompinationsAsync(ProductAttributeValueEditing model);

        Task<IRequestProviderResult<bool>> DeleteProductAttributeValueAsync(ProductAttributeValueKeys model);




        Task<IRequestProviderResult<bool>> DeleteProductImagesValueAsync(ProductImagesModel model);






        //Task<IRequestProviderResult<List<ProductLite>>> GetProductsAsync();

       

        


        

    }
}
