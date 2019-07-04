using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Categories.Models;
using TamTechSDK.Common.Services.ContentService.Categories.Settings;

namespace TamTechSDK.Common.Services.ContentService.Categories
{
    public class CategoriesServices : CommonBaseService, ICategoriesServices
    {
        #region Props 
        private readonly IRequestProvider _requestProvider;
        private readonly ICategoryServiceSettings _backendSettings;
        #endregion


        #region Ctors
        public CategoriesServices(IRequestProvider requestProvider,
                               ICategoryServiceSettings backendSettings
                               )
        {
            _requestProvider = requestProvider;
            _backendSettings = backendSettings;
        }
        #endregion


        #region Services 

        #region {Public Categories}   

        public async Task<dynamic> GetPublicDynamicListAsync()
        {
            return GetDataResult(await _requestProvider.GetAsync<dynamic>(_backendSettings.GetPublicDynamicListAsyncEndpoint));
        }


        #endregion



        #region {Categories Manager}   
        public async Task<IRequestProviderResult<Guid>> CreateAsync(Category model)
        {
            return await _requestProvider.PostAsync<Guid, Category>(_backendSettings.CreateAsyncEndpoint, model);

        }
        public async Task<IRequestProviderResult<List<Category>>> GetAsync(string lang)
        {
            return await _requestProvider.GetAsync<List<Category>>(_backendSettings.GetAsyncEndpoint);
        }




        public async  Task<IRequestProviderResult<object>> DeleteCategoryByIdAsync(string id)
        {
            return new RequestProviderResult<object>
            {
                Success = true
            };
        }


        public async Task<IRequestProviderResult<List<Category>> > GetCategoriesAsync()
        {
            throw new Exception("GetCategoriesAsync not found!");
        }

        public async  Task<IRequestProviderResult<Category>> GetCategoryByIdAsync(string id)
        {
            throw new Exception("GetCategoryByIdAsync not found!");
        }
        #endregion


        #endregion
    }
}
