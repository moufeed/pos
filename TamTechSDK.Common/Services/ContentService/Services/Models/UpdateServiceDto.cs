using System;
using System.ComponentModel.DataAnnotations;

namespace TamTechSDK.Common.Services.ContentService.Services.Models
{
	public class UpdateServiceDto  
	{
        [Required]
        public Guid Id { get; set; }

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


        public string Content { get; set; } 


        public int DisplayOrder { get; set; }

        public string Icon { get; set; }

        public bool IconVisibility { get; set; }

        public string MetaDescription { get; set; }

        public DateTime? PublishedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string SEOMarkup { get; set; }

    }
}
