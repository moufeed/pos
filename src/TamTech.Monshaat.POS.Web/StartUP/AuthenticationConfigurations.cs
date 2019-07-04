using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 
using TamTech.Monshaat.POS.Web.Core.Constants;
using TamTech.Monshaat.POS.Web.StartUP.DirectBackendConfigurations.IdentityService;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class AuthenticationConfigurations
    {
        public static void AddAuthenticationConfigurations(this IServiceCollection services, IConfiguration configuration)
        {

            bool useMicroServices = configuration.GetSection(AppSettings.WebApplicationSettings)
                .GetSection(AppSettings.WebApplication_UseMicroServices).Get<bool>();
            if (useMicroServices)
            {
               // services.MicroServices_AddIdentityServerAuthentication(configuration);
            }
            else
            {
                services.IdentityService_DirectedBackendServicesConfigurations_ConfigureServices(configuration);
            }

        }

    }
}
