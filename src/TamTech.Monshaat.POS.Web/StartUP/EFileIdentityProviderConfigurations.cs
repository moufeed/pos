using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TamTech.Monshaat.POS.EFile2.Utilities;
using TamTech.Monshaat.POS.EFile2.Utilities.Filters;
using TamTech.Monshaat.POS.EFile2.Utilities.Services;
using TamTech.Monshaat.POS.EFile2.Utilities.Settings;
using TamTech.Monshaat.POS.Web.Core.Constants;
using TamTech.Monshaat.POS.Web.MinistryServices.EFile2;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class EFileIdentityProviderConfigurations
    {
        public static void AddEFileIdentityProviderConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            string vendorRole = configuration.GetSection(AppSettings.WebApplicationSettings).GetValue<string>(AppSettings.WebApplication_VendorRoleName);
            if (string.IsNullOrWhiteSpace(vendorRole)) throw new Exception("The property 'VendorRoleName' not found in appSettings json file!!");
            TamTech.Monshaat.POS.EFile2.Utilities.Helpers.VendorRole = vendorRole;


            int logoutAfterMinutes = configuration.GetSection(AppSettings.WebApplicationSettings)
                                             .GetSection(AppSettings.WebApplication_Configuration)
                                              .GetValue<int>(AppSettings.LogoutAfterMinutes);
            if (logoutAfterMinutes == 0) throw new Exception("The property 'LogoutAfterMinutes' not found in appSettings json file!!");
            TamTech.Monshaat.POS.EFile2.Utilities.Helpers.LogoutAfterMinutes = logoutAfterMinutes;
            if (true)
            {
                services.AddTransient<IEFileIdentityProviderService, CustomEF2IdentityProviderService>();
            }
            else
            {
                services.AddTransient<IEFileIdentityProviderService, EFileIdentityProviderService>((serviceExtension) =>
                {
                    EFileServiceModelSettings Settings = configuration.GetSection("EFileServiceSettings").Get<EFileServiceModelSettings>();
                    return new EFileIdentityProviderService(Settings);
                });
            }
            services.AddTransient<IdentityUtilities>();

            services.AddTransient<AuthorizeEFile>();
        }
    }
}
