using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using TamTech.Monshaat.POS.IdentityService.Models;
using TamTech.Monshaat.POS.IdentityService.Services;
using TamTech.Monshaat.POS.Web.SDK.Core.Constants;
using TamTech.Monshaat.POS.Web.SDK.Core.Enums;
using TamTech.Monshaat.POS.Web.SDK.Models.Shared;

namespace TamTech.Monshaat.POS.IdentityService
{
    public static class POSIdentityServiceStartup
    {       
        public static void AddIdentityServiceConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            int durationOfLogin = configuration.GetSection(AppSettings.WebApplicationSettings)
                                           .GetValue<int>(AppSettings.DurationOfLogin);
            if (durationOfLogin <= 0)
            {
                durationOfLogin = CommonConstants.DefaultDurationOfLogin;
            };
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.Cookie.HttpOnly = true;
                       // options.Cookie.Expiration = TimeSpan.FromMinutes(1);  
                        options.Cookie.SecurePolicy = CookieSecurePolicy.None;
                        //    ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
                        options.Cookie.SameSite = SameSiteMode.Lax;
                        options.Cookie.Name = "POS.AspNetCore";
                        options.LoginPath = "/Account/Login";
                        options.LogoutPath = "/Account/Logout";
                        options.AccessDeniedPath = "/Account/AccessDenied";
                         options.SlidingExpiration = true;
                         options.ExpireTimeSpan = TimeSpan.FromMinutes(durationOfLogin);
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
            //    options.AddPolicy("Vendor",                                            policy =>
            //        policy.RequireRole("TAMCMS_Vendor"));
            //}).AddJsonFormatters();
            List<string> GetAdmin(string val)
            {
                return new List<string> { val };
            }
            var adminClaimPolicy = new AuthorizationPolicyBuilder().RequireClaim(CommonConstants.PermissionClaimName, new List<string> { PermissionTypeEnum.Admin.ToString() }).Build();
            var vendorClaimPolicy = new AuthorizationPolicyBuilder().RequireClaim(CommonConstants.PermissionClaimName, new List<string> { PermissionTypeEnum.User.ToString(), PermissionTypeEnum.Vendor.ToString() }).Build();
            var posClaimPolicy = new AuthorizationPolicyBuilder().RequireClaim(CommonConstants.PermissionClaimName, new List<string> { PermissionTypeEnum.Vendor.ToString() }).Build();
             services.AddMvcCore().AddAuthorization(options =>
                {
                    options.AddPolicy(PolicyConstants.AuthenticatedUser, new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build());

                    // Identity SDK Policies
                    options.AddPolicy(PolicyConstants.IdentityUserAccess, adminClaimPolicy);
                    options.AddPolicy(PolicyConstants.IdentityManager,         adminClaimPolicy);
                                                                           
                    // Content SDK Policies                                 
                                                                              
                    options.AddPolicy(PolicyConstants.MenusContentAdmin,       adminClaimPolicy);
                    options.AddPolicy(PolicyConstants.SlidersContentAdmin,     adminClaimPolicy);
                    options.AddPolicy(PolicyConstants.PagesContentAdmin,       adminClaimPolicy);
                    options.AddPolicy(PolicyConstants.UsersAdmin,              adminClaimPolicy);
                    options.AddPolicy(PolicyConstants.DashboardAdmin,          adminClaimPolicy);
                    options.AddPolicy(PolicyConstants.AdminAccess,             adminClaimPolicy);
                    options.AddPolicy(PolicyConstants.ConfigurationsAdmin,             adminClaimPolicy);
                    options.AddPolicy(PolicyConstants.BiographiesAdmin,             adminClaimPolicy);
                                                                         
                                                                         
                    options.AddPolicy(PolicyConstants.ContactUsAdmin,          adminClaimPolicy);
                    options.AddPolicy(PolicyConstants.ContactUsTypesAdmin,     adminClaimPolicy);
                    options.AddPolicy(PolicyConstants.ContactUsStatusAdmin,    adminClaimPolicy);
                    options.AddPolicy(PolicyConstants.POSAdmin,                adminClaimPolicy);
                    options.AddPolicy(PolicyConstants.POSTypesAdmin,           adminClaimPolicy);
                    options.AddPolicy(PolicyConstants.POSSectorsAdmin,         adminClaimPolicy);
                    options.AddPolicy(PolicyConstants.POSStatusAdmin,          adminClaimPolicy);
                    options.AddPolicy(PolicyConstants.POSAttributesAdmin,      adminClaimPolicy);
                    options.AddPolicy(PolicyConstants.VendorAdmin,             adminClaimPolicy);
                    options.AddPolicy(PolicyConstants.Vendor, vendorClaimPolicy);
                    options.AddPolicy(PolicyConstants.POSOwner, posClaimPolicy);


        }); ;
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
