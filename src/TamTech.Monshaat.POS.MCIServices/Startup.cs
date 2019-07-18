using Microsoft.Extensions.DependencyInjection;
using TamTech.Monshaat.POS.MCIServices.Services;
using TamTech.Monshaat.POS.MCIServices.Settings;
using TamTech.Monshaat.POS.SDK.Services.ExternalServices.Authentications;
using TamTech.Monshaat.POS.Services.ExternalServices.CommercialRegister;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Services.Email;

namespace TamTech.Monshaat.POS.MCIServices
{
    public static class MCIServicesStartup
    {
        public static void AddMCIServicesConfigurations(this IServiceCollection services)
        {
            services.AddScoped<IMCIApiSettings, MCIApiSimulatorSettings>();   
            services.AddTransient<IMCIServices>((serviceExtension) =>

            {
                IRequestProvider provider = serviceExtension.GetRequiredService<IRequestProvider>();
                IMCIApiSettings settings = serviceExtension.GetRequiredService<IMCIApiSettings>();
                string apiSecret = "5c2ea2bd-30ed-47fa-97cd-93027f229f0e";
                return new MCIServices(provider, settings, apiSecret);
            });

            services.AddTransient<IExternalAuthService, ADAuthService>();
            services.AddTransient<ICRService, CRService>();
            services.AddTransient<IEmailSenderService, EmailSenderService>();

        }
       
    }
}
