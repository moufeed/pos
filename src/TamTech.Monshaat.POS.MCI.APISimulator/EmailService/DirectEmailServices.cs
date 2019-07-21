using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.MCI.APISimulator.Models;

namespace TamTech.Monshaat.POS.MCI.APISimulator.EmailService
{
    public class DirectEmailServices :IEmailSenderService
    {
        private readonly TamTechBackendSDK.EmailService.Services.IEmailSender _emailSender;
        private readonly EmailFromInfo _settings;


        public DirectEmailServices(
            TamTechBackendSDK.EmailService.Services.IEmailSender emailSender,
            EmailFromInfo settings
            )
        {
            _settings = settings;
            _emailSender = emailSender;
        }


        public async Task<bool> SendAsync(SendEmailModel model)
        {
            var text = "";
            foreach (var item in model.BodyParameters)
            {
                text += $" {item},";
            }
            string template = "";
            switch(model.TemplateCode)
            {
                case "posa-tm_Query":
                    template = "شكراً لاستفسارك";
                    break;     
                case "posa-tm_SYRJT":
                    template = "رفض الطلب";
                    break;     
                case "posa-tm_SYSAp":
                    template = "تم الموافقة على الطلب";
                    break;     
                case "posa-tm_VREJT":
                    template = "رفض طلبك للتسجيل";
                    break;     
                case "posa-tm_VAPPR":
                    template = "تم قبول طلبك للتسجيل";
                    break;
            }
            template = $"{template}   <br />{text}";
            var email = new TamTechBackendSDK.EmailService.Models.EmailModel
            {
                ClientId = "",
                UserId = "",    
                From = _settings.From,
                Html = template,
                ReasonOfSend = "MCI.APISimulator",
                Subject = model.Subject,
                Text = text,
                Recipients =  model.To   ,
                CC = model.CC
            };

            return await _emailSender.SendEmail(email);
        }

      
    }
}
