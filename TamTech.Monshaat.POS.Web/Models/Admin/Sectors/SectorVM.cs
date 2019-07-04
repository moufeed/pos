using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Web.Models.Admin.Sectors
{
    public class SectorVM
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }
        public string Image { get; set; }

        public string Slug { get; set; }

        public string Tags { get; set; }

        public int DisplayOrder { get; set; }

        public string GenericField { get; set; }

        public string Lang { get; set; }

        public bool Published { get; set; }

        public bool IsOfficial { get; set; }

        public int GroupId { get; set; }

        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifierUserId { get; set; }

        public string CreatorUserId { get; set; }

        public string ClientId { get; set; }

        public bool Locked { get; set; }

        public int? ParentId { get; set; }

        public IFormFile NewIcon { get; set; }
        public IFormFile NewMainImage { get; set; }
    }
}
