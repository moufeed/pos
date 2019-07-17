using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;                            
using TamTech.Monshaat.POS.IdentityService;    
using TamTech.Monshaat.POS.MCIServices;
using TamTech.Monshaat.POS.Web.AppStartup.DirectBackendServices.EmailService;
using TamTech.Monshaat.POS.Web.AppStartup.DirectBackEndServices.FilesServices;    
using TamTech.Monshaat.POS.Web.Core.Cultures;
using TamTech.Monshaat.POS.Web.StartUP;                      

namespace TamTech.Monshaat.POS.Web
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddLocalizationConfigurations();

            services.AddMVCConfigurations();

            services.AddCompressionConfigurations();

            services.AddFiltersConfigurations();


            services.AddIdentityService();

      //      services.AddAuthenticationConfigurations(Configuration);

            services.AddCommonServicesConfigurations(Configuration);

          //  services.AddBackendContentServiceConfigurations(Configuration);

            services.DirectBackendServices_AddFilesServicesConfigurationsConfigurations(Configuration);
            services.DirectBackendServices_AddEmailServicesConfigurations(Configuration);
            services.AddBusinessLogicServicesConfigurations(Configuration);

            services.AddEFileIdentityProviderConfigurations(Configuration);

            services.AddFluentValidationConfigurations();

            services.AddMCIServicesConfigurations();    

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {


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
                
            app.UseXSSProtection(env, Configuration);    
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
            app.UseSettings(env, Configuration);
            app.ConfigureIdentityService(env);

            app.UseResponseCompression();

            app.UseMvcAndRoute(Configuration, new CultureManager().LocalizationOptions);


        }
    }
}    