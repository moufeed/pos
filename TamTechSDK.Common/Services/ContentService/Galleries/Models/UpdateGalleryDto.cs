using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Galleries.Models
{
   public class UpdateGalleryDto
    {
        [Required]
        public string Lang { get; set; }

        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }


        [Required]
        public string Slug { get; set; }


        public string Summary { get; set; }

        public string MainImage { get; set; }
       
        public string Section { get; set; }

        public int DisplayOrder { get; set; }
       
        public List<string> Tags { get; set; }

        public string MetaDescription { get; set; }

        public DateTime? PublishedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string SEOMarkup { get; set; }

        public string AuthorName { get; set; }

        public DateTime? CustomDate { get; set; }

    }
}
