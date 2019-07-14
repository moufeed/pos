using System.Collections.Generic;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.Identity.Models;
using TamTech.Monshaat.POS.Web.Services.Identity.Models.Params;

namespace TamTech.Monshaat.POS.Web.Services.Identity
{
    public interface IRolesService
    {
         

        Task<IEnumerable<RoleModel>> GetAllAsync();


        Task<IEnumerable<RoleModel>> GetUserRolesAsync(string name);

    }
}
