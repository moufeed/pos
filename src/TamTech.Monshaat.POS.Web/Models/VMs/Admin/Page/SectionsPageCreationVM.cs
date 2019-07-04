using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TamTech.Monshaat.POS.Web.Models.VMs.Admin.Page
{
    public class SectionsPageCreationVM
    {
        [Required]
        public string Title { get; set; }

        public string Slug { get; set; }

        [Required]
        public Dictionary<string, string> Content { get; set; }

        public List<string> KeywordsList { get; set; }

        public string Keywords { get; set; }

        [Required]
        public string Summary { get; set; }


        public string MainImage { get; set; }

        public string Section { get; set; }

        public string Lang { get; set; }

        public string MetaDescription { get; set; }

        public int DisplayOrder { get; set; }

        public string AuthorName { get; set; }
        public string Key { get; set; }

    }
}
