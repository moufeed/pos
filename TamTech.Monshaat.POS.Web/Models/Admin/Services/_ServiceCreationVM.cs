using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TamTechSDK.Web.Models.Admin.Services
{
    public class _SerivceCreationVM
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Slug { get; set; }

        public int DisplayOrder { get; set; }

        [Required]
        public string Summary { get; set; }

        public string MainImage { get; set; }

        public string Section { get; set; }

        public string Content { get; set; }

        public string Icon { get; set; }

        public bool IconVisibility { get; set; }
    }
}
