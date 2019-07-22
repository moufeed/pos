using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.SDK.Models.VMs.Admin.Page
{
    public class SectionsPageEditingVM
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Slug { get; set; }


        public string Keywords { get; set; }

        public List<string> KeywordsList { get; set; }

        [Required]
        public Dictionary<string, string> Content { get; set; }

        [Required]
        public string Summary { get; set; }

        public string MainImage { get; set; }

        public string Section { get; set; }

        public string AuthorName { get; set; }

        public string Lang { get; set; }

        public int DisplayOrder { get; set; }

        public string MetaDescription { get; set; }

        public DateTime? PublishedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string SEOMarkup { get; set; }

        public bool Locked { get; set; }

        public bool Published { get; set; }

        public string Key { get; set; }
    }
}
