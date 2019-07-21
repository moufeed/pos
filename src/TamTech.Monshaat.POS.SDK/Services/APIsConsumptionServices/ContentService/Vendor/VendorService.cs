using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Slugs;
using TamTech.Monshaat.POS.Web.SDK.Models.Shared;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Vendor.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Vendors;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Vendors.Models;

namespace TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Vendor
{
    public class VendorService : BaseAPIService, IVendorService
    {
        #region prop        
        private readonly IVendorApiSettings _apiSettings;
        #endregion

        #region ctor
        public VendorService(IRequestProvider requestProvider, IVendorApiSettings apiSettings) : base(requestProvider)
        {         
            _apiSettings = apiSettings;
        }
        #endregion


        public async Task<IRequestProviderResult<PersonDto>> GetPersonForCurrentUserAsync(string lang)
        {
            return await ReqProvider.GetAsync<PersonDto, List<object>>(_apiSettings.GetPersonForCurrentUserEndpoint, new List<object> { lang }, PassParamsBy.Route);
        }


        public async Task<IRequestProviderResult<bool>> CheckTheCurrentUserIsRegisteredAsVendorAsync()
        {
            return await ReqProvider.GetAsync<bool>(_apiSettings.CheckTheCurrentUserIsRegisteredAsVendorEndpoint);
        }

        public async Task<IRequestProviderResult<Guid>> CreateAsync(CreatePersonModel model)
        {
            return await ReqProvider.PostAsync<Guid, CreatePersonModel>(_apiSettings.CreateEndpoint, model);
        }

        public async Task<IRequestProviderResult<bool>> EditAsync(UpdatePersonModel model)
        {
            return await ReqProvider.PostAsync<bool, UpdatePersonModel>(_apiSettings.EditEndpoint, model);
        }

      

        public async Task<IRequestProviderResult<bool>> VerifyCRUniqueAsync(string commercialRegistrationNumber, Guid? vendorId = null)
        {
            return await ReqProvider.GetAsync<bool, List<object>>(_apiSettings.VerifyCRUniqueEndpoint, new List<object> { commercialRegistrationNumber , vendorId }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<bool>> VerifyVendorSlugIsUnique(string slug, Guid? vendorId = null)
        {
            return await ReqProvider.GetAsync<bool, List<object>>(_apiSettings.VerifyVendorSlugIsUnique, new List<object> { slug, vendorId }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<GeneratedSlugModel>> VerifyVendorSlugUniqueByNameAsync(string name, Guid? id = null)
        {
            return await ReqProvider.GetAsync<GeneratedSlugModel, VerifyNameModel<Guid?>>(_apiSettings.VerifyVendorSlugUniqueByNameEndpoint, new VerifyNameModel<Guid?>() { Name = name, Id = id }, PassParamsBy.Body);
        }
    }
}
