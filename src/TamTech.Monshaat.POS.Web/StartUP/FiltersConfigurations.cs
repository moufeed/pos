using Microsoft.Extensions.DependencyInjection;
using TamTech.Monshaat.POS.Web.Core.Filters;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class FiltersConfigurations
    {
        public static void AddFiltersConfigurations(this IServiceCollection services)
        {

            services.AddScoped<UserContextUpdatedFilter>();
            services.AddScoped<UserActivityFilter>();
            services.AddTransient<AdminFilter>();
            //  services.AddTransient<MenuFilter>(); 
        }
    }
}
