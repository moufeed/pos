using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Brands.Models;

namespace TamTechSDK.Common.Services.ContentService.Brands
{
    public interface IBrandsServices
    {


        #region {Public Brands}   

        Task<dynamic> GetPublicDynamicListAsync();

        #endregion


        #region {Brands Manager}   
        Task<IRequestProviderResult<Guid>> CreateAsync(Brand model);
        Task<IRequestProviderResult<List<Brand>>> GetAsync(string lang);
        Task<IRequestProviderResult<List<Brand>>> GetBrandsListAsync();
        Task<IRequestProviderResult<Brand>> GetBrandByIdAsync(string id);
        Task<IRequestProviderResult<object>> DeleteBrandByIdAsync(string id);
        #endregion
    }
}
