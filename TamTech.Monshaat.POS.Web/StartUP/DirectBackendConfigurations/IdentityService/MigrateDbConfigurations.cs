using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using TamTech.ContentService.Core.Domain.Models;
using TamTech.ContentService.Data;
using TamTech.Monshaat.POS.Web.Services.Configurations.AppSetting.Constants;
using TamTechBackendSDK.Common.Services.IdentityService.Settings;
using TamTechBackendSDK.IdentityService.Settings;

namespace TamTech.Monshaat.POS.Web.StartUP.DirectBackendConfigurations.IdentityService
{
    public static class MigrateDbConfigurations
    {
        public static void UseDataMigrationsOfIdentityService(this IApplicationBuilder app, IHostingEnvironment env, IConfiguration Configuration)
        {
            var migrateData = Configuration.GetSection(AppSettings.DirectBackendSDKsSettings).GetSection(AppSettings.DirectBackendSDK_IdentityService_SelfSecuring).
                GetValue<bool>(AppSettings.EnableSeedUsersAndRoles);
            DataMigrationManager dataMigrationManager = new DataMigrationManager();
            IConfigurationBuilder builder;
            if (migrateData)
            {
                builder = new ConfigurationBuilder()
                  .SetBasePath(env.ContentRootPath).AddJsonFile("DataMigrations.Identity.Users.json", optional: true,
                      reloadOnChange: true);

                var seedUsersAndRolesSettings = builder.Build().Get<SeedUsersAndRolesSettings>();

                dataMigrationManager.SeedIdentityServerUsersAndRoles(seedUsersAndRolesSettings, app);
            }

            migrateData = Configuration.GetSection(AppSettings.DirectBackendSDKsSettings).GetSection(AppSettings.DirectBackendSDK_IdentityService_SelfSecuring).
              GetValue<bool>(AppSettings.EnableSeedIdentityServerSettings);

            if (migrateData)
            {
                builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath).AddJsonFile("DataMigrations.Identity.Server.json", optional: true,
                        reloadOnChange: true);

                var seedIdentityServerSettings = builder.Build().Get<SeedIdentityServerSettings>();
                var IdentityServiceSettings = Configuration.GetSection(AppSettings.DirectBackendSDKsSettings)
                    .GetSection(AppSettings.DirectBackendSDK_IdentityService_SelfSecuring)
                    .Get<IdentityServiceConsumeSettings>();

                dataMigrationManager.SeedIdentityServerSettings(seedIdentityServerSettings, app, IdentityServiceSettings.Url);
            }



        }
    }
}
