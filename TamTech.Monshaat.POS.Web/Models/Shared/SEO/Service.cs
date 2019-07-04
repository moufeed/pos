using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Web.Models.Shared.SEO
{
    public class Service : SeoSchema
    {

        [JsonProperty("provider")]
        public Organization Provider { get; set; } = new Organization();

    }
}
