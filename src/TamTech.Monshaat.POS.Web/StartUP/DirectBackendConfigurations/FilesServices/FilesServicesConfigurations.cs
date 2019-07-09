using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;  
using FluentValidation;
using TamTech.Monshaat.POS.UploadService.Validators;
using TamTech.Monshaat.POS.UploadService.Services;
using TamTech.Monshaat.POS.UploadService.Configurations; 
using TamTech.Monshaat.POS.UploadService.Models; 

namespace TamTech.Monshaat.POS.Web.AppStartup.DirectBackEndServices.FilesServices
{
    public static class FilesServicesConfigurations
    {
        public static void DirectBackendServices_AddFilesServicesConfigurationsConfigurations(this IServiceCollection services, IConfiguration configuration)
        { 
            services.AddTransient<IValidator<UploadDTO>, UploadDtoValidator>();
            services.AddTransient<IUploadService, UploadToLocal>();
            services.AddScoped<IUploadSettingsConfigurations, UploadSettingsConfigurations>(); 

        }


       
    }
}
