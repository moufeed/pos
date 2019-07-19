using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.SDK.Models.VMs.Admin.Menus
{
    public class MenuItemVm
    {
        public Guid MenuId { get; set; }

        public string ParentKey { get; set; }

        public string ItemType { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string UrlTarget { get; set; }

        public int DisplayOrder { get; set; }

        public string Lang { get; set; }

        public Guid RootMenuId { get; set; }

        public string Key { get; set; }

        public string FormAction { get; set; } = "EditMenuItemAsync";
    }
}
