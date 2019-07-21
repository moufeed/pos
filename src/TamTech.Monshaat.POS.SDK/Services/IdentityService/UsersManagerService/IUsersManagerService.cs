using System.Collections.Generic;
using System.Threading.Tasks;               
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.Identity.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.Identity.Models.Params;

namespace TamTech.Monshaat.POS.Web.SDK.Services.Identity
{
    public interface IUsersManagerService
    {
        Task<IRequestProviderResult<List<UserModel>>> GetUsersAsync(GetUsersModel model);

        Task<IRequestProviderResult<UserModel>> GetUserByUsernameAsync(string username);      

        Task<IRequestProviderResult<bool>> RegisterUserAsync(RegisterUserModel data);  

        Task<IRequestProviderResult<bool>> BlockUserAsync(UserNameModel model);

        Task<IRequestProviderResult<bool>> UnblockUserAsync(UserNameModel model);    

        Task<IRequestProviderResult<bool>> CheckUserAccountIsActivatedAsync(UserNameModel model);
    
        Task<IRequestProviderResult<bool>> AddUserToRolesAsync(AddUserToRolesModel model);
    }
}
    