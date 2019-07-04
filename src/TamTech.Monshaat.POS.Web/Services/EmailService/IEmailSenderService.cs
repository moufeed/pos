using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTechSDK.Common.Services.Email.Models;

namespace TamTechSDK.Common.Services.Email
{
    public interface IEmailSenderService
    {
        Task<bool> SendAsync(EmailModel model,
                       string userId = "",
                       string clientId = "",
                       List<string> userRoles = null); 
    }
}
