using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Providers.Requests;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.Identity.Models;
using TamTechSDK.Common.Services.Identity.Models.Params;
using TamTechSDK.Common.Services.Identity.Settings;

namespace TamTechSDK.Common.Services.Identity
{
    public class RolesService : IRolesService
    {
        private readonly IRequestProvider _requestProvider;
        private readonly IIdentityBackendSettings _backendSettings;
        private string _codeVerifier;

        public RolesService(IRequestProvider requestProvider,
                               IIdentityBackendSettings backendSettings
                               )
        {
            _requestProvider = requestProvider;
            _backendSettings = backendSettings;
        }




        

        public async Task<IEnumerable<RoleModel>> GetAllAsync()
        {
            var result = await _requestProvider.GetAsync<IEnumerable<RoleModel>>(_backendSettings.GetRolesEndpoint);
            return  GetResult<IEnumerable<RoleModel>>(result);
        }

        public TResult GetResult<TResult>(IRequestProviderResult<TResult> model)
        {
            if (model.Success)
            {
                return model.Data;
            }
            else
            {
                // >>>  Loge 
            }
            return default(TResult);
        }


    }
}
