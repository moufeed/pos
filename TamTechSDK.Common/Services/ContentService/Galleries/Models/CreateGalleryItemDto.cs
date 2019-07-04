using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Galleries.Models
{
    public class CreateGalleryItemDto
    {
         
        public string Lang { get; set; }
        
        public string Title { get; set; }

        [Required]
        public Guid GalleryId { get; set; }
 
        public string Slug { get; set; }

        public string Summary { get; set; }
         
        public string MainImage { get; set; }

        public int DisplayOrder { get; set; }

        public List<string> Tags { get; set; }

        public string MetaDescription { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime? PublishedDate { get; set; }

        public string SEOMarkup { get; set; }

        public int GalleryItemType { get; set; }

        public string VideoUrl { get; set; }

    }
}
