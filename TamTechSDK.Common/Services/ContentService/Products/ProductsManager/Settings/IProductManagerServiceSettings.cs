using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Products.Settings
{
    public interface IProductManagerServiceSettings
    {

        string CreateAsyncEndpoint { get; }

        string EditAsyncEndpoint { get; }

        string GetAsyncEndpoint { get; }

        string GetAllAsyncEndpoint { get; }

        string GetByIdAsyncEndpoint { get; }

        string PublishAsyncEndpoint { get; }

        string DeleteAsyncEndpoint { get; }





        string GetProductCombinationsAsyncEndpoint { get; }

         string CreateProductCombinationAsyncEndpoint { get; }

 
        string PublishProductCombinationAsyncEndpoint { get; }

        string DeleteProductCombinationAsyncEndpoint { get; }






        string GetProductAttributesAsyncEndpoint { get; }

        string CreateProductAttributeAsyncEndpoint { get; }

        string EditProductAttributeAsyncEndpoint { get; }

        string DeleteProductAttributeAsyncEndpoint { get; }






        string CreateProductAttributeValueAsyncEndpoint { get; }

        string EditProductAttributeValueAsyncEndpoint { get; }

        string DeleteProductAttributeValueAsyncEndpoint { get; }





        string DeleteProductImagesAsyncEndpoint { get; }




    }
}
