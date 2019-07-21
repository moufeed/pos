using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.Identity.Models.Params
{
    public class UserNameModel
    {
        [Required]
        [JsonProperty("username")]
        public string UserName { get; set; } 

    }
}
