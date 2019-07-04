using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Services.Email.Models;

namespace TamTech.Monshaat.POS.Web.Services.Email
{
    public interface IEmailSenderService
    {
        Task<bool> SendAsync(EmailModel model,
                       string userId = "",
                       string clientId = "",
                       List<string> userRoles = null); 
    }
}
