using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.IdentityService.RolesService.Mapper
{
    public static class RoleMapper
    {
        public static TamTechSDK.Common.Services.Identity.Models.RoleModel MapToFrontendModel(this TamTechBackendSDK.IdentityService.Services.RolesService.Dtos.RoleDto backend)
        {
            return new TamTechSDK.Common.Services.Identity.Models.RoleModel
            {
                Id = backend.Id,
                Name = backend.Name
            };
        }
    }
}
