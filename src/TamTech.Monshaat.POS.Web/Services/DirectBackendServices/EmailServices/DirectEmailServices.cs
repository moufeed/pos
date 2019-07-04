using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Settings.Utilities;
using TamTechBackendSDK.Common.Services.ServiceBus;
using TamTechBackendSDK.Common.Services.ServiceBus.Models;

using TamTech.Monshaat.POS.Web.Services.Email.Models;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.EmailServices
{
    public class DirectEmailServices : TamTech.Monshaat.POS.Web.Services.Email.IEmailSenderService
    {
        private readonly TamTechBackendSDK.EmailService.Services.IEmailSender _emailSender;
        private readonly SettingsHelpers _settingsHelpers;


        public DirectEmailServices(
            TamTechBackendSDK.EmailService.Services.IEmailSender emailSender,
            SettingsHelpers settingsHelpers
            )
        {
            _settingsHelpers = settingsHelpers;
            _emailSender = emailSender;
        }


        public async Task<bool> SendAsync(EmailModel model,
                                    string userId = "",
                                    string clientId = "",
                                    List<string> userRoles = null)
        {

            var setting = await _settingsHelpers.GetEmailSettingsAsync();
            var email = new TamTechBackendSDK.EmailService.Models.EmailModel
            {
                ClientId = clientId,
                UserId = userId,
                UserRoles = userRoles,
                From = setting.From,
                Html = model.HtmlMessage,
                ReasonOfSend = model.ReasonOfSend,
                Subject = model.Subject,
                Text = model.Message,
                Recipients = new List<string> { model.Email },
                CC = setting.CC
            };

            return await _emailSender.SendEmail(email);
        }
    }
}
