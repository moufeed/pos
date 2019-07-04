using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Products.Settings
{
    public class ProductManagerServiceSettings : ContentsServiceSettings, IProductManagerServiceSettings
    {
        public ProductManagerServiceSettings(string contentsServiceUrl) : base(contentsServiceUrl)
        {

        }

        private string endpointBase => $"{ContentsServiceEndpointBase}/api/v0.1/ProductsManager";

        #region {Product} Get 

        public string GetAllAsyncEndpoint => $"{endpointBase}/All";

        public string GetAsyncEndpoint => $"{endpointBase}/List/Pagination";

        public string GetByIdAsyncEndpoint => $"{endpointBase}/Get";

        public string CreateAsyncEndpoint => $"{endpointBase}/Create";

        public string EditAsyncEndpoint => $"{endpointBase}/Edit";

        public string PublishAsyncEndpoint => $"{endpointBase}/Publish";

        public string DeleteAsyncEndpoint => $"{endpointBase}/Delete";

        #endregion



        #region {Product Combination} Get / Create / Edit / Delete

        public string GetProductCombinationsAsyncEndpoint => $"{endpointBase}/Combinations/Get";  

        public string CreateProductCombinationAsyncEndpoint => $"{endpointBase}/Combinations/Create";   

        public string PublishProductCombinationAsyncEndpoint => $"{endpointBase}/Combinations/Publish";

        public string DeleteProductCombinationAsyncEndpoint => $"{endpointBase}/Combinations/Delete";

        #endregion




        #region {Product Attribute} 

        public string GetProductAttributesAsyncEndpoint => $"{endpointBase}/Attributes/Get";

        public string CreateProductAttributeAsyncEndpoint => $"{endpointBase}/Attributes/Create";

        public string EditProductAttributeAsyncEndpoint => $"{endpointBase}/Attributes/Edit";

        public string DeleteProductAttributeAsyncEndpoint => $"{endpointBase}/Attributes/Delete";

        #endregion




        #region {Product Attribute Value}  

        public string CreateProductAttributeValueAsyncEndpoint => $"{endpointBase}/Attributes/Values/Create";

        public string EditProductAttributeValueAsyncEndpoint => $"{endpointBase}/Attributes/Values/Edit";

        public string DeleteProductAttributeValueAsyncEndpoint => $"{endpointBase}/Attributes/Values/Delete";
        #endregion




        #region {Product Images}   

        public string DeleteProductImagesAsyncEndpoint => $"{endpointBase}/Images/Delete";
       
        #endregion
    }
}
