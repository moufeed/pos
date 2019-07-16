using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTech.Monshaat.POS.MCIServices.Models
{
    public class AuthenticateADResultModel
    {
        [Required]
        [JsonProperty("status")]
        public bool Status { get; set; }

        [Required]
        [JsonProperty("authresult")]
        public bool AuthResult { get; set; }    
    }
}     