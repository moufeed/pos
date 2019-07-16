using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTech.Monshaat.POS.MCIServices.Models
{
    public class ADUserModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }    
    }
}
