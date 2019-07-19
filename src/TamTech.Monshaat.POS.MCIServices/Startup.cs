using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TamTech.Monshaat.POS.MCIServices.Services;
using TamTech.Monshaat.POS.MCIServices.Settings;
using TamTech.Monshaat.POS.SDK.Services.ExternalServices.Authentications;
using TamTech.Monshaat.POS.Services.ExternalServices.CommercialRegister;
using TamTech.Monshaat.POS.Web.Core.Constants;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Models.Shared;
using TamTech.Monshaat.POS.Web.Services.Email;

namespace TamTech.Monshaat.POS.MCIServices
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
                    BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
                    return new MCIApiSimulatorSettings(settings.Url);
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
                }) ;
            }
           
            services.AddTransient<IMCIServices>((serviceExtension) =>    
            {
                IRequestProvider provider = serviceExtension.GetRequiredService<IRequestProvider>();
                IMCIApiSettings settings = serviceExtension.GetRequiredService<IMCIApiSettings>();
                string apiSecret = configuration.GetSection(AppSettings.MCIApiSettings)
                                                   .GetSection(AppSettings.ApiKey)
                                                                 .Get<string>();
                return new MCIServices(provider, settings, apiSecret);
            });

            services.AddTransient<IExternalAuthService, ADAuthService>();
            services.AddTransient<ICRService, CRService>();
            services.AddTransient<IEmailSenderService, EmailSenderService>();

        }
       
    }
}
