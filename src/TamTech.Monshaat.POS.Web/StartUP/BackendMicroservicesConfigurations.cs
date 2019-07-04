using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TamTech.Monshaat.POS.Web.StartUP.DirectBackendConfigurations.ContentService;
using TamTech.Monshaat.POS.Web.AppStartup.DirectBackendServices.EmailService;
using TamTech.Monshaat.POS.Web.AppStartup.DirectBackEndServices.FilesServices; 
using TamTech.Monshaat.POS.Web.Services.Configurations.AppSetting.Constants;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class BackendMicroservicesConfigurations
    {
        public static void AddBackendMicroservicesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            bool useMicroServices = configuration.GetSection(AppSettings.WebApplicationSettings)
                                                 .GetSection(AppSettings.WebApplication_UseMicroServices).Get<bool>();
            if (useMicroServices)
            {
                //services.MicroServices_AddUrlBackendSettingsServicesConfigurations(configuration);

               // services.MicroServices_AddProvidersServicesConfigurations();
            }
            else
            {
                services.DirectBackendServices_ContentService_AddCommonHelpersServicesConfigurations(configuration);

                services.DirectBackendServices_ContentService_AddContentBLLServicesConfigurations();

                services.DirectBackendServices_ContentService_AddRepositoriesConfigurations(configuration);

                services.DirectBackendServices_ContentService_AddFluentValidationConfigurations();

                services.DirectBackendServices_AddFilesServicesConfigurationsConfigurations(configuration);

                services.DirectBackendServices_AddEmailServicesConfigurations(configuration);
            }
        }
    }
}
