using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TamTech.Monshaat.POS.MCI.Services.Services;
using TamTech.Monshaat.POS.MCI.Services.Settings;
using TamTech.Monshaat.POS.SDK.Services.ExternalServices.Authentications;
using TamTech.Monshaat.POS.Services.ExternalServices.CommercialRegister;
using TamTech.Monshaat.POS.Web.SDK.Core.Constants;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.SDK.Models.Shared;
using TamTech.Monshaat.POS.Web.SDK.Services.Email;

namespace TamTech.Monshaat.POS.MCI.Services
{
    public static class MCIServicesStartup
    {
        public static void AddMCIServicesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            bool enableFakeApiForTesting = configuration.GetSection(AppSettings.MCIApiSettings)
                                                          .GetSection(AppSettings.EnableFakeApiForTesting)
                                                                        .Get<bool>();
            if (enableFakeApiForTesting)
            {
                services.AddScoped<IMCIApiSettings>((serviceExtension) =>
                {
                    IHttpContextAccessor httpContextAccessor = serviceExtension.GetRequiredService<IHttpContextAccessor>();
                    //BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
                    return new MCIApiSimulatorSettings(httpContextAccessor, null);
                });
            }
            else
            {
                services.AddScoped<IMCIApiSettings>((serviceExtension) =>
                {
                    string apiUrl = configuration.GetSection(AppSettings.MCIApiSettings)
                                                     .GetSection(AppSettings.Url)
                                                                   .Get<string>();
                    return new MCIApiSettings(apiUrl);
                });
            }

            services.AddTransient<IMCIServices>((serviceExtension) =>
            {
                IRequestProvider provider = serviceExtension.GetRequiredService<IRequestProvider>();
                ILogger<MCIServices> logger = serviceExtension.GetRequiredService<ILogger<MCIServices>>();
                IMCIApiSettings settings = serviceExtension.GetRequiredService<IMCIApiSettings>();
                string apiSecret = configuration.GetSection(AppSettings.MCIApiSettings)
                                                   .GetSection(AppSettings.ApiKey)
                                                                 .Get<string>();
                return new MCIServices(provider, settings, apiSecret, logger);
            });

            services.AddTransient<IExternalAuthService, ADAuthService>();
            services.AddTransient<ICRService, CRService>();
            services.AddTransient<IEmailSenderService, EmailSenderService>();

        }

    }
}
