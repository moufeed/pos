using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;              
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.Identity.Models;    
using TamTech.Monshaat.POS.Web.Services.Identity.Settings;
using TamTech.Monshaat.POS.Web.Services.Identity;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.IdentityService
{
    public class RolesService : BaseAPIService,IRolesService
    {                                     
        private readonly IIdentityBackendSettings _backendSettings;     

        public RolesService(IRequestProvider requestProvider,
                               IIdentityBackendSettings backendSettings
                               ) : base(requestProvider)
        {                
            _backendSettings = backendSettings;
        }




        

        public async Task<IEnumerable<RoleModel>> GetAllAsync()
        {
            var result = await ReqProvider.GetAsync<IEnumerable<RoleModel>>(_backendSettings.GetRolesEndpoint);
            return  GetResult<IEnumerable<RoleModel>>(result);
        }

        public async Task<IEnumerable<RoleModel>> GetUserRolesAsync(string name)
        {
            var result = await ReqProvider.GetAsync<IEnumerable<RoleModel>>(_backendSettings.GetUserRolesEndpoint);
            return GetResult<IEnumerable<RoleModel>>(result);
        }

        public RoleModel GetByName(string name)
        {
            throw new NotImplementedException();
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
