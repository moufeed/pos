using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Core.Helpers
{
    public class Helpers
    {

        public static T Deserialize<T>(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return default(T);
            return JsonConvert.DeserializeObject<T>(value);
        }

    }
}
