using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TamTech.Monshaat.POS.Web.StartUP.DirectBackendConfigurations.ContentService
{

    public static class MockRepositoriesServicesConfigurations
    {
        public static void _ContentService_AddMockRepositoriesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {

            //var useMock = configuration.GetValue<bool>("ContentService_UseMockServices");

            //if (useMock)
            //{
            //    services.AddSingleton<IPagesRepository, MockPagesRepository>();
            //    services.AddSingleton<IProductsRepository, MockProductsRepository>();
            //    services.AddSingleton<IContentsRepository, MockContentRepository>();
            //}
        }

    }
}
