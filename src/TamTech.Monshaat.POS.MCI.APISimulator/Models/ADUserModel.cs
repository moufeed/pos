using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTech.Monshaat.POS.MCI.APISimulator.Models
{
    public class ADUserModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public ADUserModel(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
