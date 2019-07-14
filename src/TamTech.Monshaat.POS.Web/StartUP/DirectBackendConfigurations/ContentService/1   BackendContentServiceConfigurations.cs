using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TamTech.Monshaat.POS.Web.StartUP.DirectBackendConfigurations.ContentService;
using TamTech.Monshaat.POS.Web.AppStartup.DirectBackendServices.EmailService;
using TamTech.Monshaat.POS.Web.AppStartup.DirectBackEndServices.FilesServices; 
using TamTech.Monshaat.POS.Web.Core.Constants;

namespace TamTech.Monshaat.POS.Web.StartUP.DirectBackendConfigurations.ContentService
{
    public static class ContentServiceConfigurations
    {
        public static void AddBackendContentServiceConfigurations(this IServiceCollection services, IConfiguration configuration)
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
