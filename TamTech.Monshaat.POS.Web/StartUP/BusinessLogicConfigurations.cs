using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TamTech.Monshaat.POS.Web.Services.Configurations.AppSetting.Constants;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class BusinessLogicConfigurations
    {
        public static void AddBusinessLogicServicesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            bool useMicroServices = configuration.GetSection(AppSettings.WebApplicationSettings)
                                                 .GetSection(AppSettings.WebApplication_UseMicroServices).Get<bool>();
            if (useMicroServices)
            {
                services._AddBusinessLogicMicroServicesConfigurations(configuration);
            }
            else
            {
                services._AddBusinessLogicDirectBackendServicesConfigurations();
            }
        }
    }
}
