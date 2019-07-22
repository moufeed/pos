using System.Collections.Generic;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.Identity.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.Identity.Models.Params;

namespace TamTech.Monshaat.POS.Web.SDK.Services.Identity
{
    public interface IRolesService
    {
         

        Task<IEnumerable<RoleModel>> GetAllAsync();


        Task<IEnumerable<RoleModel>> GetUserRolesAsync(string name);

    }
}
