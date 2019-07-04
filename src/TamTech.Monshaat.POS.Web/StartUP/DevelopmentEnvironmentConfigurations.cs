using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class DevelopmentEnvironmentConfigurations
    {
        public static void ConfigureDevelopmentEnvironment(this IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}
