using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;   
using TamTech.Monshaat.POS.MCI.EFile2.Filters;
using TamTech.Monshaat.POS.MCI.EFile2.Utilities;
using TamTech.Monshaat.POS.Web.SDK.Core.Constants;

namespace TamTech.Monshaat.POS.MCI.EFile2
{
    public static class EFile2Startup
    {
        public static void AddEFile2Configurations(this IServiceCollection services, IConfiguration configuration)
        {

            int durationOfLogin = configuration.GetSection(AppSettings.WebApplicationSettings)   
                                              .GetValue<int>(AppSettings.DurationOfLogin);
            if (durationOfLogin <= 0)
            {
                durationOfLogin = CommonConstants.DefaultDurationOfLogin;
            };
                //if (logoutAfterMinutes == 0) throw new Exception("The property 'LogoutAfterMinutes' not found in appSettings json file!!");
                TamTech.Monshaat.POS.MCI.EFile2.Utilities.Helpers.DurationOfLogin = durationOfLogin; /*logoutAfterMinutes*/;



            services.AddTransient<IdentityUtilities>();

            services.AddTransient<AuthorizeEFile>();
        }
    }
}
