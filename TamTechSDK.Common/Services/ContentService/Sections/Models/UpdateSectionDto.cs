using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Common.Services.ContentService.Sections.Models
{
    public class UpdateSectionDto : CreateSectionDto
    {
        public Guid Id { get; set; }

        public DateTime? PublishedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string SEOMarkup { get; set; }

    }
}
