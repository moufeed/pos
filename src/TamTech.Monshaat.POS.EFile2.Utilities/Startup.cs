using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;            
using TamTech.Monshaat.POS.EFile2.Utilities.Filters;
using TamTech.Monshaat.POS.EFile2.Utilities.Services;
using TamTech.Monshaat.POS.EFile2.Utilities.Settings;   
using TamTech.Monshaat.POS.Web.Core.Constants;

namespace TamTech.Monshaat.POS.EFile2.Utilities
{
    public static class EFile2Startup
    {
        public static void AddEFile2Configurations(this IServiceCollection services, IConfiguration configuration)
        {

            //int logoutAfterMinutes = configuration.GetSection(AppSettings.WebApplicationSettings)
            //                                 .GetSection(AppSettings.WebApplication_Configuration)
            //                                  .GetValue<int>(AppSettings.LogoutAfterMinutes);
            //if (logoutAfterMinutes == 0) throw new Exception("The property 'LogoutAfterMinutes' not found in appSettings json file!!");
            TamTech.Monshaat.POS.EFile2.Utilities.Helpers.LogoutAfterMinutes = 30; /*logoutAfterMinutes*/;



            services.AddTransient<IdentityUtilities>();

            services.AddTransient<AuthorizeEFile>();
        }
    }
}
