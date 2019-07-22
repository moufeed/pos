using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTech.Monshaat.POS.Web.SDK.Services.Identity.Models
{
    public class AddUserToRolesModel
    {
        [Required]
        [JsonProperty("username")]
        public string UserName { get; set; }

        [Required]
        [JsonProperty("roles")]
        public List<string> RolesNames { get; set; }
    }
}
