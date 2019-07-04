using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Web.Models.Admin.Galleries
{
    public class GalleryBaseItemVM
    {
        [Required]
        public string Lang { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid GalleryId { get; set; }

        public string Slug { get; set; }

        public string Summary { get; set; }

        public int DisplayOrder { get; set; }

        public bool Published { get; set; }

        public DateTime CreatedDate { get; set; }

        public string MetaDescription { get; set; }
    }
}
