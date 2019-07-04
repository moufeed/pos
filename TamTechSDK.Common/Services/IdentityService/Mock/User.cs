using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelWeb.Models
{
    public class _User
    {
        public string Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public string ImageUrl { get; set; }
        public string Gender { get; set; }
        [Required]
        public string Phone { get; set; }

        public string Email { get; set; }

        public bool Status { get; set; }

        public bool Confirmed { get; set; }

        public string Role { get; set; }
    }
}

