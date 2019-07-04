using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Galleries.Models
{
    public class CreateListGalleryItemsDto
    {
        [Required]
        public string Lang { get; set; }

        [Required]
        public Guid GalleryId { get; set; }

       
        public List<string> MainImages { get; set; }
    }
}
