using Microsoft.Extensions.DependencyInjection;
using TamTech.Monshaat.POS.MCI.APISimulator;

namespace TamTech.Monshaat.POS.MCI.APISimulator
{
    public static class MCIAPISimulatorStartup
    {
        public static void AddMCIAPISimulatorConfigurations(this IServiceCollection services)
        {
              services.AddScoped<MCIAPISecret>((serviceExtension) =>

            {      
                string apiSecret = "5c2ea2bd-30ed-47fa-97cd-93027f229f0e";
                return new MCIAPISecret( apiSecret);
            });
           


        }
       
    }
}
