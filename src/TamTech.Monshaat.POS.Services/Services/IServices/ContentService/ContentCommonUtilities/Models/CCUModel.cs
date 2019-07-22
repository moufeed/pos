using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.ContentCommonUtilities.Models
{
    public class CCUModel<T>
    {
      
            
            [JsonProperty("lang")]
            public string Lang { get; set; }


            [JsonProperty("array")]
            public T Types { get; set; }
    
    }
}
