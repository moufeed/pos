using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Products.Models;

namespace TamTechSDK.Common.Services.ContentService.Products
{
   public interface IProductsService
    {
        Task<dynamic> GetPublicDynamicListByIdsAsync(IEnumerable<Guid> ids);

        Task<IRequestProviderResult<List<Product>>> GetPublicDynamicListBySKUsAsync(IEnumerable<string> skus);

        Task<IRequestProviderResult<Product>> GetPublicDynamicByIdAsync(Guid id);

        Task<IRequestProviderResult<ProductForm>> GetByIdAsync(Guid id);

        Task<IRequestProviderResult<List<Product>>> GetPublicDynamicListByFiltrationAsync(PublicProductFiltrationModel model);

        Task<IRequestProviderResult<List<Product>>> GetPaginationWithGenericFiltrationAsync(PaginateWithFilterModel model);
    }
}
