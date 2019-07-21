using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.Identity.Auth.Models
{
  public  class SignupByName
    {
        [Required]
        [JsonProperty("p")]
        public string Password { get; set; }



        [Required]
        [JsonProperty("u")]
        public string Username { get; set; }
    }
}
