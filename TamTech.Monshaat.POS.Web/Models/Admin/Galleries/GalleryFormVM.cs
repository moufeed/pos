using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Web.Models.Admin.Galleries
{
    public class GalleryFormVM
    {
        [Required]
        public string Lang { get; set; }


        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        //TODO Convert To Constants
        [Required]
        [RegularExpression("^([A-Za-z0-9\u0621-\u064A0-9])+(?:[-|_]|[A-Za-z0-9\u0621-\u064A0-9])+([A-Za-z0-9\u0621-\u064A0-9])$")]
        public string Slug { get; set; }

        public string Summary { get; set; }

        public string MainImage { get; set; }

        public string Section { get; set; }

        public int DisplayOrder { get; set; }

        public List<string> Tags { get; set; }

        public List<GalleryItemFormVM> Items { get; set; }

        public bool Published { get; set; }

        public string MetaDescription { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? PublishedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string SEOMarkup { get; set; }

        public string AuthorName { get; set; }

        public bool Locked { get; set; }

        public DateTime? CustomDate { get; set; }
    }
}

