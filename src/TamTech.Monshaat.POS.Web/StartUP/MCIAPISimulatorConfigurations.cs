using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Collections.Generic;  
using TamTech.Monshaat.POS.MCI.APISimulator;
using TamTech.Monshaat.POS.MCI.APISimulator.EmailService;
using TamTech.Monshaat.POS.Web.SDK.Core.Enums;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Settings;
using TamTechBackendSDK.EmailService.Services;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class MCIAPISimulatorConfigurations
    {
        public static void AddMCIAPISimulatorConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMCIAPISimulatorLibraryConfigurations(configuration);

            services.AddTransient<IEmailSenderService>((serviceExtension) =>
            {
                var settingService = serviceExtension.GetService<ISettingService>();
                var emailSender = serviceExtension.GetService<IEmailSender>();
                var settings = settingService.GetEnabledListBySharedKeysAsync(
                        new List<string> { SettingSharedKeysEnum.Email.ToString(),
                                           SettingSharedKeysEnum.Email_CC.ToString()
                                         }).GetAwaiter().GetResult();
                EmailFromInfo model = new EmailFromInfo
                {
                    From = settings.Data.FirstOrDefault(e => e.Key == SettingKeysEnum.Email_From.ToString())?.Value,
                    FromName = settings.Data.FirstOrDefault(e => e.Key == SettingKeysEnum.Email_FromName.ToString())?.Value,
                    CC = settings.Data.Where(e => e.SharedKey == SettingSharedKeysEnum.Email_CC.ToString())?.Select(c => c.Value)?.ToList(),
                };
                return new DirectEmailServices(emailSender, model);
            });



        }

    }
}
