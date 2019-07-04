using System.Collections.Generic;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.Identity.Models;
using TamTechSDK.Common.Services.Identity.Models.Params;

namespace TamTechSDK.Common.Services.Identity
{
    public interface IUsersManagerService
    {
        Task<IRequestProviderResult<List<UserModel>>> GetUsersAsync(GetUsersModel model);

        Task<IRequestProviderResult<UserModel>> GetUserByUsernameAsync(string username);

      //  Task<IRequestProviderResult<bool>> DeleteUserByUsernameAsync(string username);

        Task<IRequestProviderResult<bool>> RegisterUserAsync(RegisterUserModel data);

        //Task<bool> RegisterUserAsync(RegisterUserModel data); 

        Task<IRequestProviderResult<bool>> BlockUserAsync(UserNameModel model);

        Task<IRequestProviderResult<bool>> UnblockUserAsync(UserNameModel model);


        Task<IRequestProviderResult<bool>> CheckUserAccountIsActivatedAsync(UserNameModel model);
    }
}
