using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Categories.Settings
{
    public interface ICategoryServiceSettings
    {

        string GetPublicDynamicListAsyncEndpoint { get; }

        string CreateAsyncEndpoint { get; }

        string GetAsyncEndpoint { get; }

        string GetByIdAsyncEndpoint { get; }

      

    }
}
