using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Brands.Models;
using TamTechSDK.Common.Services.ContentService.Brands.Settings;

namespace TamTechSDK.Common.Services.ContentService.Brands
{
    public class BrandsServices : CommonBaseService,  IBrandsServices
    {
        #region Props 
        private readonly IRequestProvider _requestProvider;
        private readonly IBrandServiceSettings _backendSettings;
        #endregion


        #region Ctors
        public BrandsServices(IRequestProvider requestProvider,
                               IBrandServiceSettings backendSettings
                               )
        {
            _requestProvider = requestProvider;
            _backendSettings = backendSettings;
        }
        #endregion


        #region Services



        #region {Public Brands}   

        public async Task<dynamic> GetPublicDynamicListAsync()
        {
            return GetDataResult(await _requestProvider.GetAsync<dynamic>(_backendSettings.GetPublicDynamicListAsyncEndpoint));
        }


        #endregion



        #region {Brands Manager}   
        public async Task<IRequestProviderResult<Guid>> CreateAsync(Brand model)
        {
            return await _requestProvider.PostAsync<Guid, Brand>(_backendSettings.CreateAsyncEndpoint, model);

        }
        public async Task<IRequestProviderResult<List<Brand>>> GetAsync( string lang)
        {
            return await _requestProvider.GetAsync<List<Brand>>(_backendSettings.GetAsyncEndpoint);
        }

        public async Task<IRequestProviderResult<object>> DeleteBrandByIdAsync(string id)
        {
            return new RequestProviderResult<object>
            {
                Success = true
            };
        }

        public async  Task<IRequestProviderResult<Brand>> GetBrandByIdAsync(string id)
        {
            throw new Exception("GetBrandByIdAsync not found!");
        }

        public async  Task<IRequestProviderResult<List<Brand>>> GetBrandsListAsync()
        {
            throw new Exception("GetBrandsListAsync not found!");
        }

        #endregion
        #endregion
    }
}
