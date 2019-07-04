using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Web.Models.Admin.Posts
{
    public class PostVM
    {
        public Guid Id { get; set; }

        [Required]
        public string Lang { get; set; }

        [Required]
        public string Title { get; set; }

        //TODO Convert To Constants
        [Required]
        [RegularExpression("^([A-Za-z0-9\u0621-\u064A0-9])+(?:[-|_]|[A-Za-z0-9\u0621-\u064A0-9])+([A-Za-z0-9\u0621-\u064A0-9])$")]
        public string Slug { get; set; }

        public int DisplayOrder { get; set; }

        [Required]
        public string Summary { get; set; }

        public string MainImage { get; set; }

        public string Section { get; set; }

        public Guid? SectionId { get; set; }

        public string SectionSlug { get; set; }

        public string Content { get; set; }

        public string MetaDescription { get; set; }

        public DateTime? PublishedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string SEOMarkup { get; set; }

        public bool Locked { get; set; }

        public bool Published { get; set; }

        public List<string> Tags { get; set; }

        public string TagsString { get; set; }

        public DateTime? PostDate { get; set; }

    }
}
