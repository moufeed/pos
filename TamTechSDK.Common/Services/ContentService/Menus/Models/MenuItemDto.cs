using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Menus.Models
{
   public  class MenuItemDto
    {
        public string Title { get; set; }

        public string Key { get; set; }

        public string Url { get; set; }

        public string UrlTarget { get; set; }

        public string ItemType { get; set; }

        public bool Published { get; set; }

        public int DisplayOrder { get; set; }

        public List<MenuItemDto> MenuItems { get; set; }

        public string Lang { get; set; }
    }
}


 