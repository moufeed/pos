using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Pages.Models
{
    public class PageSummary

    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
         
        public string Summary { get; set; }

        public string MainImage { get; set; }

        public string Section { get; set; }
    }
}
