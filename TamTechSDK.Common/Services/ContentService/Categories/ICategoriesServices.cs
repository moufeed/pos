using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Categories.Models;

namespace TamTechSDK.Common.Services.ContentService.Categories
{
    public interface ICategoriesServices
    {


        #region {Public Categories}   

        Task<dynamic> GetPublicDynamicListAsync();
            
        #endregion



        #region {Categories Manager}   

        Task<IRequestProviderResult<Guid>> CreateAsync(Category model);
        Task<IRequestProviderResult<List<Category>>> GetAsync(string lang);
        Task<IRequestProviderResult<List<Category>>>  GetCategoriesAsync();
        Task<IRequestProviderResult<Category>> GetCategoryByIdAsync(string id);
        Task<IRequestProviderResult<object>> DeleteCategoryByIdAsync(string id);

        #endregion
    }
}
