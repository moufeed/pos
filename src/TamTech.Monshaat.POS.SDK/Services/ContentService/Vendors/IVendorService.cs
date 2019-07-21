using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Slugs;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Vendors.Models;

namespace TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Vendors
{
    public interface IVendorService
    {
        #region Vendors Manager

        #region Get

        Task<IRequestProviderResult<PersonDto>> GetPersonForCurrentUserAsync(string lang);

        Task<IRequestProviderResult<bool>> CheckTheCurrentUserIsRegisteredAsVendorAsync();

        

        #endregion

        #region  Create / Edit  

        Task<IRequestProviderResult<Guid>> CreateAsync(CreatePersonModel model);

        Task<IRequestProviderResult<bool>> EditAsync(UpdatePersonModel model);

        Task<IRequestProviderResult<bool>> VerifyVendorSlugIsUnique(string slug, Guid? vendorId = null);

        Task<IRequestProviderResult<GeneratedSlugModel>> VerifyVendorSlugUniqueByNameAsync(string name, Guid? id = null);

        Task<IRequestProviderResult<bool>> VerifyCRUniqueAsync(string commercialRegistrationNumber, Guid? vendorId = null);
        #endregion
        #endregion
    }
}
