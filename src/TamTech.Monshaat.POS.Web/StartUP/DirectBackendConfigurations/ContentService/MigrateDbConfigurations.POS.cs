using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using TamTech.ContentService.Core.Domain.Models;
using TamTech.ContentService.Data;

namespace TamTech.Monshaat.POS.Web.StartUP.DirectBackendConfigurations.ContentService
{
    public static class MigrateDbConfigurations_POS
    {
        public static void UseDataMigrationsOfPOS(this IApplicationBuilder app, IHostingEnvironment env,
            IConfiguration Configuration)
        {
            var migrateData = Configuration.GetSection("DirectBackendSDKsSettings").GetValue<bool>("DirectBackendSDK_ContentService_MigrateDatabase");
            if (!migrateData) return;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath).AddJsonFile("DataMigrations.json", optional: true, reloadOnChange: true);

            DataMigrationModel dataSource = builder.Build().Get<DataMigrationModel>();

            var biographiesBuilder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath).AddJsonFile("DataMigrations.Biographies.json", optional: true, reloadOnChange: true);

            DataMigrationModel bio = biographiesBuilder.Build().Get<DataMigrationModel>();

            var settingsBuilder = new ConfigurationBuilder()
           .SetBasePath(env.ContentRootPath).AddJsonFile("DataMigrations.Settings.json", optional: true, reloadOnChange: true);

            DataMigrationModel set = settingsBuilder.Build().Get<DataMigrationModel>();

            dataSource.Biographies = bio.Biographies;
            dataSource.Settings = set.Settings;
            POSDataMigrationsManager dataMigrationManager = new POSDataMigrationsManager(dataSource, app);
            dataMigrationManager.Migrate();// MigrateAsync()

        }
    }
}
