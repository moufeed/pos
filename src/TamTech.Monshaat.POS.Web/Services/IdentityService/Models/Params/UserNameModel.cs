using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Common.Services.Identity.Models.Params
{
    public class UserNameModel
    {
        [Required]
        [JsonProperty("username")]
        public string UserName { get; set; } 

    }
}
