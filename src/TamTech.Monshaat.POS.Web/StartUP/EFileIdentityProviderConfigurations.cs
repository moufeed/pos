using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TamTech.Monshaat.POS.MCI.EFile2;      
using TamTech.Monshaat.POS.MCI.EFile2.Services;
using TamTech.Monshaat.POS.MCI.EFile2.Settings;
using TamTech.Monshaat.POS.Web.MinistryServices.EFile2; 


namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class EFileIdentityProviderConfigurations
    {
        public static void AddEFileIdentityProviderConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEFile2Configurations(configuration);

           // services.AddTransient<IEFileIdentityProviderService, FakeEFileIdentityProviderService>();
            services.AddTransient<IEFileIdentityProviderService, EFileIdentityProviderService>((serviceExtension) =>
            {
                ILogger<EFileIdentityProviderService> logger = serviceExtension.GetRequiredService<ILogger<EFileIdentityProviderService>>();
                EFileServiceModelSettings Settings = configuration.GetSection("EFileServiceSettings").Get<EFileServiceModelSettings>();
                return new EFileIdentityProviderService(Settings, logger);
            });
        }
    }
}
