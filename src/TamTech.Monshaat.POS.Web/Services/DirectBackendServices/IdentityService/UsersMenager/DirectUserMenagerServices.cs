using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.DirectBackendServices.IdentityService.UsersMenager.Mapper;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.Identity;
using TamTech.Monshaat.POS.Web.Services.Identity.Models;
using TamTech.Monshaat.POS.Web.Services.Identity.Models.Params;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.IdentityService.UsersMenager
{
    public class DirectUserMenagerServices : BaseDirectService, TamTech.Monshaat.POS.Web.Services.Identity.IUsersManagerService
    {

        #region Props  
        private readonly TamTechBackendSDK.IdentityService.Services.IUserManagerService _userManagerService;
        private readonly TamTechBackendSDK.IdentityService.Services.IRoleService _roleService;
        #endregion


        #region Ctors
        public DirectUserMenagerServices(
            TamTechBackendSDK.IdentityService.Services.IUserManagerService userManagerService,
            TamTechBackendSDK.IdentityService.Services.IRoleService roleService
            )
        {
            _userManagerService = userManagerService;
            _roleService = roleService;

        }
        #endregion

        #region Utilities


        private IRequestProviderResult<TResult> GetRequestProviderResult<TResult>(TResult data, PaginationMetadataModel header)
        {
            IRequestProviderResult<TResult> _resultModel = new RequestProviderResult<TResult>();
            _resultModel.Success = true;
            _resultModel.StatusCode = System.Net.HttpStatusCode.OK;
            _resultModel.Data = data;
            _resultModel.Header = header;
            return _resultModel;
        }


        #endregion

        #region Services





        public async Task<IRequestProviderResult<UserModel>> GetUserByUsernameAsync(string username)
        {
            var result = _userManagerService.GetByUserName(username);
            UserModel user = result != null ? result.MapToFrontendModel() : new UserModel();
            return ReturnResult(user);
        }

        public async Task<IRequestProviderResult<List<UserModel>>> GetUsersAsync(GetUsersModel model)
        {
            var result = _userManagerService.GetAll(model.MapToBackendModel());
            var users = result.Users != null ? result.Users.Select(m => m.MapToFrontendModel()).ToList() : new List<UserModel>();
            TamTech.Monshaat.POS.Web.Models.Dtos.Pagination.PaginationMetadataModel p = result.PaginateMetaData.MapToFrontendModel();
            return GetRequestProviderResult(users, p);
        }

        public async Task<IRequestProviderResult<bool>> RegisterUserAsync(RegisterUserModel model)
        {
            var result = await _userManagerService.RegisterAsync(model.MapToBackendModel());
            return MapRequestProviderResult<bool>(result);
        }

        public async Task<IRequestProviderResult<bool>> BlockUserAsync(UserNameModel model)
        {
            var result = _userManagerService.BlockUserAccount(model.UserName);
            return MapRequestProviderResult<bool>(result);
        }

        public async Task<IRequestProviderResult<bool>> UnblockUserAsync(UserNameModel model)
        {
            var result = _userManagerService.UnblockUserAccount(model.UserName);
            return MapRequestProviderResult<bool>(result);
        }


        public async Task<IRequestProviderResult<bool>> CheckUserAccountIsActivatedAsync(UserNameModel model)
        {
            var result = await _userManagerService.CheckUserAccountIsActivatedAsync<bool>(model.UserName);
            return MapRequestProviderResult<bool>(result);
        }
        #endregion

    }
}
