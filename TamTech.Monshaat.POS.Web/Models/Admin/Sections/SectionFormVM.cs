using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Web.Models.Admin.Sections
{
    public class SectionFormVM
    {
        public Guid Id { get; set; }

        [Required]
        public string Lang { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Slug { get; set; }

        public int DisplayOrder { get; set; }

        [Required]
        public string Summary { get; set; }

        public string MainImage { get; set; }

        public Guid? ParentId { get; set; }

        public string MetaDescription { get; set; }

        public DateTime? PublishedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string SEOMarkup { get; set; }

        public bool Locked { get; set; }

        public bool Published { get; set; }

    }
}
