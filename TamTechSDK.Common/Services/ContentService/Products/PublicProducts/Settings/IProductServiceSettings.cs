using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Products.Settings
{
    public interface IProductServiceSettings
    {
        string GetPublicDynamicListByIdsAsyncEndpoint { get; }

        string GetPublicDynamicListBySKUsAsyncEndpoint { get; }

        string GetPublicDynamicByIdAsyncEndpoint { get; }

        string GetByIdAsyncEndpoint { get; }

        string GetFiltrationAsyncEndpoint { get; }

        string GetPaginationWithGenericFiltrationAsyncEndpoint { get; }

    }
}
