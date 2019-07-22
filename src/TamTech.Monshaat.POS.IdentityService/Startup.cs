using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TamTech.Monshaat.POS.IdentityService.Models;
using TamTech.Monshaat.POS.IdentityService.Services;
using TamTech.Monshaat.POS.Web.SDK.Core.Constants;
using TamTech.Monshaat.POS.Web.SDK.Models.Shared;

namespace TamTech.Monshaat.POS.IdentityService
{
    public static class POSIdentityServiceStartup
    {       
        public static void AddIdentityServiceConfigurations(this IServiceCollection services, IConfiguration configuration)
        {       

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.Cookie.HttpOnly = true;
                        options.Cookie.SecurePolicy = CookieSecurePolicy.None;
                        //    ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
                        options.Cookie.SameSite = SameSiteMode.Lax;
                        options.Cookie.Name = "POS.AspNetCore";
                        options.LoginPath = "/Account/Login";
                        options.LogoutPath = "/Account/Logout";
                        options.AccessDeniedPath = "/Account/AccessDenied";
                    });
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
                options.HttpOnly = HttpOnlyPolicy.None;
                options.Secure = CookieSecurePolicy.None;
                //  ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
            });
            //services.AddMvcCore().AddAuthorization(options =>
            //{
            //    options.AddPolicy("Vendor", policy =>
            //        policy.RequireRole("TAMCMS_Vendor"));
            //}).AddJsonFormatters();
                 
            services.AddTransient<ITokenTamService, TokenTamService>();



            services.AddScoped<ITokenTamService>((serviceExtension) =>
            {
                BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
                //BackendApiSettingsModel settings = new BackendApiSettingsModel
                //{
                //    Url = settingsService.IDS4Url,
                //    ClientId = settingsService.ClientId,
                //    ClientSecret = settingsService.ClientSecret,
                //    ClientScope = settingsService.ClientScope,
                //};
                return new TokenTamService(settings);
            });

        }


        public static void ConfigureIdentityService(this IApplicationBuilder app, IHostingEnvironment env)
        {     
            app.UseAuthentication();    
        }
    }
}
