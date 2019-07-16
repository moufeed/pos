using Microsoft.Extensions.DependencyInjection;
using TamTech.Monshaat.POS.MCIServices.Settings;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;

namespace TamTech.Monshaat.POS.MCIServices
{
    public static class MCIServicesStartup
    {
        public static void AddMCIServicesConfigurations(this IServiceCollection services)
        {
            services.AddScoped<IMCIApiSettings, MCIApiSimulatorSettings>();   
            services.AddTransient<IMCIADServices>((serviceExtension) =>

            {
                IRequestProvider provider = serviceExtension.GetRequiredService<IRequestProvider>();
                IMCIApiSettings settings = serviceExtension.GetRequiredService<IMCIApiSettings>();
                string apiSecret = "5c2ea2bd-30ed-47fa-97cd-93027f229f0e";
                return new MCIServices(provider, settings, apiSecret);
            });
           


        }
       
    }
}
