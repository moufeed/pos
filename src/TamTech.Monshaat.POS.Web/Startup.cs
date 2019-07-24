using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;      
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;                            
using TamTech.Monshaat.POS.IdentityService;    
using TamTech.Monshaat.POS.MCI.Services;
using TamTech.Monshaat.POS.SDK.Core.Context;
using TamTech.Monshaat.POS.Web.AppStartup.DirectBackEndServices.FilesServices;    
using TamTech.Monshaat.POS.Web.SDK.Core.Cultures;
using TamTech.Monshaat.POS.Web.StartUP;                      
using TamTech.Monshaat.POS.Web.StartUP.MicroServices;                      

namespace TamTech.Monshaat.POS.Web
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {

             _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddLocalizationConfigurations();

            services.AddMVCConfigurations();

            services.AddCompressionConfigurations();

            services.AddFiltersConfigurations();  

            services.AddIdentityServiceConfigurations(_configuration);   

            services.AddCommonServicesConfigurations(_configuration);           

            services.DirectBackendServices_AddFilesServicesConfigurationsConfigurations(_configuration);

            services._AddBusinessLogicDirectBackendServicesConfigurations();

            services.MicroServices_AddProvidersServicesConfigurations();

            services.MicroServices_AddBackendAPIsSettingsConfigurations(_configuration);

            services.AddBLLAPIsServicesConfigurations();

            services.AddEFileIdentityProviderConfigurations(_configuration);

            services.AddFluentValidationConfigurations();

            services.AddMCIServicesConfigurations(_configuration);

            services.AddMCIAPISimulatorConfigurations(_configuration);
          

            //services.AddTransient<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

            //services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseLogsConfiguration(loggerFactory);

         //   app.SeedData(env, Configuration);  
            string cachePeriod;
            if (env.IsDevelopment())
            {
                // app.UseBrowserLink(); from web admin panel
                app.UseDeveloperExceptionPage();
                cachePeriod = "600";

            }
            else
            {
                app.UseExceptionHandler("/error/500");
                app.UseHsts();
                cachePeriod = "86400";
            }
                
            app.UseXSSProtection(env, _configuration);    
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={cachePeriod}");
                }
            });
            app.UseResponseCompression();
            app.UseStatusCodePagesWithRedirects("/error/{0}");
            app.InitializeMapper();    
            app.UseSettings(env, _configuration);
            app.ConfigureIdentityService(env);
           // app.UseCustomHttpContext();
            app.UseResponseCompression();

            app.UseMvcAndRoute(_configuration, new CultureManager().LocalizationOptions);
            app.UseCookiePolicy();

        }
    }
}    