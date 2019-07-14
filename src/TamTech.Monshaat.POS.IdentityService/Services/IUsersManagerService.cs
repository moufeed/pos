//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace TamTech.Monshaat.POS.IdentityService.Services
//{
//    public interface IUsersManagerService
//    {
//        Task<IRequestProviderResult<List<UserModel>>> GetUsersAsync(GetUsersModel model);

//        Task<IRequestProviderResult<UserModel>> GetUserByUsernameAsync(string username);

//        Task<IRequestProviderResult<bool>> RegisterUserAsync(RegisterUserModel data);

//        Task<IRequestProviderResult<bool>> BlockUserAsync(UserNameModel model);

//        Task<IRequestProviderResult<bool>> UnblockUserAsync(UserNameModel model);

//        Task<IRequestProviderResult<bool>> CheckUserAccountIsActivatedAsync(UserNameModel model);
//    }
//}
