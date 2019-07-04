using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService
{
    public interface IContentsServiceSettings
    {
        string ContentsServiceEndpointBase { get; }

        string ClientId { get; }

        string ClientSecret { get; }
    }
}
