using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Services.ContentService.Pages.Enums;

namespace TamTech.Monshaat.POS.Web.Models.VMs.Admin.Page
{
    public class PageVM
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifierUserId { get; set; }

        public string CreatorUserId { get; set; }

        public string ClientId { get; set; }

        public bool Published { get; set; }

        public int Type { get; set; }

        public List<string> Keywords { get; set; } = new List<string>();

        public int DisplayOrder { get; set; }

        public PageTypeEnum TypeEnum { get; set; }


        public string Summary { get; set; }

        public string MainImage { get; set; }

        public string Section { get; set; }

        public string Lang { get; set; }

        public string MetaDescription { get; set; }

        public DateTime? PublishedDate { get; set; }

        public string AuthorName { get; set; }

        public string SEOMarkup { get; set; }

        public bool Locked { get; set; }
        public string Key { get; set; }
    }

}
