using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.Identity.Auth.Models
{
  public  class ResetPOSAdminPasswordModel
    {
        [Required]
        [JsonProperty("u")]
        public string UserName { get; set; }

        [Required]
        [JsonProperty("p")]
        public string NewPassword { get; set; }
    }
}
