using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.Identity.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.Identity.Models.Params;
using TamTech.Monshaat.POS.Web.SDK.Services.Identity.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.Identity;

namespace TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.IdentityService
{
    public class UsersManagerService : BaseAPIService,  IUsersManagerService
    {                                                
        private readonly IIdentityBackendSettings _backendSettings;    

        public UsersManagerService (IRequestProvider requestProvider,
                               IIdentityBackendSettings backendSettings
                               ) : base(requestProvider)
        {            
            _backendSettings = backendSettings;
        }




        public async Task<IRequestProviderResult<List<UserModel>>> GetUsersAsync(GetUsersModel model)
        { 
            return await ReqProvider.GetAsync<List<UserModel>, GetUsersModel, PaginationMetadataModel>(
                                        _backendSettings.GetUsersEndpoint, model, "Paging-Header" );
        }

        public async Task<IRequestProviderResult<UserModel>> GetUserByUsernameAsync(string username)
        {
            return await ReqProvider.GetAsync<UserModel, List<string>>(
                        _backendSettings.GetUserByUserNameEndpoint, new List<string> { username}, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<bool>> RegisterUserAsync(RegisterUserModel data)
        {
            return await ReqProvider.PostAsync<bool, RegisterUserModel>( _backendSettings.RegisterUserAsyncEndpoint, data);
            
        }

        public async Task<IRequestProviderResult<bool>> BlockUserAsync(UserNameModel model)
        {
            return await ReqProvider.PostAsync<bool, UserNameModel>(_backendSettings.BlockUserAsyncEndpoint, model);
        }

        public async Task<IRequestProviderResult<bool>> UnblockUserAsync(UserNameModel model)
        {
            return await ReqProvider.PostAsync<bool, UserNameModel>(_backendSettings.UnblockUserAsyncEndpoint, model);
        }

        public async Task<IRequestProviderResult<List<RoleModel>>> _GetRolesAsync()
        {
            return await ReqProvider.GetAsync<List<RoleModel>>(_backendSettings.GetRolesEndpoint);
        }

        public async Task<IEnumerable<RoleModel>> GetRolesAsync()
        {
            var result = await ReqProvider.GetAsync<IEnumerable<RoleModel>>(_backendSettings.GetRolesEndpoint);
            return  GetResult<IEnumerable<RoleModel>>(result);
        }

        public async Task<IRequestProviderResult<bool>> CheckUserAccountIsActivatedAsync(UserNameModel model)
        {
            return await ReqProvider.GetAsync<bool, List<string>>(_backendSettings.CheckUserAccountIsActivatedEndpoint, new List<string> { model.UserName }, PassParamsBy.Route);
        }

       
        public async Task<IRequestProviderResult<bool>> AddUserToRolesAsync(AddUserToRolesModel model)
        {
            return await ReqProvider.PostAsync<bool, AddUserToRolesModel>(_backendSettings.AddUserToRolesEndpoint, model);
        }

        public TResult GetResult<TResult>(IRequestProviderResult<TResult> model)
        {
            if(model.Success)
            {
                return  model.Data;
            }
            else 
            {
                // >>>  Loge 
            } 
            return default(TResult);
        }
       

 

        


    }
}
