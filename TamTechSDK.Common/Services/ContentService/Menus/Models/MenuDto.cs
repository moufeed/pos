using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TamTechSDK.Common.Services.ContentService.Menus.Models
{
    public class MenuDto
    {
        public Guid Id { get; set; }

        public string Position { get; set; }

        public string Title { get; set; }

        public string Key { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public List<MenuItemDto> MenuItems { get; set; }

        public string Lang { get; set; }

        public bool Locked { get; set; }
    }
}
