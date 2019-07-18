using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.IdentityService.Models;
using TamTech.Monshaat.POS.Web.Core.Enums;

namespace TamTech.Monshaat.POS.IdentityService.Services
{
   public interface ITokenTamService
    {
        Task<TokenModel> GetTokenAsync(GetTokenModel model);

        Task<List<Claim>> GetUserClaimsAsync(string accessToken, PermissionTypeEnum permission);
    }
}
