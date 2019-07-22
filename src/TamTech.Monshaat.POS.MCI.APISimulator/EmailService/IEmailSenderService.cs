using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.MCI.APISimulator.Models;

namespace TamTech.Monshaat.POS.MCI.APISimulator.EmailService
{
    public interface IEmailSenderService
    {
        Task<bool> SendAsync(SendEmailModel model );

     


        
    }
}
