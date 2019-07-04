using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Testimonials.Models
{
    public class FormDto
    {
        public string Lang { get; set; }

        public string Title { get; set; }

        public int DisplayOrder { get; set; }

        public string Summary { get; set; }

        public string MainImage { get; set; }

        public string Company { get; set; }
        public string Postion { get; set; }
        public string Email { get; set; }

        public string AuthorName { get; set; }
        public int Rating { get; set; }
    }
}
