
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TamTech.Monshaat.POS.Web.StartUP.DirectBackendConfigurations.ContentService;    
using TamTech.ContentService.Core.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class MigrateDbConfigurations
    {
        public static void SeedData(this IApplicationBuilder app, IHostingEnvironment env, IConfiguration configuration)
        {


            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<POSdbContext>().Database.Migrate();
            }

            app.UseDataMigrationsOfContentService(env, configuration);
                app.UseDataMigrationsOfPOS(env, configuration);
           


        }
    }
}
