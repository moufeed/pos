using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TamTechSDK.Common.Services.ContentService.Menus.Models;

namespace TamTechSDK.Web.Models.Admin.Menus
{
    public class EditMenuVM
    {
        [Required]
        public Guid Id { get; set; }


        public string Title { get; set; }

        [Required]
        public string Key { get; set; }


        public string Position { get; set; }

        public bool Locked { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }


        public string Lang { get; set; }

        public List<MenuItemDto> MenuItems { get; set; }



    }
}
