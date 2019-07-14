using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.IdentityService.Models;

namespace TamTech.Monshaat.POS.IdentityService.Services
{
   public interface IAuthTamService
    {
        Task<AuthTamResultModel> LoginAsync(LoginTamModel model);
    }
}
