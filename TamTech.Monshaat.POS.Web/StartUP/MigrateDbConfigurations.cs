
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TamTech.Monshaat.POS.Web.StartUP.DirectBackendConfigurations.ContentService;
using TamTech.Monshaat.POS.Web.Services.Configurations.AppSetting.Constants;
using TamTech.Monshaat.POS.Web.StartUP.DirectBackendConfigurations.IdentityService;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class MigrateDbConfigurations
    {
        public static void SeedData(this IApplicationBuilder app, IHostingEnvironment env, IConfiguration configuration)
        {
            bool useMicroServices = configuration.GetSection(AppSettings.WebApplicationSettings)
                .GetSection(AppSettings.WebApplication_UseMicroServices).Get<bool>();

            if (!useMicroServices)
            {
                app.UseDataMigrationsOfIdentityService(env, configuration);
                app.UseDataMigrationsOfContentService(env, configuration);
                app.UseDataMigrationsOfPOS(env, configuration);
            }


        }
    }
}
