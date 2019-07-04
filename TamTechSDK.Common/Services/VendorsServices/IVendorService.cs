using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.Shared.Models;
using TamTechSDK.Common.Services.VendorsServices.Models;

namespace TamTechSDK.Common.Services.VendorsServices
{
    public interface IVendorService
    {
        #region Vendors Manager

        #region Get

        Task<PersonDto> GetPersonForCurrentUserAsync(string lang);

        Task<bool> CheckTheCurrentUserIsRegisteredAsVendorAsync();

        

        #endregion

        #region  Create / Edit  

        Task<IRequestProviderResult<Guid>> CreateAsync(CreatePersonModel model);

        Task<IRequestProviderResult<bool>> EditAsync(UpdatePersonModel model);

        Task<IRequestProviderResult<bool>> VerifyVendorSlugIsUnique(string slug, Guid? vendorId = null);

        Task<IRequestProviderResult<GeneratedSlugModel>> VerifyVendorSlugUniqueByNameAsync(string name, Guid? id = null);

        #endregion
        #endregion
    }
}
