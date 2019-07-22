using Microsoft.Extensions.DependencyInjection;
using TamTech.Monshaat.POS.Web.SDK.Core.Filters;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class FiltersConfigurations
    {
        public static void AddFiltersConfigurations(this IServiceCollection services)
        {

            services.AddScoped<UserContextUpdated>();
            services.AddScoped<ActiveVendor>();
            services.AddTransient<AdminFilter>();
            //  services.AddTransient<MenuFilter>(); 
        }
    }
}
