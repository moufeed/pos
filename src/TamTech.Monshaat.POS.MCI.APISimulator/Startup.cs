using Microsoft.Extensions.DependencyInjection;    
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;       
using System.Linq;                             
using TamTechBackendSDK.EmailService.Services;   
using TamTechBackendSDK.Common.Services.ApplicationInsightsTelemetry;
using TamTechBackendSDK.Common.Services.ApplicationInsightsTelemetry.Settings;
using TamTech.Monshaat.POS.Web.SDK.Core.Constants;

namespace TamTech.Monshaat.POS.MCI.APISimulator
{
    public static class MCIAPISimulatorStartup
    {
        public static void AddMCIAPISimulatorLibraryConfigurations(this IServiceCollection services,  IConfiguration configuration)
        {
              services.AddScoped<MCIAPISecret>((serviceExtension) =>

            {
              //  string apiSecret = "5c2ea2bd-30ed-47fa-97cd-93027f229f0e";
                string apiSecret = configuration.GetSection(AppSettings.MCIApiSettings)
                                                 .GetSection(AppSettings.ApiKey)
                                                               .Get<string>();
                return new MCIAPISecret( apiSecret);
            });





            if (!services.Any(s => s.ServiceType == typeof(ITelemetryClientService)))
            {
                services.AddTransient<ITelemetryClientService, TelemetryClientService>((serviceExtension) =>
                {
                    TelemetryClientSettings insightsSettings = new TelemetryClientSettings
                    {
                        InstrumentationKey = "a438e18e-7856-4176-935b-04714d363f85"
                    };
                    IHttpContextAccessor httpContextAccessor = serviceExtension.GetRequiredService<IHttpContextAccessor>();
                    return new TelemetryClientService(httpContextAccessor, insightsSettings);
                });
            }

            services.AddTransient<IEmailSender, SendGridEmailSender>(
                (serviceExtension) =>
                {
                    ITelemetryClientService telemetry = serviceExtension.GetService<ITelemetryClientService>();
                    TamTechBackendSDK.EmailService.Settings.SendGridSettings settings =
                    new TamTechBackendSDK.EmailService.Settings.SendGridSettings
                    {
                        ApiKey = "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"
                    };
                    SendGridEmailSender sender = new SendGridEmailSender(telemetry, settings.ApiKey);

                    return sender;
                }

                );


        }

     
   

    }
}
