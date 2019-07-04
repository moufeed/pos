using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TamTechSDK.Web.Models.Admin.Page
{
    public class HtmlPageEditingVM
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Slug { get; set; }

        [Required]
        public string Summary { get; set; }

        public string MainImage { get; set; }

        public string Section { get; set; }

        public string Keywords { get; set; }

        public List<string> KeywordsList { get; set; } = new List<string>();

        [Required]
        public string Content { get; set; }

        public string Lang { get; set; }

        public string MetaDescription { get; set; }


        public int DisplayOrder { get; set; }

        public DateTime? PublishedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string SEOMarkup { get; set; }

        public string AuthorName { get; set; }

        public bool Locked { get; set; }

        public bool Published { get; set; }

        public string Key { get; set; }
    }
}
