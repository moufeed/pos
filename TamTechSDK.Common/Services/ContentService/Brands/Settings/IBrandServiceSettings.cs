using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Brands.Settings
{
    public interface IBrandServiceSettings
    {

        string GetPublicDynamicListAsyncEndpoint { get; }

        string CreateAsyncEndpoint { get; }

        string GetAsyncEndpoint { get; }

        string GetByIdAsyncEndpoint { get; }

      

    }
}
