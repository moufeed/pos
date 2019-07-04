using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Galleries.Models
{
    public class GalleryItemKeysDto
    {

        [Required]
        [JsonProperty("galleryid")]
        public Guid GalleryId { get; set; }

        [Required]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }
}
