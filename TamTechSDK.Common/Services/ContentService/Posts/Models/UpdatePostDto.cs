using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TamTechSDK.Common.Services.ContentService.Posts.Models
{
	public class UpdatePostDto  : PostForm
	{
        [Required]
        public Guid Id { get; set; }

        public DateTime? PublishedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string SEOMarkup { get; set; }
    }
}
