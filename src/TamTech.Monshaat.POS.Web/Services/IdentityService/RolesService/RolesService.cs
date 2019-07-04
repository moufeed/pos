using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.Identity.Models;
using TamTech.Monshaat.POS.Web.Services.Identity.Models.Params;
using TamTech.Monshaat.POS.Web.Services.Identity.Settings;

namespace TamTech.Monshaat.POS.Web.Services.Identity
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
