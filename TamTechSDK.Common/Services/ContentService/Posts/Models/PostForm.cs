using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Posts.Models
{
    public class PostForm
    {
      
        [Required]
        public string Lang { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Slug { get; set; }

        [Required]
        public string Summary { get; set; }

        public string MainImage { get; set; }

        public string Section { get; set; }

        public Guid? SectionId { get; set; }

        public string Content { get; set; }

        public int DisplayOrder { get; set; }

        public string MetaDescription { get; set; }

        public List<string> Tags { get; set; }

        public DateTime? PostDate { get; set; }
    }
}


