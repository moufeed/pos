using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Core.Settings.Utilities;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class SettingsConfigurations
    {
        public static void UseSettings(this IApplicationBuilder app, IHostingEnvironment env, IConfiguration Configuration)
        {
            try
            {
                using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    var service = scope.ServiceProvider.GetRequiredService<SettingsHelpers>();
                    // var result = AsyncContext.RunTask(MyAsyncMethod).Result;
                    //var task = Task.Run(async () => await service.PrepareCashedSettingsAsync()).WaitAndUnwrapException();
                    var task = service.PrepareCashedSettingsAsync().GetAwaiter();

                }
            }
            catch (Exception ex)
            {

            }


        }
    }
}
