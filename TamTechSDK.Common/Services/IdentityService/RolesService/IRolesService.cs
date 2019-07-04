using System.Collections.Generic;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.Identity.Models;
using TamTechSDK.Common.Services.Identity.Models.Params;

namespace TamTechSDK.Common.Services.Identity
{
    public interface IRolesService
    {
         

        Task<IEnumerable<RoleModel>> GetAllAsync(); 
         
    }
}
