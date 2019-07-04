using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.ContentService
{
    public interface IContentsServiceSettings
    {
        string ContentsServiceEndpointBase { get; }

        string ClientId { get; }

        string ClientSecret { get; }
    }
}
