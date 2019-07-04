using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Common.Services.Identity.Auth.Models
{
    public class ChangePassword
    {
        [Required]
        [JsonProperty("c")]
        public string CurrentPassword { get; set; }


        [Required]
        [JsonProperty("n")]
        public string NewPassword { get; set; }

    }
}
