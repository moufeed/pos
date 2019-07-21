using Microsoft.Extensions.DependencyInjection; 
using TamTech.Monshaat.POS.Web.SDK.Services.Upload;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class BLLDirectBackendServicesConfigurations
    {
        public static void _AddBusinessLogicDirectBackendServicesConfigurations(this IServiceCollection services)
        {  
            #region Upload Service 

            services.AddTransient<IUploadService, TamTech.Monshaat.POS.Web.DirectBackendServices.UploadService.DirectFileStorageService>();

            #endregion
          


        }
    }
}
