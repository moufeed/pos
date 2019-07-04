using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Sections.Models
{
    public class CreateSectionDto
    {
        [Required]
        public string Lang { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Slug { get; set; }

        [Required]
        public string Summary { get; set; }
         
        public Guid? ParentId { get; set; }

        public string MainImage { get; set; }
         
        public int DisplayOrder { get; set; }
          
        public string MetaDescription { get; set; }
    }
}
