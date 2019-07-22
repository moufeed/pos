using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.SDK.Services.ExternalServices.Authentications.Models;

namespace TamTech.Monshaat.POS.SDK.Services.ExternalServices.Authentications
{
   public interface IExternalAuthService
    {
        Task<ExternalAuthResultModel> LoginAsync(ExternalLoginModel model);
    }
}
