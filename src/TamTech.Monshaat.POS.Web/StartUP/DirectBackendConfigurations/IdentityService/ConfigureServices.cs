using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Constants;
using TamTechBackendSDK.Common.Services.ApplicationInsightsTelemetry;
using TamTechBackendSDK.Common.Services.ServiceBus.Models;
using TamTechBackendSDK.IdentityService.Enums;
using TamTechBackendSDK.SMSService.Services;
using TamTechBackendSDK.SMSService.Settings;
using TamTech.Monshaat.POS.Web.Core.Constants;

namespace TamTech.Monshaat.POS.Web.StartUP.DirectBackendConfigurations.IdentityService
{
    public static class ConfigureServices
    {
        public static void IdentityService_DirectedBackendServicesConfigurations_ConfigureServices(this IServiceCollection services, IConfiguration Configuration)
        {
            #region SMS Notifications Configuration

            //if (!services.Any(s => s.ServiceType == typeof(ISMSQueueSender)))
            //{
            //    services.AddTransient<ISMSQueueSender, ServiceBusSMSQueueSender>((serviceExtension) =>
            //    {
            //        var telemetry = serviceExtension.GetService<ITelemetryClientService>();
            //        var settings = Configuration.GetSection("SMSServiceSettings").Get<ServiceBusSettings>();
            //        return new ServiceBusSMSQueueSender(telemetry, settings);
            //    });
            //} 
            // ##### this is to send the sms directly without sending to messaging service
            services.AddTransient<ISMSSender, TwilioSMSSender>((serviceExtension) =>
            {
                var telemetry = serviceExtension.GetService<ITelemetryClientService>();
                var settings = Configuration.GetSection("Twilio").Get<TwilioSMSSettings>();
                var sender = new TwilioSMSSender(telemetry, settings);

                return sender;
            });
            #endregion

            #region Email Notifications Configuration
            //#### this is to send email directly
            //services.AddTransient<IEmailSender, SendGridEmailSender>((serviceExtension) =>
            //    {
            //        var telemetry = serviceExtension.GetService<TamTechBackendSDK.Common.Services.ApplicationInsightsTelemetry.ITelemetryClientService>();
            //        var settings = Configuration.GetSection("Portal_SendGrid").Get<TamTechBackendSDK.EmailService.Settings.SendGridSettings>();
            //        var sender = new TamTechBackendSDK.EmailService.Services.SendGridEmailSender(telemetry, settings.ApiKey);

            //        return sender;
            //    }); 
            #endregion


            var _directBackendSDKsSettingsSection = Configuration.GetSection(AppSettings.DirectBackendSDKsSettings);
            services.AddDbContext<TamTechBackendSDK.IdentityService.Data.ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(AppSettings.DirectBackendSDK_IdentityService_IdentityServerUsersCN),
                                    config => config.MigrationsHistoryTable("__IdentityUsers_EFMigrationsHistory")
                                ));

            #region Configure Identity Server 4

            // this is related to how to use identity server to secure it self 
            // this setting will be used in any service that need to secure itself by Identity Server
            var IdentityServiceSettings = Configuration.GetSection(AppSettings.DirectBackendSDKsSettings)
                                                       .GetSection(AppSettings.DirectBackendSDK_IdentityService_SelfSecuring)
                                                       .Get<TamTechBackendSDK.Common.Services.IdentityService.Settings.IdentityServiceConsumeSettings>();


            // configure the password requirements
            var _UsersCreationSettings = Configuration.GetSection(AppSettings.DirectBackendSDKsSettings)
                                                     .GetSection(AppSettings.DirectBackendSDK_IdentityService_UsersCreation);
            bool passwordRequireDigit = _UsersCreationSettings.GetValue<bool>("PasswordRequireDigit");
            int passwordMinimumLength = _UsersCreationSettings.GetValue<int>("PasswordMinimumLength");
            bool passwordRequireLowercase = _UsersCreationSettings.GetValue<bool>("PasswordRequireLowercase");
            bool passwordRequireUppercase = _UsersCreationSettings.GetValue<bool>("PasswordRequireUppercase");
            bool passwordRequireNonAlphanumeric = _UsersCreationSettings.GetValue<bool>("PasswordRequireNonAlphanumeric");
            int passwordMinimumUniqueChars = _UsersCreationSettings.GetValue<int>("PasswordMinimumUniqueChars");
            bool RequireUniqueEmail = _UsersCreationSettings.GetValue<bool>("RequireUniqueEmail");
            bool RequireConfirmedEmail = _UsersCreationSettings.GetValue<bool>("RequireConfirmedEmail");
            bool RequireConfirmedPhoneNumber = _UsersCreationSettings.GetValue<bool>("RequireConfirmedPhoneNumber");

            services.AddIdentity<TamTechBackendSDK.IdentityService.Models.ApplicationUser, Microsoft.AspNetCore.Identity.IdentityRole>(options =>
            {
                options.Password.RequireDigit = passwordRequireDigit;
                options.Password.RequiredLength = passwordMinimumLength;
                options.Password.RequireLowercase = passwordRequireLowercase;
                options.Password.RequireUppercase = passwordRequireUppercase;
                options.Password.RequireNonAlphanumeric = passwordRequireNonAlphanumeric;
                options.Password.RequiredUniqueChars = passwordMinimumUniqueChars;

                options.User.RequireUniqueEmail = RequireUniqueEmail;

                options.SignIn.RequireConfirmedEmail = RequireConfirmedEmail;
                options.SignIn.RequireConfirmedPhoneNumber = RequireConfirmedPhoneNumber;


                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(100);
                //options.Lockout.MaxFailedAccessAttempts = 3;

            })
             .AddEntityFrameworkStores<TamTechBackendSDK.IdentityService.Data.ApplicationDbContext>()
             .AddDefaultTokenProviders();

            //services.ConfigureApplicationCookie(options =>
            //{
            //    // Cookie settings
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

            //    options.LoginPath = "/Identity/Account/Login";
            //    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            //    options.SlidingExpiration = true;
            //});

            var IdentityConfiguration = services.AddIdentityServer()//x => x.IssuerUri = "null")
                                                .AddDeveloperSigningCredential()
                                                .AddAspNetIdentity<TamTechBackendSDK.IdentityService.Models.ApplicationUser>();



            var assembly = typeof(TamTechBackendSDK.IdentityService.Startup.IdentityServiceStartup).GetTypeInfo().Assembly.GetName().Name;

            IdentityConfiguration.AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = builder =>
                    builder.UseSqlServer(Configuration.GetConnectionString(AppSettings.DirectBackendSDK_IdentityService_IdentityServerCN),
                        config =>
                        {
                            config.MigrationsHistoryTable("__IdentityServer4_PersistedGrant_EFMigrationsHistory");
                            config.MigrationsAssembly(assembly);
                        });
            })
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = builder => builder.UseSqlServer(Configuration.GetConnectionString(AppSettings.DirectBackendSDK_IdentityService_IdentityServerCN),
                                                     config =>
                                                     {
                                                         config.MigrationsHistoryTable("__IdentityServer4_EFMigrationsHistory");
                                                         config.MigrationsAssembly(assembly);
                                                     });

                // this enables automatic token cleanup. this is optional.
                options.EnableTokenCleanup = true;
                options.TokenCleanupInterval = 30; // interval in seconds
            })
           .Services
            //.AddAuthorization(options =>
            //{
            //    options.AddPolicy(PolicyConstants.ConfirmMobileNumber, policy => policy.RequireRole(IdentityServiceSettings.GetRolesByPolicy(PolicyConstants.ConfirmMobileNumber)))
            //}
            //)
            .AddTransient<IdentityServer4.Services.IProfileService, TamTechBackendSDK.IdentityService.IdentityServer4Extensions.ProfileService>();
            int LogoutAfterMinutes = Configuration.GetSection(AppSettings.WebApplicationSettings)
                                             .GetSection(AppSettings.WebApplication_Configuration)
                                             .GetValue<int>(AppSettings.LogoutAfterMinutes);

            if (LogoutAfterMinutes == 0) LogoutAfterMinutes = 30;

            // configure securing the identity service by itself
            services.AddAuthentication()
                    .AddIdentityServerAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme, isAuth =>
                    {
                        isAuth.Authority = IdentityServiceSettings.Url;
                        isAuth.ApiName = IdentityServiceSettings.ApiName;
                        isAuth.RequireHttpsMetadata = IdentityServiceSettings.RequireHttpsMetadata;
                    }).Services.ConfigureApplicationCookie(options =>
                    {
                        options.SlidingExpiration = true;
                        options.ExpireTimeSpan = TimeSpan.FromMinutes(LogoutAfterMinutes);
                    }).AddAuthorization(options =>
                    {
                        // Identity SDK Policies
                        options.AddPolicy(PolicyConstants.ConfirmMobileNumber, policy => policy.RequireRole(IdentityServiceSettings.GetRolesByPolicy(PolicyConstants.ConfirmMobileNumber)));
                        options.AddPolicy(PolicyConstants.ResendMobileConfirmationCode, policy => policy.RequireRole(IdentityServiceSettings.GetRolesByPolicy(PolicyConstants.ResendMobileConfirmationCode)));
                        options.AddPolicy(PolicyConstants.ChangePassword, policy => policy.RequireRole(IdentityServiceSettings.GetRolesByPolicy(PolicyConstants.ChangePassword)));
                        options.AddPolicy(PolicyConstants.UsersManager, policy => policy.RequireRole(IdentityServiceSettings.GetRolesByPolicy(PolicyConstants.UsersManager)));

                        // Content SDK Policies

                        options.AddPolicy(ContentSDKPoliciesConstants.MenusContentAdmin, policy => policy.RequireRole(IdentityServiceSettings.GetRolesByPolicy(ContentSDKPoliciesConstants.MenusContentAdmin)));
                        options.AddPolicy(ContentSDKPoliciesConstants.SlidersContentAdmin, policy => policy.RequireRole(IdentityServiceSettings.GetRolesByPolicy(ContentSDKPoliciesConstants.SlidersContentAdmin)));
                        options.AddPolicy(ContentSDKPoliciesConstants.PagesContentAdmin, policy => policy.RequireRole(IdentityServiceSettings.GetRolesByPolicy(ContentSDKPoliciesConstants.PagesContentAdmin)));
                        options.AddPolicy(ContentSDKPoliciesConstants.UsersAdmin, policy => policy.RequireRole(IdentityServiceSettings.GetRolesByPolicy(ContentSDKPoliciesConstants.UsersAdmin)));
                         options.AddPolicy(ContentSDKPoliciesConstants.DashboardAdmin, policy => policy.RequireRole(IdentityServiceSettings.GetRolesByPolicy(ContentSDKPoliciesConstants.DashboardAdmin)));


                        options.AddPolicy(ContentSDKPoliciesConstants.ContactUsAdmin, policy => policy.RequireRole(IdentityServiceSettings.GetRolesByPolicy(ContentSDKPoliciesConstants.ContactUsAdmin)));
                        options.AddPolicy(ContentSDKPoliciesConstants.ContactUsTypesAdmin, policy => policy.RequireRole(IdentityServiceSettings.GetRolesByPolicy(ContentSDKPoliciesConstants.ContactUsTypesAdmin)));
                        options.AddPolicy(ContentSDKPoliciesConstants.ContactUsStatusAdmin, policy => policy.RequireRole(IdentityServiceSettings.GetRolesByPolicy(ContentSDKPoliciesConstants.ContactUsStatusAdmin)));
                        options.AddPolicy(ContentSDKPoliciesConstants.POSAdmin, policy => policy.RequireRole(IdentityServiceSettings.GetRolesByPolicy(ContentSDKPoliciesConstants.POSAdmin)));
                        options.AddPolicy(ContentSDKPoliciesConstants.POSTypesAdmin, policy => policy.RequireRole(IdentityServiceSettings.GetRolesByPolicy(ContentSDKPoliciesConstants.POSTypesAdmin)));
                        options.AddPolicy(ContentSDKPoliciesConstants.POSSectorsAdmin, policy => policy.RequireRole(IdentityServiceSettings.GetRolesByPolicy(ContentSDKPoliciesConstants.POSSectorsAdmin)));
                        options.AddPolicy(ContentSDKPoliciesConstants.POSStatusAdmin, policy => policy.RequireRole(IdentityServiceSettings.GetRolesByPolicy(ContentSDKPoliciesConstants.POSStatusAdmin)));
                        options.AddPolicy(ContentSDKPoliciesConstants.POSAttributesAdmin, policy => policy.RequireRole(IdentityServiceSettings.GetRolesByPolicy(ContentSDKPoliciesConstants.POSAttributesAdmin)));
                        options.AddPolicy(ContentSDKPoliciesConstants.VendorAdmin, policy => policy.RequireRole(IdentityServiceSettings.GetRolesByPolicy(ContentSDKPoliciesConstants.VendorAdmin)));
                        options.AddPolicy(ContentSDKPoliciesConstants.RequestAdmin, policy => policy.RequireRole(IdentityServiceSettings.GetRolesByPolicy(ContentSDKPoliciesConstants.RequestAdmin)));
                        options.AddPolicy(ContentSDKPoliciesConstants.TestimonialsAdmin, policy => policy.RequireRole(IdentityServiceSettings.GetRolesByPolicy(ContentSDKPoliciesConstants.TestimonialsAdmin)));
                        options.AddPolicy(ContentSDKPoliciesConstants.Vendor, policy => policy.RequireRole(IdentityServiceSettings.GetRolesByPolicy(ContentSDKPoliciesConstants.Vendor)));

                    }); ;

            #endregion

            services.AddScoped<TamTechBackendSDK.IdentityService.Services.Configurations.AppSettings.IWebApplicationSettingsService,
                    TamTechBackendSDK.IdentityService.Services.Configurations.AppSettings.WebApplicationSettingsService>((serviceExtension) =>
                    {
                        return new TamTechBackendSDK.IdentityService.Services.Configurations.AppSettings.WebApplicationSettingsService
                         (Configuration,
                            $"{AppSettings.DirectBackendSDKsSettings}:{ AppSettings.DirectBackendSDK_IdentityService_ResetPasswordEmailModelSettings}",
                             $"{AppSettings.DirectBackendSDKsSettings}:{ AppSettings.DirectBackendSDK_IdentityService_SelfSecuring}");
                    });

            services.AddTransient<TamTechBackendSDK.IdentityService.Services.IIdentityServiceNotificationSenderToMessagingService, TamTechBackendSDK.IdentityService.Services.IdentityServiceNotificationSenderToServiceBus>((serviceExtension) =>
            {
                var settings = Configuration.GetSection("SMSServiceSettings").Get<ServiceBusSettings>();
                return new TamTechBackendSDK.IdentityService.Services.IdentityServiceNotificationSenderToServiceBus(settings);
            });

            services.AddTransient<TamTechBackendSDK.Common.Validations.IExpressionValidation, TamTechBackendSDK.Common.Validations.ExpressionValidation>();
            services.AddTransient<TamTechBackendSDK.IdentityService.Services.IUserAccountService, TamTechBackendSDK.IdentityService.Services.UserAccountService>();
            services.AddTransient<TamTechBackendSDK.IdentityService.Services.IUserManagerService, TamTechBackendSDK.IdentityService.Services.UserManagerService>();
            services.AddTransient<TamTechBackendSDK.IdentityService.Services.UserAccountServices.ResetPasswordService.IResetPasswordByEmailSendingService, TamTechBackendSDK.IdentityService.Services.UserAccountServices.ResetPasswordService.ResetPasswordByEmailSendingService>();
            services.AddTransient<TamTechBackendSDK.IdentityService.Services.IRoleService, TamTechBackendSDK.IdentityService.Services.RoleService>();

        }
    }
}
