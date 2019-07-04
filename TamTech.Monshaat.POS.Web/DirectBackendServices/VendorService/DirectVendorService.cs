using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.ContentService.Services.Persons;
using TamTech.Monshaat.POS.Web.DirectBackendServices.VendorService.Mapper;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.Shared.Models;
using TamTechSDK.Common.Services.VendorsServices;
using TamTechSDK.Common.Services.VendorsServices.Models;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.VendorService
{
    public class DirectVendorService : BaseDirectService, IVendorService
    {
        private readonly IVendorResponsibleManagerService _vendoreService;

        public DirectVendorService(IVendorResponsibleManagerService VendorResponsibleManagerService)
        {
            _vendoreService = VendorResponsibleManagerService;
        }
        public async Task<IRequestProviderResult<Guid>> CreateAsync(CreatePersonModel model)
        {
            var result = await _vendoreService.CreateAsync(model.MapTobackCreatePersonModel());
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<bool>> EditAsync(UpdatePersonModel model)
        {
            var result = await _vendoreService.EditAsync(model.MapTobackUpdatePersonModel());
            return MapRequestProviderResult(result);
        }

        public async Task<PersonDto> GetPersonForCurrentUserAsync(string lang)
        {
            var result = await _vendoreService.GetPersonForCurrentUserAsync(lang);
            return result?.MapToFrontPersonDto();
        }

        public async Task<bool> CheckTheCurrentUserIsRegisteredAsVendorAsync()
        {
            var result = await _vendoreService.CheckTheCurrentUserIsRegisteredAsVendorAsync();
            return result;
        }

        public async Task<IRequestProviderResult<bool>> VerifyVendorSlugIsUnique(string slug, Guid? vendorId = null)
        {
            var result = await _vendoreService.VerifyVendorSlugUniqueAsync(slug, vendorId);
            return MapRequestProviderResult(result);
        }

        public async Task<IRequestProviderResult<GeneratedSlugModel>> VerifyVendorSlugUniqueByNameAsync(string name, Guid? id = null)
        {
            var result = await _vendoreService.VerifyVendorSlugUniqueByNameAsync(name, id);
            var slug = result.Data?.MapToFrontGeneratedSlugModel();
            return ReturnResult(slug, result.Success, MapToHttpStatusCode(result.StatusCode), result.Messages);
        }
    }
}
