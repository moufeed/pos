using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Types.Models;

namespace TamTech.Monshaat.POS.Web.SDK.Models.VMs.Admin.Types
{
    public class TypeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public string Slug { get; set; }

        public string Tags { get; set; }

        public int DisplayOrder { get; set; }

        public string GenericField { get; set; }

        public string Lang { get; set; }
        public int? ParentId { get; set; }

        public Dictionary<string, bool> Options { get; set; }

        public bool IsOfficial { get; set; }


    }
}
