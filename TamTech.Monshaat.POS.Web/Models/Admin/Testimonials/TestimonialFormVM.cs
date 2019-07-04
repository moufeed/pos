using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Web.Models.Admin.Testimonials
{
    public class TestimonialFormVM
    {
        public Guid Id { get; set; }

        public string Lang { get; set; }

        public string Title { get; set; }

        public int DisplayOrder { get; set; }

        public string Summary { get; set; }

        public string MainImage { get; set; }

        public DateTime? PublishedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool Published { get; set; }

        public string Company { get; set; }
        public string Postion { get; set; }
        public string Email { get; set; }

        public string AuthorName { get; set; }
        public int Rating { get; set; }
    }
}
