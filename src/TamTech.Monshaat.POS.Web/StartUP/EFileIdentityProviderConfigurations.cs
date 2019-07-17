using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 
using TamTech.Monshaat.POS.EFile2.Utilities;      
using TamTech.Monshaat.POS.EFile2.Utilities.Services;
using TamTech.Monshaat.POS.EFile2.Utilities.Settings;
using TamTech.Monshaat.POS.Web.MinistryServices.EFile2; 


namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class EFileIdentityProviderConfigurations
    {
        public static void AddEFileIdentityProviderConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEFile2Configurations(configuration);

            services.AddTransient<IEFileIdentityProviderService, EFileIdentityProviderService>((serviceExtension) =>
            {
                EFileServiceModelSettings Settings = configuration.GetSection("EFileServiceSettings").Get<EFileServiceModelSettings>();
                return new EFileIdentityProviderService(Settings);
            });
        }
    }
}
