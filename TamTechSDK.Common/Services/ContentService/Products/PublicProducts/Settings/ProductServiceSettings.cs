namespace TamTechSDK.Common.Services.ContentService.Products.Settings
{
    public class ProductServiceSettings : ContentsServiceSettings, IProductServiceSettings
    {
        public ProductServiceSettings(string contentsServiceUrl) : base(contentsServiceUrl)
        {

        }


        private string endpointBase => $"{ContentsServiceEndpointBase}/api/v0.1/Products";


        public string GetPublicDynamicListByIdsAsyncEndpoint => $"{endpointBase}/Dynamic/List/ids";

        public string GetPublicDynamicListBySKUsAsyncEndpoint => $"{endpointBase}/Dynamic/List/skus";

        public string GetPublicDynamicByIdAsyncEndpoint => $"{endpointBase}/Dynamic/Get"; 


        public string GetByIdAsyncEndpoint => $"{endpointBase}/Get";


        public string GetFiltrationAsyncEndpoint => $"{endpointBase}/List/Filtration";


        public string GetPaginationWithGenericFiltrationAsyncEndpoint => $"{endpointBase}/List/PaginationWithGenericFiltration";

    }
}
