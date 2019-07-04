using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.Identity.Models.Params
{
      public class GetUsersModel
    {
         
        //[JsonProperty("u")]  >>> From Query
        public string UserName { get; set; } = "";

        // [JsonProperty("r")]  >>> From Query
        public string RoleId { get; set; } = "";


        // [JsonProperty("pn")]// >>> From Query
         public int PageNumber { get; set; } = 1;

        // [JsonProperty("s")]>>> From Query
       // public int Skip { get; set; }

        //[JsonProperty("ps")]  >>> From Query
        public int PageSize { get; set; } = 10;
    }
}
