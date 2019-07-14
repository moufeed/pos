using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TamTech.Monshaat.POS.Web.Core.Constants;
using TamTech.Monshaat.POS.Web.StartUP.MicroServices;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class BusinessLogicConfigurations
    {
        public static void AddBusinessLogicServicesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
         
                services._AddBusinessLogicDirectBackendServicesConfigurations();

                services.MicroServices_AddProvidersServicesConfigurations();

                services.MicroServices_AddBackendAPIsSettingsConfigurations(configuration);

               services._AddBusinessLogicAPIsServicesConfigurations();
             
        }
    }
}
